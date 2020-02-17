var GetOne = document.querySelector.bind(document);
var GetAll = document.querySelectorAll.bind(document);
var Print = console.log.bind(document);
var NewElement = document.createElement.bind(document);
var NewText = document.createTextNode.bind(document);

function AddNewLi(ul, id, text) {
    let li = NewElement("li");
    li.appendChild(NewText(text));
    li.setAttribute("data-mobile-id", id);
    ul.appendChild(li);
}

function ToggleSpiner(behavior) {
    let loading = GetOne("#loading");

    if (loading !== null) {
        if (behavior === "hide") {
            loading.classList.add("hide");
        } else {
            loading.classList.remove("hide");
        }
    }
}

function _get(url, callback, errorcallback) {
    ToggleSpiner("show");
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
    ToggleSpiner("hide");
}

function _post(url, data, callback, errorcallback) {
    var token = GetOne("input[name=__RequestVerificationToken]").value;
    ToggleSpiner("show");
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
    ToggleSpiner("hide");
}
