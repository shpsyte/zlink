// JS para adicionar novo link

let add = document.querySelector("#add");
add.addEventListener("click", () => {
    this.disabled = true;

    event.preventDefault();
    let name = GetOne("#Name").value;
    let targetlink = GetOne("#TargetLink").value;
    let url = add.getAttribute("data-url");
    let data = { name, targetlink };
    _post(url, data, CreateTagSucceful);

    this.disabled = false;
});

// Js para adicionar um novo item na tabela
function CreateTagSucceful(data) {
    let total = GetOne("#TotalTags");
    let nextItem = total.value;
    ++nextItem;

    let linkDto = data.data;

    let divLinks = GetOne(".links");
    let url = GetOne("#url").value;

    let divItem = NewElement("div");
    divItem.setAttribute("class", "item");

    // let form = NewElement("form");
    // form.setAttribute("asp-antiforgery", "true");

    let divDataLinks = NewElement("div");
    divDataLinks.setAttribute("class", "data-links");

    let divDataInput = NewElement("div");
    divDataInput.setAttribute("class", "data-input");

    let divDataActions = NewElement("div");
    divDataActions.setAttribute("class", "data-action");

    let inputName = NewElement("input");
    inputName.setAttribute("type", "text");
    inputName.setAttribute("data-key", nextItem);
    inputName.setAttribute("data-name", "");
    inputName.setAttribute("value", linkDto.name);
    inputName.value = linkDto.name;

    let inputLink = NewElement("input");
    inputLink.setAttribute("type", "text");
    inputLink.setAttribute("data-key", nextItem);
    inputLink.setAttribute("data-link", "");
    inputLink.setAttribute("value", linkDto.targetLink);
    inputLink.value = linkDto.targetLink;

    let inputActive = NewElement("input");
    inputActive.setAttribute("type", "checkbox");
    inputActive.setAttribute("data-key", nextItem);
    inputActive.setAttribute("data-active", "");
    inputActive.setAttribute("data-type", "update");
    inputActive.setAttribute("data-url", url);
    inputActive.setAttribute("data-id", linkDto.id);
    inputActive.setAttribute("id", nextItem);
    inputActive.checked = linkDto.active;
    inputActive.onclick = UpdateTag;

    let label = NewElement("label");
    label.setAttribute("for", nextItem);
    label.appendChild(NewText("Active"));

    let button = NewElement("button");
    button.setAttribute("value", "update");
    button.setAttribute("data-key", nextItem);
    button.setAttribute("data-type", "update");
    button.setAttribute("data-id", linkDto.id);
    button.setAttribute("data-url", url);

    button.appendChild(NewText("Update"));

    button.onclick = UpdateTag;

    divDataInput.appendChild(inputName);
    divDataInput.appendChild(inputLink);
    divDataInput.appendChild(inputActive);
    divDataInput.appendChild(label);

    divDataActions.appendChild(button);

    divDataLinks.appendChild(divDataInput);
    divDataLinks.appendChild(divDataActions);

    //    form.appendChild(divDataLinks);
    divItem.appendChild(divDataLinks);

    divLinks.prepend(divItem);

    total.value = nextItem;
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
}
