$(document).ready(function () {
    $("#idBookTable").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "aLengthMenu": [[4, 6, 8], [4, 6, 8]],
        "ajax": {
            "url": "/Books/LoadData",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
            [{
                "targets": [0],
                "visible": true,
                "searchable": false
            }],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "publisher", "name": "Publisher", "autoWidth": true },
            { "data": "name", "name": "Name", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return '<ul><li style="display: inline;"> <button type="submit" class="delete" id=' + data.id + "delete" + " " + 'onClick="reply_clickDelete(' + data.id + ')" >Delete</button>'
                        + '<button type = "submit" class="edit" id = ' + data.id + "edit" + " " + 'onClick = "reply_clickEdit(' + data.id + ')" >Edit</button >' + '</li></ul>';
                }
            }

        ]
    });
});



