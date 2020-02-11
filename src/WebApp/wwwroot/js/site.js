// JS para adicionar novo link

let add = document.querySelector("#add");
add.addEventListener("click", () => {
    event.preventDefault();
    let name = GetOne("#Name").value;
    let targetlink = GetOne("#TargetLink").value;

    let url = add.getAttribute("data-url");

    let data = { name, targetlink };

    _post(url, data, CreateTagSucceful);
});

// Js para adicionar um novo item na tabela
function CreateTagSucceful(data) {
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
    label.appendChild(NewText("Active"));

    let button = NewElement("button");
    button.setAttribute("value", "update");
    button.appendChild(NewText("Update"));
    button.onclick = UpdateBtn;

    divDataInput.appendChild(inputName);
    divDataInput.appendChild(inputLink);
    divDataInput.appendChild(inputActive);
    divDataInput.appendChild(label);

    divDataActions.appendChild(button);

    divDataLinks.appendChild(divDataInput);
    divDataLinks.appendChild(divDataActions);

    form.appendChild(divDataLinks);
    divItem.appendChild(form);

    divLinks.prepend(divItem);
}

// JS para alterar uma tag existe
let btnUpdate = GetAll('button[data-type="update"]');

for (const btn of btnUpdate) {
    btn.addEventListener("click", UpdateBtn);
}

function UpdateBtn() {
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
}
