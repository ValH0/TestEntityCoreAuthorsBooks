$(document).ready(function () {
    $("#idAuthorsBooksTable").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "aLengthMenu": [[4, 6, 8], [4, 6, 8]],
        "ajax": {
            "url": "/AuthorsBooks/LoadData",
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
            { "data": "authorId", "name": "AuthorId", "autoWidth": true },
            { "data": "bookId", "name": "BookId", "autoWidth": true },
            { "data": "country", "name": "Country", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return '<ul><li style="display: inline;"> <button type="submit" class="delete" id=' + data.id + "delete" + " " + 'onClick="reply_clickDelete(' + data.id + ')" >Delete</button>'
                        + '<button type = "submit" class="edit" id = ' + data.id + "edit" + " " + 'onClick = "reply_clickEdit(' + data.id + ')" >Edit</button >'
                        + '<button type = "submit" class="search" id = ' + data.id + "search" + " " + 'onClick = "reply_clickShowAuthorsAndBooks(' + data.id + ')" >Show</button >' + '</li></ul>';
                }
            }
        ]
    });
});
