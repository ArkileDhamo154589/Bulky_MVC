$(document).ready(function () {
    loadDataTable();  // Εδώ καλούμε τη σωστή συνάρτηση
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/product/getall",  // Διόρθωση στο URL για την AJAX κλήση
            "type": "GET"
        },
        "columns": [
            { "data": "title" },
            { "data": "isbn" },
            { "data": "price" },
            { "data": "author" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit </a>
                    <button class="btn btn-danger mx-2" onclick="deleteProduct(${data})"> <i class="bi bi-trash-fill"></i> Delete </button>
                    </div>`
                }
            }
        ]
    });
}

// Function to handle delete
function deleteProduct(id) {
  
    Swal.fire({
        title: 'Are you sure?',
        text: "This action cannot be undone!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'Cancel',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: '/admin/product/delete?id=' + id,
                type: 'DELETE',
                success: function (response) {
                    if (response.success) {
    
                        Swal.fire({
                            icon: 'success',
                            title: 'Deleted!',
                            text: 'The product has been deleted successfully.',
                        }).then(() => {
                            dataTable.ajax.reload(); 
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error!',
                            text: 'There was an issue deleting the product.',
                        });
                    }
                },
                error: function (xhr, status, error) {
                   
                    Swal.fire({
                        icon: 'error',
                        title: 'Error!',
                        text: 'An error occurred: ' + error,
                    });
                }
            });
        } else {
           
            Swal.fire({
                icon: 'info',
                title: 'Cancelled',
                text: 'The product was not deleted.',
            });
        }
    });
}
