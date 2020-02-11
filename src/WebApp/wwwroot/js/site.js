// JS para adicionar novo link

let add = document.querySelector("#add");
add.addEventListener("click", () => {
    event.preventDefault();
    let name = GetOne("#Name").value;
    let targetlink = GetOne("#TargetLink").value;
    let token = GetOne("input[name=__RequestVerificationToken]").value;
    let url = add.getAttribute("data-url");

    let data = { name, targetlink };

    _post(url, token, data, successfull);
});

// Js para adicionar um novo item na tabela
function successfull(data) {
    let linkDto = data.data;
    let divLinks = GetOne(".links");

    let divItem = NewElement("div");
    divItem.setAttribute("class", "item");

    let form = NewElement("form");
    form.setAttribute("asp-antiforgery", "true");

    let divDataLinks = NewElement("div");
    divDataLinks.setAttribute("class", "data-links");

    let divDataInput = NewElement("div");
    divDataInput.setAttribute("class", "data-input");

    let divDataActions = NewElement("div");
    divDataActions.setAttribute("class", "data-action");

    let inputName = NewElement("input");
    inputName.setAttribute("type", "text");
    inputName.value = linkDto.name;

    let inputLink = NewElement("input");
    inputLink.setAttribute("type", "text");
    inputLink.value = linkDto.targetLink;

    let inputActive = NewElement("input");
    inputActive.setAttribute("type", "checkbox");

    let label = NewElement("label");
    label.appendChild(NewText("Actived"));

    let button = NewElement("button");
    button.setAttribute("value", "update");
    button.appendChild(NewText("Update"));

    divDataInput.appendChild(inputName);
    divDataInput.appendChild(inputLink);
    divDataInput.appendChild(inputActive);
    divDataInput.appendChild(label);

    divDataActions.appendChild(button);

    divDataLinks.appendChild(divDataInput);
    divDataLinks.appendChild(divDataActions);

    form.appendChild(divDataLinks);
    divItem.appendChild(form);

    divLinks.appendChild(divItem);
}
