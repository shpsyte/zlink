let tags = GetAll(".tag-register");

for (let tag of tags) {
    tag.onclick = RegisterTag;
}

function RegisterTag() {
    event.preventDefault();

    let username = "admin";
    let targetLink = this.getAttribute("href");

    //register IP
    let data = {
        username,
        targetLink
    };
    _post("https://localhost:5001/app-store-data", data, SuccessAddData);

    //continue Fluxo

    //document.location(targetLink);
    window.open(targetLink, "_blank");
}

function SuccessAddData(data) {
    Print(data);
}

// $.get("https://www.cloudflare.com/cdn-cgi/trace", function(data) {
//     console.log(data);
// });

// $.getJSON("https://api.ipify.org?format=jsonp&callback=?", function(json) {
//     Print("My public IP address is: ", json.ip);
// });

// $.getJSON('https://api.ipgeolocation.io/ipgeo?apiKey=<your_api_key>', function (data) {
//     console.log(JSON.stringify(data, null, 2));
// });
