let tags = GetAll(".tag-register");

for (let tag of tags) {
    tag.onclick = RegisterTag;
}

function RegisterTag() {
    event.preventDefault();

    let id = this.getAttribute("data-id");

    //register IP
    let data = { id };
    _post("https://localhost:5001/app-store-data", data, SuccessAddData);

    //continue Fluxo

    //document.location(targetLink);
    // window.open(targetLink, "_blank");
}

function SuccessAddData(data) {
    Print("ok");
    Print(data);
}


// $.getJSON('https://api.ipgeolocation.io/ipgeo?apiKey=8dcd359f87a84a679c93461a79de8202', function (data) {
//     console.log(JSON.stringify(data, null, 2));
// });
