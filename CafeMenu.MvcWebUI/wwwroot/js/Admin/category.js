$('#categoryTable').DataTable({
    pageLength: 10,
    "columnDefs": [
        {
            "render": function (data, type, row) {
                return `
                     <a class="btn btn-link btn-primary btn-lg" data-id="${row.categoryId}" href="/Admin/Category/Update">
                         <i class="fa fa-edit"></i>
                     </a>
                     <a class="btn btn-link btn-danger" data-id="${row.categoryId}" href="/Admin/Category/Delete">
                         <i class="fa fa-times"></i>
                     </a>
                    `;
            },
            "targets": 3
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
        "url": "/Admin/Category/GetAll",
        "type": "GET",
        "dataSrc": "categories"
    },
    "columns": [
        { "title": "Ana Kategori", "data": "parentCategoryName", "className": "text-center" },
        { "title": "Oluşturan Kullanıcı", "data": "user.fullName", "className": "text-center" },
        { "title": "Kategori Adı", "data": "categoryName", "className": "text-center" },
        { "title": "İşlemler", "data": null, "defaultContent": "", "className": "text-center" },
    ],
});