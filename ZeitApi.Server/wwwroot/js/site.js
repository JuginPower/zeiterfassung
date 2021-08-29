function sendForm(uri="https://localhost:5001/Arbeiter/Login") {

    var username = document.getElementById("username").innerText;
    var password = document.getElementById("pwd").innerText;
    console.log("Das ist der Username: ", username);
    console.log("Das ist das Passwort: ", password);

    var item = {
        "name" : username,
        "pwd" : password
    }
    stritem = JSON.stringify(item);
    console.log("Das ist das gestringefeite Item: ", stritem);

    fetch(uri, {
        method: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: stritem
    }).then(response => response.json())
    .then(data => {
        if (data.answer == "Ok") {
            window.location.assign("dashboard.html");
        } else {
            alert(data.answer);
        }
    })
    .catch(error => console.error("Error:", error));
}
function getAnswer(uri="https://localhost:5001/Arbeiter/State") {
    
    fetch(uri, {
        method: "POST",
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded'
        }
    }).then(response => response.text())
    .then(data => {
        document.getElementById("res").innerHTML = data;
    }).catch((error) => {
        console.error("Error: ", error);
    });
}