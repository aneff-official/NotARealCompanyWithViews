(function () {
    // Imitates loading data
    const initialDelay = 500;
    setTimeout(loadData, initialDelay);
})();

function loadData() {
    const spinner = document.getElementsByClassName("loader-container")[0];
    const table = document.getElementsByTagName("table")[0];

    // Hides spinner & shows the table
    spinner.remove();
    table.style.display = 'inline-table';
}