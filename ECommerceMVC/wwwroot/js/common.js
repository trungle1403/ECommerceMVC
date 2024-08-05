
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

var Alert = {
    success: function (message) {
        iziToast.success({
            message: message,
            position: 'topRight'
        });
    },
    warning: function (message) {
        iziToast.warning({
            message: message,
            position: 'topRight'
        });
    }, 
    error: function (message) {
        iziToast.error({
            message: message,
            position: 'topRight'
        });
    }
}

/////////////////////// - Pagination ///////////////////////////////

function Pagination(pageIndex, listCount) {
    const pageSize = 5;
    var containerPage = ``;
    pageIndex = pageIndex == 0 ? 1 : pageIndex;
    var totalPage = Math.ceil(listCount / pageSize);

    containerPage += `<li class="page-item ${pageIndex == 1 ? 'disabled' : ""} " data="${(parseInt(pageIndex) - 1)}" onClick="changePage(this)"><a class="page-link page-link-item"  >Previous</a></li>`; 
    for (var i = 1; i <= totalPage; i++) {
        containerPage += `<li class="page-item ${pageIndex == i ? "active" : ""}"  data="${i}" onClick="changePage(this)"><a class="page-link page-link-item" >${i}</a></li>`
    }
    containerPage += `<li class="page-item ${pageIndex == totalPage ? 'disabled' : ""}"  data="${parseInt(pageIndex)+1}" onClick="changePage(this)"><a class="page-link page-link-item" >Next</a></li>`;
    return containerPage;
}

function changePage(e) {
    $('.page-item').each(function (index, element) {
        $(element).removeClass("active");
    });
    $(e).addClass('active')
}
/////////////////////// - Pagination - End ///////////////////////////////

