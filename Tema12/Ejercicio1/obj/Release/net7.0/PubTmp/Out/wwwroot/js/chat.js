"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (oMensajeUsuario) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${oMensajeUsuario.NombreUsuario} says ${oMensajeUsuario.MensajeUsuario}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let oMensajeUsuario = new clsMensajeUsuario()
    oMensajeUsuario.NombreUsuario = document.getElementById("userInput").value;
    oMensajeUsuario.MensajeUsuario = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", oMensajeUsuario).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

class clsMensajeUsuario{
    constructor(NombreUsuario, MensajeUsuario){
        this.NombreUsuario = NombreUsuario;
        this.MensajeUsuario = MensajeUsuario;
    }
}

