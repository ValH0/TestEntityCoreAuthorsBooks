$(document).ready(function () {
    $("#idAuthorsTable").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "aLengthMenu": [[6, 8], [6, 8]],
        "ajax": {
            "url": "/Author/LoadData",
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
            { "data": "firstName", "name": "FirstName", "autoWidth": true },           
            { "data": "lastName", "name": "LastName", "autoWidth": true },
            { "data": "hasCustomImage", "name": "Image", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return '<ul><li style="display: inline;"> <button type="submit" class="delete" id=' + data.id + "delete" + " " + 'onClick="reply_clickDelete(' + data.id + ')" >Delete</button>'
                        + '<button type = "submit" class="edit" id = ' + data.id + "edit" + " " + 'onClick = "reply_clickEdit(' + data.id + ')" >Edit</button >'
                        + '<button type = "submit" class="search" id = ' + data.id + "search" + " " + 'onClick = "reply_clickShowAuthorBooks(' + data.id + ')" >Show Books</button >'
                        + '<a class="search" href="/Author/AuthorDetails?id=' + data.id + '">Details</a>'
                        + '</li></ul>';
                }
            }
        ]
    });
});
