const urlParams = new URLSearchParams(window.location.search);
const hotelId = urlParams.get("id");

async function createBooking() {
    const email = document.getElementById("email").value;
    const from = document.getElementById("from").value;
    const to = document.getElementById("to").value;

    const booking = {
        hotelId: hotelId,
        userEmail: email,
        dateFrom: from,
        dateTo: to
    };

    const response = await fetch("http://localhost:5089/api/bookings", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(booking)
    });

    const resultText = document.getElementById("result");

    if (response.ok) {
        resultText.innerText = "Бронирование успешно";
    } else {
        const error = await response.text();
        resultText.innerText = "Ошибка: " + error;
    }
}