var database = firebase.database();

// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
var $usernameInput = $("#username");
var $usernameLabel = $("#usrname-label");
var $loginBtn = $("#login-btn");
var $logoutBtn = $("#logout-btn");
var $chatbox = $("#chatbox");
var $messageInput = $("#message-text");
var $sendBtn = $("#send-btn");

// localStorage.setItem("username", "1"); localStorage.removeItem("username");
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text

window.onload = (function () {
    if (localStorage.getItem("username")) {
        $usernameLabel.css("display", "none");
        $usernameInput.css("display", "none");
        $loginBtn.css("display", "none");
    } else {
        $logoutBtn.css("display", "none");
    }
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
// Some text
    
});

// Login event
$loginBtn.on('click', function (ev) {
    if ($usernameInput.val() !== "") {
        localStorage.setItem("username", $usernameInput.val().trim());
        $usernameInput.css("display", "none");
        // Some text
// Some text
// Some text
// Some text
// Some text

        $usernameLabel.css("display", "none");

        $loginBtn.css("display", "none");
        $logoutBtn.css("display", "");
    }
});
// Some text
// Some text
// Some text
// Some text
// Some text

$logoutBtn.on('click', function (ev) {
    localStorage.removeItem("username");
    $usernameInput.css("display", "");
    $usernameLabel.css("display", "");
    $loginBtn.css("display", "");

    $logoutBtn.css("display", "none");
});

function sendMessage(message) {
    let date = new Date();
    $.ajax({
        type: "POST",
        url: "https://test-50a3e.firebaseio.com/messages.json",
        data: JSON.stringify({
            "senton": `${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`,
            "sender": `${localStorage.getItem("username")}`,
            "message": `${message}`
        })
    });
}
// Some text
// Some text
// Some text

$sendBtn.on('click', function(ev) {
    let msg = $messageInput.val().trim();
    if(msg !== "" && localStorage.getItem("username")) {
        sendMessage(msg);
        $messageInput.val("");
    }
    else {
        throw "Not logged in";
    }
});
// Some text
// Some text
// Some text

let getFromDB = function getMessagesPromise() {
    return new Promise((resolve, reject) => {
        $.get("https://test-50a3e.firebaseio.com/messages.json", function(data) {        
            resolve(data);
        });
    });
};
// Some text
// Some text
// Some text
// Some text

function parseMessages(data) {
    let result = [];

    for(let key in data) {
        result.push({
            senton: data[key].senton,
            sender: data[key].sender,
            message: data[key].message
        });
    }

    console.log("Parse messages >>");
    console.log(result.length);

    return result;
}

function displayMessages(messages) {
    let result = "";
    for(let i = 0; i < messages.length; i += 1) {
        result += `${messages[i].senton} =>> - ${messages[i].sender} : ${messages[i].message}\n`;
    }

    console.log(result);
    $chatbox.val(result);
}



// Some text
// Some text
// Some text
// Some text


database.ref().on('value', function(ev) {
    getFromDB()
        .then(parseMessages)
        .then(displayMessages);
});


