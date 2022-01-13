function RefreshAppUrl(appBaseUrl) {
    setTimeout(function () {
        window.location.href = appBaseUrl;
    }, 1500);
};


function RedirectFunction(appBaseUrl) {
    window.location.href = appBaseUrl;
};