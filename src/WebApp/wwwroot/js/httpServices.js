var GetOne = document.querySelector.bind(document);
var GetAll = document.querySelectorAll.bind(document);
var Print = console.log.bind(document);
var NewElement = document.createElement.bind(document);
var NewText = document.createTextNode.bind(document);

function AddNewLi(ul, text) {
    let li = NewElement("li");
    li.appendChild(text);
    ul.appendChild(li);
}

function _get(url, callback, errorcallback) {
    $.ajax({
        type: "GET",
        url: url,
        error: function(data) {
            if (typeof errorcallback !== "undefined") errorcallback(data);
        },
        success: function(data) {
            if (typeof callback !== "undefined") callback(data);
        },
        dataType: "json"
    });
}

function _post(url, token, data, callback, errorcallback) {
    $.ajax({
        type: "POST",
        headers: {
            RequestVerificationToken: token
        },
        url: url,
        data: data,
        error: function(data) {
            if (typeof errorcallback !== "undefined") errorcallback(data);
        },
        success: function(data) {
            if (typeof callback !== "undefined") callback(data);
        },
        dataType: "json"
    });
}
