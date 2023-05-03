function confirmDelete(id, IsDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + id;
    var confirmSpan = 'confirmDeleteSpan_' + id;

    if (IsDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmSpan).hide();
    }

}