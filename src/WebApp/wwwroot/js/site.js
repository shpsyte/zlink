// JS para adicionar novo link

let add = document.querySelector("#add");
add.addEventListener("click", () => {
    event.preventDefault();
    let name = GetOne("#Name").value;
    let link = GetOne("#TargetLink").value;
    let token = GetOne("input[name=__RequestVerificationToken]").value;
    let url = add.getAttribute("data-url");

    let data = { name, link };
    _post(url, token, data);
});

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

// Js para adicionar um novo item na tabela
function UpdateLinkElement(data) {
    AddNewLi(GetOne("#links"), NewText(data.name));
}
