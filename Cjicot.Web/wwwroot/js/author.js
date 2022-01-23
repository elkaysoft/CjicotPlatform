let coverletterDocName = '';
let manuscriptDocName = '';
let supplementaryDocName = ''

function UploadJournalRecord() {
    let coverletter_validation = ValidateJournalExtension(coverletterDocName, 'Cover Letter');
    let manuscript_validation = ValidateJournalExtension(manuscriptDocName, 'Manuscript');
    let supplementarydoc_validation = ValidateJournalExtension(supplementaryDocName, 'Supplementary file');
    
    if (coverletter_validation != '') {
        toastr.error(coverletter_validation);
        return;
    }
    if (manuscript_validation != '') {
        toastr.error(manuscript_validation);
        return;
    }
    if (supplementarydoc_validation != '') {
        toastr.error(supplementarydoc_validation);
        return;
    }
}




$('#fpCoverLetter').change(function (e) {
    var $val = e.target.files[0].name;
    coverletterDocName = $val;
});

$('#fpManuscript').change(function (e) {
    var $val = e.target.files[0].name;
    manuscriptDocName = $val;
});

$('#fpSupplementary').change(function (e) {
    var $val = e.target.files[0].name;
    supplementaryDocName = $val;
});