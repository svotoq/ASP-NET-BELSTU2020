var contacts = [];

function getContacts() {
    if (document.getElementById("contacts-body") == null) {
        return;
    }
    $.ajax({
        url: "/ts",
        type: "GET",
        success: data => {
            contacts = [...data];
            displayContacts();
        }
    });
}

function addContact() {
    var phoneContact = {
        name: document.getElementById("name").value,
        phone: document.getElementById("phone").value
    };

    $.ajax({
        url: "/ts",
        type: "POST",
        data: phoneContact,
        success: contact => {
            contacts = [...contacts, contact];
            displayContacts();
        }
    });
}

function updateContact() {
    var phoneContact = {
        id: document.getElementById("idUpdate").value,
        name: document.getElementById("nameUpdate").value,
        phone: document.getElementById("phoneUpdate").value
    };

    $.ajax({
        url: "/ts",
        type: "PUT",
        data: phoneContact,
        success: contact => {
            contacts = contacts.map(x => {
                return x.Id === contact.Id
                    ? {
                        ...contact
                    }
                    : x;
            });
            clearUpdateContact();
            displayContacts();
        }
    });
}

function removeContact(id) {
    $.ajax({
        url: `/ts/${id}`,
        type: "DELETE",
        success: () => {
            contacts = contacts.filter(x => x.Id !== id);
            displayContacts();
        }
    });
}

function displaySelectedContact(id, name, phone) {
    document.getElementById("idUpdate").value = id;
    document.getElementById("nameUpdate").value = name;
    document.getElementById("phoneUpdate").value = phone;
}

function clearUpdateContact() {
    document.getElementById("idUpdate").value = "";
    document.getElementById("nameUpdate").value = "";
    document.getElementById("phoneUpdate").value = "";
}

function displayContacts() {
    var table = document.getElementById("contacts-body");
    table.innerHTML = "";
    contacts.forEach(contact => {
        let tr = document.createElement("tr");
        let name = document.createElement("td");
        let phone = document.createElement("td");
        let actions = document.createElement("td");
        name.innerHTML = contact.Name;
        phone.innerHTML = contact.Phone;

        //buttons
        var onClickAttribute = document.createAttribute("onclick");
        onClickAttribute.value = `removeContact(${contact.Id})`;

        var removeButton = document.createElement("button");
        removeButton.textContent = "Remove";
        removeButton.setAttributeNode(onClickAttribute);
        removeButton.classList.add("btn", "btn-danger");
        removeButton.setAttribute("style", "margin-left:10px");

        var onClickAttributeUpdate = document.createAttribute("onclick");
        onClickAttributeUpdate.value = `displaySelectedContact(${contact.Id}, "${contact.Name}", "${contact.Phone}")`;

        var updateButton = document.createElement("button");
        updateButton.textContent = "Update";
        updateButton.setAttributeNode(onClickAttributeUpdate);
        updateButton.classList.add("btn", "btn-default");

        actions.appendChild(updateButton);
        actions.appendChild(removeButton);

        tr.appendChild(name);
        tr.appendChild(phone);
        tr.appendChild(actions);


        table.appendChild(tr);
    });
}