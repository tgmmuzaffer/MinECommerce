//$(document).ready(function () {
//    $('#example').DataTable();
//});


//https://code.jquery.com/jquery-3.5.1.js
//https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js


window.addEventListener('DOMContentLoaded', event => {
    // Simple-DataTables
    // https://github.com/fiduswriter/Simple-DataTables/wiki

    const datatablesSimple = document.getElementById('datatablesSimple');
    if (datatablesSimple) {
        new simpleDatatables.DataTable(datatablesSimple);
    }
});