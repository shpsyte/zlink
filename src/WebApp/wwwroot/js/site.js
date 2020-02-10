// JS para adicionar novo link

let add = document.querySelector("#add");
add.addEventListener("click", () => {
    event.preventDefault();
    let name = GetOne("#Name").value;
    let link = GetOne("#TargetLink").value;
    let token = GetOne("input[name=__RequestVerificationToken]").value;
    let url = add.getAttribute("data-url");

    let data = { name, link };
    _post(url, token, data, successfull);
});

// Js para adicionar um novo item na tabela
function successfull(data) {
    AddNewLi(GetOne("#links"), NewText(data.data.name));
}
