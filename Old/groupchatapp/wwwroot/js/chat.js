//"use strict";

//$(function () {
//    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//    // Disable the send button until connection is established.
//    $("#sendButton").prop("disabled", true);

//    // Keep track of the current group for sending and displaying messages
//    var currentGroup = "";

//    // Join a group when a user clicks on its name
//    $(".groups-column li").click(function () {
//        const groupName = $(this).text();
//        currentGroup = groupName;
//        connection.invoke("JoinGroup", groupName);
//        // Fetch and display messages for the group
//        fetch(`/api/messages/group/${groupName}`)
//            .then(response => response.json())
//            .then(messages => {
//                messages.forEach(message => {
//                    // Display the message in the chat UI
//                    // ...
//                });
//            });
//    });

//    connection.on("ReceiveMessage", function (user, message) {
//        if (currentGroup === "") {
//            // Handle global messages if no group is selected
//        } else if (user.group === currentGroup) {
//            // Display message only if it's from the current group
//            $("#messagesList").append(`<li>${user} says ${message}</li>`);
//        }
//    });

//    connection.start().then(function () {
//        $("#sendButton").prop("disabled", false);
//    }).catch(function (err) {
//        console.error(err.toString());
//    });

//    $("#sendButton").click(function (event) {
//        const user = $("#userInput").val();
//        const message = $("#messageInput").val();
//        connection.invoke("SendMessageToGroup", currentGroup, user, message).catch(function (err) {
//            console.error(err.toString());
//        });
//        event.preventDefault();
//    });
//});


"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});