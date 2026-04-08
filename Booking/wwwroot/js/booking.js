async function createBooking() {
    const from = document.getElementById("from").value;
    const to = document.getElementById("to").value;

    const userId = localStorage.getItem("userId");
    const token = localStorage.getItem("jwtToken"); // <-- Дістаємо токен
    const resultText = document.getElementById("result");

    if (!userId || !token) {
        resultText.innerText = "Спочатку увійдіть!";
        return;
    }

    if (!from || !to) {
        resultText.innerText = "Оберіть дати!";
        return;
    }

    const booking = {
        hotelId: hotelId,
        roomId: "00000000-0000-0000-0000-000000000000", // Поки заглушка, як і було у тебе
        userId: userId,
        dateFrom: from,
        dateTo: to
    };

    const response = await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}` // <-- Відправляємо токен на бекенд
        },
        body: JSON.stringify(booking)
    });

    if (response.ok) {
        resultText.innerText = "Бронювання успішне";
    } else {
        const error = await response.text();
        resultText.innerText = "Помилка: " + error;
    }
}