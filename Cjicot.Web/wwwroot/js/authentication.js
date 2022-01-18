function Login(username, password, loginUrl, myButton, redirectUrl) {
    $.ajax({
        type: 'post',
        beforeSend: function () {
            $(myButton).text('Processing...');
            $(myButton).attr('disabled', 'disabled')
        },
        url: loginUrl,
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify({ "UserName": username, "Password": password }),
        success: function (response, textStatus, xhr) {            
            if (response !== null) {                
                if (response.code == '00') {
                    localStorage.setItem('_ozauthoruid', response.data.appUserId);
                    RedirectFunction(redirectUrl);
                }
                else {
                    //$('#dvErrorMessage').removeAttr('hidden');
                    toastr.error(response.message);                    
                    //$('#dvErrorMessage').text(response.message);
                }
            }

        },
        error: function (err) {
            toastr.error(err.responseJSON.message);
        },
        complete: function (xhr, textStatus) {
            $(myButton).text('Login');
            $(myButton).removeAttr('disabled');
        }
    })
};



function registerAuthor(apiUrl, fullName, email, mobile, username, password, gender, myButton) {
    $.ajax({
        type: 'post',
        beforeSend: function () {
            $(myButton).text('Processing...');
            $(myButton).attr('disabled', 'disabled')
        }, 
        url: apiUrl,
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify({
            "FullName": fullName, "Email": email,
            "MobileNumber": mobile, "Username": username,
            "Password": password, "Gender": gender
        }),
        success: function (response, textStatus, xhr) {            
            if (response !== null) {
                if (response.code == '00') {
                    toastr.success('Account successfully created, kindly proceed to Login');
                    clearAuthorRegistrationForm();
                }
            }
        },
        error: function (err) {
            toastr.error(err.responseJSON.message);
        },
        complete: function (xhr, textStatus) {
            $(myButton).text('Login');
            $(myButton).removeAttr('disabled');
        }
    });
};

function clearAuthorRegistrationForm() {
    $('#fullName').val('');
    $('#email').val('');
    $('#mobile').val('');
    $('#username').val('');
    $('#password').val('');    
}