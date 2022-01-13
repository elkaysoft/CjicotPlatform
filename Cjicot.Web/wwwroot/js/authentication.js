function Login(username, password, loginUrl, myButton) {
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
            console.log(xhr.status);
            if (response !== null) {                
                if (response.code == '00') {
                    //localStorage.setItem('duid', username);
                    RedirectToDashboard(redirectUrl);
                    toastr.success('Successful');
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



function registerAuthor(apiUrl, fullName, email, mobile, username, password, myButton) {
    $.ajax({
        type: 'post',
        beforeSend: function () {
            $(myButton).text('Processing...');
            $(myButton).attr('disabled', 'disabled')
        },
        url: loginUrl,
        contentType: 'application/json; charset=UTF-8',
        data: JSON.stringify({
            "FullName": fullName, "Email": email,
            "MobileNumber": mobile, "Username": username,
            "Password": password
        }),
        success: function (response, textStatus, xhr) {            
            if (response !== null) {
                if (response.code == '00') {
                    toastr.success('Account successfully created, kindly proceed to Login');
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
}