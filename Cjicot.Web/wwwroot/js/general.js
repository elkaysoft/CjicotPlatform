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