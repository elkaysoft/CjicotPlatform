function RefreshAppUrl(appBaseUrl) {
    setTimeout(function () {
        window.location.href = appBaseUrl;
    }, 1500);
};


function RedirectFunction(appBaseUrl) {
    window.location.href = appBaseUrl;
};

function GetJournalCategories(getUrl) {

    $('#journalType').empty();
    $('#journalType').append('<option selected="true" disabled>-Choose Category-</option>')
    $.getJSON(getUrl, function (data) {
        let obj = Object.entries(data.data);
        for (let [key, value] of obj) {
            $('#journalType').append($('<option></option>')
                .attr('value', value.id)
                .text(value.name));
        }
    });
};

function GetSalutations() {
    let salutations = ['Dr', 'Miss', 'Mr', 'Mrs'];

    $('.drpSalutations').empty();
    $('.drpSalutations').append('<option selected="true" disabled>-Choose-</option>')

    for (let [key, value] of salutations) {
        console.log(value);
        $('.drpSalutations').append($('<option></option>')
            .attr('value', value)
            .text(value));
    }
}

function ConvertFileToBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        return reader.result;
    };
    reader.onerror = function (error) {
        return error;
    }
}


function ValidateJournalExtension(docFileName, caller) {
    var fileExtension = ['pdf', 'doc', 'docx'];    
    let response = '';
    if (docFileName.length == 0) {
        response = 'Please select a ' + caller;
    }
    else {
        var extension = docFileName.replace(/^.*\./, '');
        if ($.inArray(extension, fileExtension) == -1) {
            response = 'Please upload a valid ' + caller +' file';
        }
    }

    return response;
}


function GetSelectedFileName(controId) {
    let result = '';
    $(controId).change(function (e) {
        var $val = e.target.files[0].name;
        result = $val;
    });
    console.log('Selected file name ' + result);
    return result;
}

function GetSelectedFileNameV2(controId) {
    let result = '';
    result = jQuery(controId).files[0].name;
    console.log('Selected file name ' + result);
    return result;
}