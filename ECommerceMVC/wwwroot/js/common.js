
function getAjax(Url, data) {
    var result = null;
    $.ajax({
        type: "GET",
        url: Url,
        traditional: true,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            result = response;
        },
        error: function (response) {
            result = null;
            console.log(response);
        }
    });
    if (result === null) return null;
    try {
        return result
    } catch (e) { }
}

function getAjaxAsync(Url, data) {
    $.ajax({
        type: "GET",
        url: Url,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            result = response;
        },
        error: function (response) {
            result = null;
            console.log(response);
        }
    })
    if (result === null) return null;
    try {
        return JSON.parse(result.toString());
    } catch (e) { }
}

function formaterCheckBox(value) {
    return `<div class="form-check d-flex justify-content-center align-items-center"><input disabled="disabled" class="form-check-input" type="checkbox" value="" ` + (value ? 'checked' : '') + `></div>`;
}

function formaterbtnThaoTac(ID) {
    return `<div><a class='text-primary btnEditGrid' title="Sửa" data='${ID}'><i class="far fa-edit"></i></a></b>&ensp;<a class='text-danger btnEditGrid' title="Xoá" data='${ID}'><i class='fas fa-times'></i></a></div>`;
};

var TabulatorLangsVi = {
    "default": {
        "columns": {
            "name": "Name",
        },
        "ajax": {
            "loading": "Đang tải...",
            "error": "Lỗi tải dữ liệu",
        },
        "groups": {
            "item": "dòng",
            "items": "dòng",
        },
        "pagination": {
            "page_size": "Kích thước",
            "page_title": "Hiển thị",
            "first": '<i class="fa fa-step-backward" aria-hidden="true"></i>',
            "first_title": "Trang đầu",
            "last": '<i class="fa fa-step-forward" aria-hidden="true"></i>',
            "last_title": "Trang cuối",
            "prev": '<i class="fa fa-chevron-left" aria-hidden="true"></i>',
            "prev_title": "Lùi lại",
            "next": '<i class="fa fa-chevron-right" aria-hidden="true"></i>',
            "next_title": "Kế tiếp",
            "all": "All",
            "counter": {
                "showing": "Hiển thị",
                "of": "của",
                "rows": "dòng",
                "pages": "trang",
            }
        },
        "headerFilters": {
            "default": "filter column...",
            "columns": {
                "name": "filter name...",
            }
        },
    }
}