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
        Swal.fire({ icon: 'warning', title: 'Увага', text: 'Заповніть основні поля!' });
        return;
    }

    if (password !== confirmPassword) {
        Swal.fire({ icon: 'error', title: 'Помилка', text: 'Паролі не співпадають!' });
        return;
    }

    const data = {
        firstName: firstName, lastName: lastName,
        email: email, password: password,
        phoneNumber: phone, dateOfBirth: birth
    };

    try {
        const res = await fetch("/api/Users", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

        if (res.ok) {
            Swal.fire({
                icon: 'success',
                title: 'Реєстрація успішна!',
                text: 'Зараз вас буде перенаправлено на сторінку входу...',
                timer: 2000,
                showConfirmButton: false
            }).then(() => {
                window.location.href = "login.html"; // Кидаем на логин
            });
        } else {
            Swal.fire({ icon: 'error', title: 'Помилка', text: 'Помилка реєстрації. Перевірте дані.' });
        }
    } catch (err) {
        Swal.fire({ icon: 'error', title: 'Помилка', text: 'Сервер не відповідає.' });
    }
}

// ВХОД
async function login() {
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();

    if (!email || !password) {
        Swal.fire({ icon: 'warning', title: 'Увага', text: 'Введіть email та пароль!' });
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
            localStorage.setItem("userEmail", email); // СОХРАНЯЕМ EMAIL ДЛЯ ШАПКИ!

            Swal.fire({
                icon: 'success',
                title: 'Успішний вхід!',
                text: 'Повертаємось на головну...',
                timer: 1500,
                showConfirmButton: false
            }).then(() => {
                window.location.href = "../index.html"; // Возвращаем на главную
            });
        } else {
            Swal.fire({ icon: 'error', title: 'Помилка', text: 'Невірний email або пароль!' });
        }
    } catch (err) {
        Swal.fire({ icon: 'error', title: 'Помилка', text: 'З\'єднання з сервером втрачено.' });
    }
}

// Показать/скрыть пароль (остается как было)
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