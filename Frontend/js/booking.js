const urlParams = new URLSearchParams(window.location.search);
const hotelId = urlParams.get("id");

const API_URL = "http://localhost:5089/api/bookings";

const today = new Date().toISOString().split("T")[0];
document.getElementById("from").min = today;
document.getElementById("to").min = today;

async function createBooking() {
    const from = document.getElementById("from").value;
    const to = document.getElementById("to").value;

    const userId = localStorage.getItem("userId");
    const resultText = document.getElementById("result");

    if (!userId) {
        resultText.innerText = "Спочатку увійдіть!";
        return;
    }

    if (!from || !to) {
        resultText.innerText = "Оберіть дати!";
        return;
    }

    const booking = {
        hotelId: hotelId,
        roomId: "00000000-0000-0000-0000-000000000000",
        userId: userId,
        dateFrom: from,
        dateTo: to
    };

    const response = await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
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