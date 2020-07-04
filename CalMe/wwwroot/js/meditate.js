document.getElementById("like").disabled = true;
document.getElementById("dislike").disabled = true;

var connection = new signalR.HubConnectionBuilder().withUrl("/MeditationHub").build();
connection.on("ReceiveMessage", function (meditationName, messageContent) {
    var name = meditationName.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var content = messageContent.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    document.getElementById("name").value = name;
    document.getElementById("content").value = content;
});

connection.start().then(function () {
    document.getElementById("like").disabled = false;
    document.getElementById("dislike").disabled = false;
}).catch(function (err) {
    return console.error(err);
});

document.getElementById("like").addEventListener("click", function (event) {
    var meditationName = document.getElementById("name").value;
    var messageContent = document.getElementById("content").value;
    connection.invoke("SendMeditationMetaData", "true").catch(function (err) {
        return console.error(err);
    });
    event.preventDefault();
});
document.getElementById("dislike").addEventListener("click", function (event) {
    var meditationName = document.getElementById("name").value;
    var messageContent = document.getElementById("content").value;
    connection.invoke("SendMeditationMetaData", "false").catch(function (err) {
        return console.error(err);
    });
    event.preventDefault();
});