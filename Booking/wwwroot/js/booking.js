function getUserIdFromToken() {
    const token = localStorage.getItem("jwtToken");
    if (!token) return null;
    try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        return payload.nameid || payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    } catch (e) { return null; }
}

// async function createBooking() {
//     const from = document.getElementById("dateFrom")?.value || document.getElementById("from")?.value;
//     const to = document.getElementById("dateTo")?.value || document.getElementById("to")?.value;

//     if (!from || !to) return Swal.fire('Увага', 'Оберіть дати заїзду та виїзду!', 'warning');

//     const dateF = new Date(from);
//     const dateT = new Date(to);
//     const today = new Date();
//     today.setHours(0, 0, 0, 0); // Обнуляємо години, щоб перевіряти тільки день

//     if (dateF < today) {
//         return Swal.fire('Помилка', 'Дата заїзду не може бути в минулому!', 'error');
//     }
//     if (dateT <= dateF) {
//         return Swal.fire('Помилка', 'Дата виїзду має бути пізніше за дату заїзду!', 'error');
//     }

//     const token = localStorage.getItem("jwtToken");
//     const userId = getUserIdFromToken();
//     const hotelId = new URLSearchParams(window.location.search).get('id');

//     if (!token || !userId) {
//         return Swal.fire('Помилка', 'Увійдіть в акаунт для бронювання.', 'error')
//             .then(() => window.location.href = "/pages/login.html");
//     }

//     // roomId = той самий номер що й готель, але з префіксом 10000000
//     const roomId = `10000000-0000-0000-0000-${hotelId.split('-').pop()}`;

//     try {
//         const res = await fetch("/api/Bookings", {
//             method: "POST",
//             headers: {
//                 "Content-Type": "application/json",
//                 "Authorization": `Bearer ${token}`
//             },
//             body: JSON.stringify({ hotelId, roomId, userId, dateFrom: from, dateTo: to })
//         });

//         if (res.ok) {
//             Swal.fire({
//                 icon: 'success',
//                 title: 'Бронювання успішне!',
//                 text: 'Переходимо до вашого кабінету...',
//                 timer: 2000,
//                 showConfirmButton: false
//             }).then(() => window.location.href = "/pages/profile.html");
//         } else {
//             const err = await res.text();
//             Swal.fire('Помилка', err || 'Ці дати зайняті.', 'error');
//         }
//     } catch (e) {
//         Swal.fire('Помилка', 'Сервер не відповідає.', 'error');
//     }
// }

async function createBooking() {
    const from = document.getElementById("dateFrom")?.value || document.getElementById("from")?.value;
    const to = document.getElementById("dateTo")?.value || document.getElementById("to")?.value;

    if (!from || !to) {
        return Swal.fire('Увага', 'Оберіть дати заїзду та виїзду!', 'warning');
    }

    // === ЖОРСТКА ПЕРЕВІРКА ДАТ ===
    const dFrom = new Date(from);
    const dTo = new Date(to);
    const today = new Date();
    today.setHours(0, 0, 0, 0);

    if (dFrom < today) {
        return Swal.fire('Помилка', 'Неможливо забронювати в минулому часі!', 'error');
    }
    if (dTo <= dFrom) {
        return Swal.fire('Помилка', 'Дата виїзду має бути пізніше за дату заїзду!', 'error');
    }
    // ============================

    const token = localStorage.getItem("jwtToken");
    const userId = getUserIdFromToken(); // переконайся, що ця функція є в файлі
    const hotelId = new URLSearchParams(window.location.search).get('id');

    if (!token || !userId) {
        return Swal.fire('Помилка', 'Увійдіть в акаунт для бронювання.', 'error')
            .then(() => window.location.href = "/pages/login.html");
    }

    const roomId = `10000000-0000-0000-0000-${hotelId.split('-').pop()}`;

    try {
        const res = await fetch("/api/Bookings", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify({ hotelId, roomId, userId, dateFrom: from, dateTo: to })
        });

        if (res.ok) {
            Swal.fire({
                icon: 'success',
                title: 'Бронювання успішне!',
                text: 'Переходимо до вашого кабінету...',
                timer: 2000,
                showConfirmButton: false
            }).then(() => window.location.href = "/pages/profile.html");
        } else {
            const err = await res.text();
            Swal.fire('Помилка', err || 'Ці дати зайняті.', 'error');
        }
    } catch (e) {
        Swal.fire('Помилка', 'Сервер не відповідає.', 'error');
    }
}