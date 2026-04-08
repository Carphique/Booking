// LOGIN с проверками
async function login() {
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();

    // 1. ПРОВЕРКИ (Валидация)
    if (!email || !password) {
        alert("Помилка: Будь ласка, заповніть всі поля!");
        return;
    }
    if (!email.includes("@") || !email.includes(".")) {
        alert("Помилка: Введіть коректний email (наприклад: name@gmail.com)");
        return;
    }

    // 2. Отправка на бекенд (короткий URL, так как мы на одном сервере)
    const res = await fetch("/api/Auth/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email: email, password: password })
    });

    if (res.ok) {
        const data = await res.json();

        localStorage.setItem("jwtToken", data.token);
        localStorage.setItem("userEmail", email);

        const payload = JSON.parse(atob(data.token.split('.')[1]));
        const userId = payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        localStorage.setItem("userId", userId);

        alert("Успішний вхід!");
        window.location.href = "/"; // Перенаправляем на главную
    } else {
        alert("Помилка: Невірний логін або пароль!");
    }
}

// REGISTER с проверками
async function register() {
    const firstName = document.getElementById("firstName").value.trim();
    const lastName = document.getElementById("lastName").value.trim();
    const email = document.getElementById("email").value.trim();
    const phone = document.getElementById("phone").value.trim();
    const birth = document.getElementById("birth").value;

    // В HTML тебе нужно добавить поле <input type="password" id="regPassword"> 
    // Я пока захардкодил "Password123!", так как у тебя его не было в форме
    const password = "Password123!";

    // 1. ПРОВЕРКИ (Валидация)
    if (!firstName || !lastName || !email || !phone || !birth) {
        alert("Помилка: Заповніть всі обов'язкові поля!");
        return;
    }
    if (!email.includes("@")) {
        alert("Помилка: Email має містити символ @");
        return;
    }
    if (phone.length < 10) {
        alert("Помилка: Введіть коректний номер телефону");
        return;
    }

    // 2. Отправка на бекенд
    const data = {
        firstName: firstName,
        lastName: lastName,
        email: email,
        password: password,
        phoneNumber: phone,
        dateOfBirth: birth
    };

    const res = await fetch("/api/Users", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data)
    });

    if (res.ok) {
        alert("Реєстрація успішна! Тепер увійдіть.");
        window.location.href = "login.html";
    } else {
        alert("Помилка реєстрації. Можливо, такий email вже існує.");
    }
}