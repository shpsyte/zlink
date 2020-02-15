let tags = GetAll(".tag-register");

for (let tag of tags) {
    tag.addEventListener("mousedown", RegisterTag);
}

function RegisterTag() {
    event.preventDefault();

    let id = this.getAttribute("data-id");
    let url = this.getAttribute("data-url");
    let targetLink = this.getAttribute("href");

    let data = { id };
    _post(url, data);

    window.open(targetLink, "_blank");
}
