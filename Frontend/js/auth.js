const API_URL = "http://localhost:5089/api/users";

// LOGIN (простой, без JWT)
async function login() {
    const email = document.getElementById("email").value;

    const res = await fetch(API_URL);
    const users = await res.json();

    const user = users.find(u => u.email === email);

    if (!user) {
        alert("Користувач не знайден");
        return;
    }

    localStorage.setItem("userId", user.id);
    localStorage.setItem("userEmail", user.email);

    alert("Успешный вход!");
    window.location.href = "../index.html";
}

// REGISTER
async function register() {
    const data = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        email: document.getElementById("email").value,
        phoneNumber: document.getElementById("phone").value,
        dateOfBirth: document.getElementById("birth").value
    };

    const res = await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    });

    if (res.ok) {
        alert("Реєстрація успішна!");
        window.location.href = "login.html";
    } else {
        alert("Помилка реєстрації");
    }
}