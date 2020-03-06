var GetOne = document.querySelector.bind(document);
var GetAll = document.querySelectorAll.bind(document);
var Print = console.log.bind(document);
var NewElement = document.createElement.bind(document);
var NewText = document.createTextNode.bind(document);

function AddNewLi(ul, id, text, classs) {
    let li = NewElement("li");
    li.appendChild(NewText(text));
    li.setAttribute("data-mobile-id", id);
    li.setAttribute("class", classs);
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
        //  data: data,
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

function RegisterTag() {
    let tags = GetAll(".tag-register");

    for (let tag of tags) {
        tag.addEventListener("mousedown", RegisterClickOnTag);
    }

    function RegisterClickOnTag() {
        event.preventDefault();

        let id = this.getAttribute("data-id");
        let url = this.getAttribute("data-url");
        let targetLink = this.getAttribute("href");

        let data = { id };
        _post(url, data);

        window.open(targetLink, "_blank");
    }
}

function Listening() {
    // JS que escuta o link criado
    var idTime;
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/newTagHub")
        .build();

    function ConectToServer() {
        Print("trying connect...");
        connection
            .start()
            .then(HandleNewConnection())
            .catch(function(err) {
                return console.error(err.toString());
            });
    }

    ConectToServer();

    connection.on("NewTagAdd", function(data) {
        UpdateLinkElement(data);
    });

    connection.onclose(() => {
        idTime = setTimeout(ConectToServer, 5000);
    });

    function HandleNewConnection() {
        Print("listening...");
        if (idTime !== null) clearTimeout(idTime);
    }
}

function AreaChart() {
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var id = GetOne("#Id").value;
        var url = GetOne("#url").value + "/" + id;
        _get(url, success);
    }

    function success(data) {
        var dataCol = new google.visualization.DataTable();
        dataCol.addColumn("string", "Date");
        dataCol.addColumn("number", "Access");
        for (i = 0; i < data.length; i++)
            dataCol.addRow([data[i].key, data[i].qtd]);

        var options = {
            title: "Access By Day",
            hAxis: { title: "Days", titleTextStyle: { color: "#333" } },
            vAxis: { minValue: 0, scaleType: "int", format: "#" },
            legend: "none"
        };

        var chart = new google.visualization.AreaChart(
            document.getElementById("chart_div")
        );
        chart.draw(dataCol, options);
    }
}

function SetupCreateLink() {
    let add = document.querySelector("#add");
    add.addEventListener("click", () => {
        this.disabled = true;

        event.preventDefault();
        let name = GetOne("#Name").value;
        let targetlink = GetOne("#TargetLink").value;
        let url = add.getAttribute("data-url");
        let data = { name, targetlink };
        _post(url, data, CreateTag);

        this.disabled = false;
    });

    // Js para adicionar um novo item na tabela
    function CreateTag(data) {
        CreateElementForTag(data);
        CreateElementForMobile(data);
    }

    function CreateElementForTag(data) {
        let total = GetOne("#TotalTags");
        let nextItem = total.value;
        ++nextItem;

        let linkDto = data.data;

        let divLinks = GetOne(".links");
        let url = GetOne("#url").value;

        let divDataInput = NewElement("div");
        divDataInput.setAttribute("class", "data-input");

        let button = NewElement("button");
        button.setAttribute("value", "update");
        button.setAttribute("data-key", nextItem);
        button.setAttribute("data-type", "update");
        button.setAttribute("data-id", linkDto.id);
        button.setAttribute("data-url", url);
        button.setAttribute("class", "btn g-bg-primary rounded-0");
        button.appendChild(NewText("Update"));
        button.onclick = UpdateTag;

        let inputName = NewElement("input");
        inputName.setAttribute("type", "text");
        inputName.setAttribute("data-key", nextItem);
        inputName.setAttribute("data-name", "");
        inputName.setAttribute("value", linkDto.name);
        inputName.setAttribute(
            "class",
            "form-control form-control-xs rounded-0"
        );
        inputName.value = linkDto.name;

        let inputLink = NewElement("input");
        inputLink.setAttribute("type", "text");
        inputLink.setAttribute("data-key", nextItem);
        inputLink.setAttribute("data-link", "");
        inputLink.setAttribute("value", linkDto.targetLink);
        inputLink.setAttribute(
            "class",
            "form-control form-control-xs rounded-0"
        );
        inputLink.value = linkDto.targetLink;

        let i = NewElement("i");
        i.setAttribute("class", "fa");
        i.setAttribute("data-check-icon", "");

        let divIcon = NewElement("div");
        divIcon.setAttribute(
            "class",
            "u-check-icon-checkbox-v4 g-absolute-centered--y g-left-0"
        );
        divIcon.appendChild(i);

        let inputActive = NewElement("input");
        inputActive.setAttribute("type", "checkbox");
        inputActive.setAttribute("data-key", nextItem);
        inputActive.setAttribute("data-active", "");
        inputActive.setAttribute("data-type", "update");
        inputActive.setAttribute("data-url", url);
        inputActive.setAttribute("data-id", linkDto.id);
        inputActive.setAttribute("id", nextItem);
        inputActive.setAttribute("value", true);
        inputActive.setAttribute("checked", true);

        inputActive.setAttribute(
            "class",
            "g-hidden-xs-up g-pos-abs g-top-0 g-left-0"
        );
        inputActive.checked = linkDto.active;
        inputActive.onclick = UpdateTag;

        let labelItem = NewElement("label");
        labelItem.setAttribute("class", "u-check g-pl-25");

        labelItem.appendChild(divIcon);
        labelItem.appendChild(inputActive);

        let divActive = NewElement("div");
        divActive.setAttribute(
            "class",
            "form-group g-mb-0 d-flex align-items-center"
        );
        divActive.appendChild(labelItem);

        divDataInput.appendChild(button);
        divDataInput.appendChild(inputName);
        divDataInput.appendChild(inputLink);

        divDataInput.appendChild(divActive);

        divLinks.prepend(divDataInput);

        // let divItem = NewElement("div");
        // divItem.setAttribute("class", "item");

        // let divDataLinks = NewElement("div");
        // divDataLinks.setAttribute("class", "data-links");

        // let divDataActions = NewElement("div");
        // divDataActions.setAttribute("class", "data-action");

        // let label = NewElement("label");
        // label.setAttribute("for", nextItem);
        // label.appendChild(NewText("Active"));

        // divDataInput.appendChild(inputName);
        // divDataInput.appendChild(inputLink);
        // divDataInput.appendChild(inputActive);
        // divDataInput.appendChild(label);

        // divDataActions.appendChild(button);

        // divDataLinks.appendChild(divDataInput);
        // divDataLinks.appendChild(divDataActions);

        // //    form.appendChild(divDataLinks);
        // divItem.appendChild(divDataLinks);

        // divLinks.prepend(divItem);

        total.value = nextItem;
    }

    function CreateElementForMobile(data) {
        let url = "/app-get-link/" + data.username;

        _get(
            url,
            function(data) {
                GetOne(".view-link").innerHTML = data.responseText;
            },
            function(data) {
                GetOne(".view-link").innerHTML = data.responseText;
            }
        );

        // let linkDto = data.data;
        // let ul = GetOne("#mobile");

        // AddNewLi(ul, linkDto.id, linkDto.name, "btn btn-md u-btn-primary");
    }

    // JS para alterar uma tag existe
    let btnUpdate = GetAll('*[data-type="update"]');

    for (const btn of btnUpdate) {
        btn.addEventListener("click", UpdateTag);
    }

    function UpdateTag() {
        event.preventDefault();
        let btn = this;
        let url = btn.getAttribute("data-url");
        let key = btn.getAttribute("data-key");
        let id = btn.getAttribute("data-id");
        let name = GetOne(`input[data-name][data-key="${key}"] `).value;
        let targetlink = GetOne(`input[data-link][data-key="${key}"] `).value;
        let active = GetOne(`input[data-active][data-key="${key}"] `).checked;
        let data = { id, name, targetlink, active, key };

        _post(url, data, UpdateTagSucceful);
    }

    function UpdateTagSucceful(data) {
        let linkDto = data.data;
        let key = linkDto.key;

        let name = GetOne(`input[data-name][data-key="${key}"] `);
        let targetlink = GetOne(`input[data-link][data-key="${key}"] `);
        let active = GetOne(`input[data-active][data-key="${key}"] `);

        name.value = linkDto.name;
        targetlink.value = linkDto.targetLink;
        active.checked = linkDto.active;

        UpdateMobile(linkDto.id, linkDto.name, linkDto.active);
    }

    function UpdateMobile(id, name, activeItem) {
        let li = GetOne(`li[data-mobile-id="${id}"]`);

        if (li !== null) {
            if (!activeItem) {
                li.parentNode.removeChild(li);
            } else {
                li.innerHTML = name;
            }
        } else {
            let ul = GetOne("#mobile");
            AddNewLi(ul, id, name, "btn btn-md u-btn-primary");
        }
    }
}

function SetupDashBoard() {
    var d = function DrawDash(id) {
        let url = GetOne("#url").value + "/" + id;
        _get(url, DrawGraph);
    };

    function DrawGraph(data) {
        GetOne("#name").innerHTML = data.name;
        GetOne("#totalClick").innerHTML = data.stats.totalClicks;
        GetOne("#totalUniqueClick").innerHTML = data.stats.totalUniqueClicks;

        let clickByDay = data.stats.clicksByDay;
        let clicksByMonth = data.stats.clicksByMonth;
        let clicksByYear = data.stats.clicksByYear;
        let clicksByRegion = data.stats.clicksByRegion;
        let clicksByCity = data.stats.clicksByCity;
        let clicks = data.stats.clicks;

        drawChart(clickByDay, "Days", "Access By Day", "#byday");
        drawChart(clicksByMonth, "Month", "Access By Month", "#bymonth");
        drawChart(clicksByYear, "Year", "Access By Year", "#byyear");
        drawChart(clicksByRegion, "Region", "Access By Region", "#byregion");
        drawChart(clicksByCity, "City", "Access By City", "#bycity");
        drawTable(clicks);
    }

    function drawTable(data) {
        let dataTable = [];

        for (i = 0; i < data.length; i++)
            dataTable.push(
                new Array(
                    data[i].country,
                    new Date(data[i].data).toLocaleDateString("pt-Br"),
                    data[i].postalCode,
                    data[i].regionName,
                    data[i].city
                )
            );

        let table = $("#clicks").DataTable({ retrieve: true, data: dataTable });
        table.destroy();
        table = $("#clicks").DataTable({ retrieve: true, data: dataTable });
    }

    function drawChart(data, column, title, divToGraph) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(function drawChart() {
            var dataTable = new google.visualization.DataTable();
            dataTable.addColumn("string", column);
            dataTable.addColumn("number", "Clicks");

            for (i = 0; i < data.length; i++)
                dataTable.addRow([data[i].key, data[i].qtd]);

            var options = {
                title: title,
                hAxis: { title: column, titleTextStyle: { color: "#333" } },
                vAxis: { minValue: 0, scaleType: "int", format: "#" },
                legend: "none"
            };

            var chart = new google.visualization.ColumnChart(
                GetOne(divToGraph)
            );

            chart.draw(dataTable, options);
        });
    }

    GetOne("#Id").addEventListener("change", function() {
        d(this.value);
    });
}
