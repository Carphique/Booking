// Показать/скрыть пароль
function togglePassword(inputId, iconId) {
    const input = document.getElementById(inputId);
    const icon = document.getElementById(iconId);
    if (input.type === "password") {
        input.type = "text";
        icon.classList.replace("bi-eye", "bi-eye-slash");
    } else {
        input.type = "password";
        icon.classList.replace("bi-eye-slash", "bi-eye");
    }
}

// РЕГИСТРАЦИЯ
async function register() {
    const firstName = document.getElementById("firstName").value.trim();
    const lastName = document.getElementById("lastName").value.trim();
    const email = document.getElementById("email").value.trim();
    const phone = document.getElementById("phone").value.trim();
    const birth = document.getElementById("birth").value;
    const password = document.getElementById("regPassword").value.trim();
    const confirmPassword = document.getElementById("confirmPassword").value.trim();

    if (!firstName || !email || !password) {
        alert("Помилка: Заповніть основні поля!");
        return;
    }

    if (password !== confirmPassword) {
        alert("Помилка: Паролі не співпадають!");
        return;
    }

    const data = {
        firstName: firstName,
        lastName: lastName,
        email: email,
        password: password,
        phoneNumber: phone,
        dateOfBirth: birth
    };

    try {
        const res = await fetch("/api/Users", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        if (res.ok) {
            alert("Реєстрація успішна! Тепер увійдіть.");
            window.location.href = "login.html";
        } else {
            alert("Помилка реєстрації. Перевірте дані.");
        }
    } catch (err) {
        alert("Сервер не відповідає.");
    }
}

// ВХОД
async function login() {
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();

    if (!email || !password) {
        alert("Введіть email та пароль!");
        return;
    }

    try {
        const res = await fetch("/api/Auth/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email: email, password: password })
        });

        if (res.ok) {
            const data = await res.json();
            localStorage.setItem("jwtToken", data.token);
            alert("Успішний вхід!");
            window.location.href = "../index.html";
        } else {
            alert("Невірний email або пароль!");
        }
    } catch (err) {
        alert("Помилка з'єднання.");
    }
}