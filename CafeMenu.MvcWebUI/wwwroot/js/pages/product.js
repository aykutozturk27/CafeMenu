$('#productTable').DataTable({
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
        "url": "/Product/GetAll",
        "type": "GET",
        "dataSrc": ""
    },
    "columns": [
        { "title": "Ürün Adı", "data": "productName" },
        { "title": "Resim", "data": "imagePAth" },
        { "title": "Kategori Adı", "data": "categoryName" },
        { "title": "Fiyat", "data": "price" },
        { "title": "Oluşturulma Tarihi", "data": "createdDate" }
    ]
});