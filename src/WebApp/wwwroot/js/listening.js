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
