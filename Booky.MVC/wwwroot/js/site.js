function loadata() {
    $('#myTable').DataTable({
        "ajax": {
            url: "/Eastate/getall",
            type: "GET",
            dataType: "json",
            contentType: "application/json"
        },
        "searching": true, // Enable search feature
        "columnDefs": [{
            "targets": 'form-control', // Apply search to columns with class 'searchable'
            "searchable": true
        }],
        "columns": [
            { data: 'id' },
            { data: 'name' },
            { data: 'details' }, // Ensure the property names match the actual JSON response
            { data: 'rate' },
            { data: 'sqft' },
            {
                data: null,
                render: function (row) {
                    return '<div class="m-75 btn-group"><a href=/Admin/Eastate/Edit/' + row.id + ' class="btn btn-primary mx-2"> Edit</a > <a href=/Admin/Eastate/Delete/' + row.id + ' class="btn btn-danger mx-2">Delete</a></div > '
                }
            } // Ensure the property names match the actual JSON response

        ]
    });
    $('div.dataTables_filter input').addClass('form-control');
    $('div.dataTables_length select').addClass('form-control');
}

