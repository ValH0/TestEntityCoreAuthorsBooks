$(document).ready(function () {
    $("#idEmployeesTable").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "aLengthMenu": [[4, 6, 8], [4, 6, 8]],
        "ajax": {
            "url": "/Employee/LoadData",
            "type": "POST",
            "datatype": "JSON"
        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": true,
                "searchable": false
            }],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "departmentName", "name": "Department", "autoWidth": true },
            { "data": "fullName", "name": "Full Name", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return '<ul><li style="display: inline;"> <button type="submit" class="delete" id=' + data.id + "delete" + " " + 'onClick="reply_clickDelete(' + data.id + ')" >Delete</button>'
                        + '</li></ul>';
                }
            }
        ]
    });
});
