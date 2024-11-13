$('#propertyTable').DataTable({
    pageLength: 10,
    "columnDefs": [
        {
            "render": function (data, type, row) {
                return `
                     <button type="button" data-bs-toggle="tooltip" title="" data-id="${row.propertyId}" class="btn btn-link btn-primary btn-lg btn-update" data-original-title="Güncelle">
                        <i class="fa fa-edit"></i>
                     </button>
                     <button type="button" data-bs-toggle="tooltip" title="" data-id="${row.propertyId}" class="btn btn-link btn-danger btn-delete" data-original-title="Sil">
                        <i class="fa fa-times"></i>
                     </button>
                    `;
            },
            "targets": 2
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
        "url": "/Admin/Property/GetAll",
        "type": "GET",
        "dataSrc": "properties"
    },
    "columns": [
        { "title": "Anahtar Adı", "data": "key", "className": "text-center" },
        { "title": "Değer Adı", "data": "value", "className": "text-center" },
        { "title": "İşlemler", "data": null, "defaultContent": "", "className": "text-center" },
    ],
});

$('#propertyTable tbody').on('click', '.btn-update', function () {
    var data = $('#propertyTable').DataTable().row($(this).parents('tr')).data();
    window.location.href = '/Admin/Property/Update?propertyId=' + data.propertyId;
});

$('#propertyTable tbody').on('click', '.btn-delete', function () {
    var data = $('#propertyTable').DataTable().row($(this).parents('tr')).data();
    $.ajax({
        url: '/Admin/Property/Delete',
        type: 'POST',
        data: { propertyId: data.propertyId },
        success: function (response) {
            if (response) {
                Swal.fire("Silindi", "", "success");
                $('#propertyTable').DataTable().ajax.reload();
            } else {
                Swal.fire("Error!", "Ürün durumu güncellenirken bir hata oluştu.", "error");
            }
        },
        error: function (xhr, status, error) {
            Swal.fire("Error!", "Ürün durumu güncellenirken bir hata oluştu.", "error");
        }
    });
});