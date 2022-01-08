function Login(username, password) {
    $.ajax({
        type: 'post',
        beforeSend: function () {
            $(myButton).text('Processing...');
            $(myButton).attr('disabled', 'disabled')
        },
        url: loginUrl,
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify({ "UserName": username, "Password": password }),
        success: function (response) {
            console.dir(response);

            if (response !== null) {
                if (response.responseCode == '00') {
                    $('#dvErrorMessage').attr('hidden', 'hidden');
                    localStorage.setItem('duid', username);
                    RedirectToDashboard(redirectUrl);
                }
                else if (response.responseCode == '06') {
                    $('#dvErrorMessage').attr('hidden', 'hidden');
                    toastr.error('Invalid Email/Password');
                }
                else if (response.responseCode == '02') {
                    $('#dvErrorMessage').attr('hidden', 'hidden');
                    toastr.error('Sorry! Your email has not been provisioned for this platform');
                }
                else if (response.responseCode == '05') {
                    $('#dvErrorMessage').removeAttr('hidden');
                }
                else {
                    $('#dvErrorMessage').attr('hidden', 'hidden');
                    toastr.error(response.responseMessage);
                }
            }
            else {
                $('#dvErrorMessage').attr('hidden', 'hidden');
                toastr.error('Oooops! An error occured while processing your request');
            }

        },
        error: function (err) {
            console.log(err);
            $('#dvErrorMessage').attr('hidden', 'hidden');
            toastr.error('Error Occured while logging in');
        },
        complete: function () {
            $(myButton).text('Login');
            $(myButton).removeAttr('disabled');
        }
    })
};


function RedirectFunction(appBaseUrl) {
    window.location.href = appBaseUrl;
};