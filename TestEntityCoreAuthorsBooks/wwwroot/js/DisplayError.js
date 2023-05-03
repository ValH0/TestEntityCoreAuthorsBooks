function errorShow(elem) {
    if (elem === null) {
        return;
    }

    if (elem.style.display === 'block') {
        elem.style.display = 'none';
    }
}