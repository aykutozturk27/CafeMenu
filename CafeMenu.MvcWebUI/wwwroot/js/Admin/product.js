$('#productTable').DataTable({
    pageLength: 10,
    "columnDefs": [
        {
            "render": function (data, type, row) {
                return `
                     <button type="button" data-bs-toggle="tooltip" title="" data-id="${row.productId}" class="btn btn-link btn-primary btn-lg btn-update" data-original-title="Güncelle">
                        <i class="fa fa-edit"></i>
                     </button>
                     <button type="button" data-bs-toggle="tooltip" title="" data-id="${row.productId}" class="btn btn-link btn-danger btn-delete" data-original-title="Sil">
                        <i class="fa fa-times"></i>
                     </button>
                    `;
            },
            "targets": 5
        }
    ],
    "scrollX": true,
    "destroy": true,
    language: {
        'paginate': {
            'previous': '<span class="bx bx-left-arrow"></span>',
            'next': '<span class="bx bx-right-arrow"></span>'
        },
        "lengthMenu": 'Display <select class="form-control input-sm">' +
            '<option value="10">10</option>' +
            '<option value="20">20</option>' +
            '<option value="30">30</option>' +
            '<option value="40">40</option>' +
            '<option value="50">50</option>' +
            '<option value="-1">All</option>' +
            '</select> results'
    },
    "ajax": {
        "url": "/Admin/Product/GetAll",
        "type": "GET",
        "dataSrc": "products"
    },
    "columns": [
        { "title": "Ürün Adı", "data": "productName", "className": "text-center" },
        { "title": "Fiyat", "data": "price", "className": "text-center" },
        {
            "title": "Ürün Resmi", "data": "imagePath", "render": function (data, type, row) {
                return '<a href="' + data + '"target="_blank" ><img src="' + data + '" alt="' + row.imagePath + '" height="100px"> </a>';
            }
        },
        { "title": "Kategori Adı", "data": "category.categoryName", "className": "text-center" },
        { "title": "Kullanıcı Adı", "data": "user.username", "className": "text-center" },
        { "title": "İşlemler", "data": null, "defaultContent": "", "className": "text-center" },
    ],
});

$('#productTable tbody').on('click', '.btn-update', function () {
    var data = $('#productTable').DataTable().row($(this).parents('tr')).data();
    window.location.href = '/Admin/Product/Update?productId=' + data.productId;
});

$('#productTable tbody').on('click', '.btn-delete', function () {
    var data = $('#productTable').DataTable().row($(this).parents('tr')).data();
    $.ajax({
        url: '/Admin/Product/Delete',
        type: 'POST',
        data: { productId: data.productId },
        success: function (response) {
            if (response) {
                Swal.fire("Silindi", "", "success");
                $('#productTable').DataTable().ajax.reload();
            } else {
                Swal.fire("Error!", "Ürün durumu güncellenirken bir hata oluştu.", "error");
            }
        },
        error: function (xhr, status, error) {
            Swal.fire("Error!", "Ürün durumu güncellenirken bir hata oluştu.", "error");
        }
    });
});