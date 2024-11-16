$('#productTable').DataTable({
    "columnDefs": [
        {
            "render": function (data, type, row) {
                return commaSeparateNumber(data);
            },
            "targets": 3
        },
        {
            targets: [4],
            render: function (data, type, row) {
                if (type === 'display' || type === 'filter') {
                    let date = new Date(data);
                    let day = String(date.getDate()).padStart(2, '0');
                    let month = String(date.getMonth() + 1).padStart(2, '0'); // Aylar 0'dan başlar
                    let year = date.getFullYear();
                    let hours = String(date.getHours()).padStart(2, '0');
                    let minutes = String(date.getMinutes()).padStart(2, '0');
                    return `${day}/${month}/${year} ${hours}:${minutes}`;
                }
                return data;
            }
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
        "url": "/Product/GetAll",
        "type": "GET",
        "dataSrc": "products"
    },
    "columns": [
        { "title": "Ürün Adı", "data": "productName" },
        {
            "title": "Ürün Resmi", "data": "imagePath", "render": function (data, type, row) {
                return '<a href="' + data + '"target="_blank" ><img src="' + data + '" alt="' + row.imagePath + '" height="100px"> </a>';
            }
        },
        { "title": "Kategori Adı", "data": "category.categoryName" },
        { "title": "Fiyat", "data": "price" },
        { "title": "Oluşturulma Tarihi", "data": "createdDate" }
    ]
});