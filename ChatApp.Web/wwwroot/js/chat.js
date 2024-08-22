"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

// Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (sender, message) {
  const msg = document.createElement("li");
  msg.classList.add('clearfix');
  msg.innerHTML = `
            <div class="message-data">
                  <span class="message-data-time">${sender}</span>
              </div>
            <div class="message my-message">${message}</div>`;
  document.getElementById("messagesList").appendChild(msg);
});

connection.start().then(function () {
  document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
  return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
  const sender = document.getElementById("sender").value;
  const receiver = document.getElementById("receiver").value;
  const message = document.getElementById("messageInput").value;

  if (message.trim() === "") return;  // Prevent empty messages

  connection.invoke("SendMessage", sender, receiver, message).catch(function (err) {
    return console.error(err.toString());
  });

  document.getElementById("messageInput").value = "";

  event.preventDefault();
});
