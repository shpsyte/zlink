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
