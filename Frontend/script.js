const API_URL = "http://localhost:5089/api/hotels";

let allHotels = [];

async function loadHotels() {
    const response = await fetch(API_URL);
    const hotels = await response.json();

    allHotels = hotels;
    renderHotels(hotels);
}

function renderHotels(hotels) {
    const container = document.getElementById("hotels");
    container.innerHTML = "";

    hotels.forEach(hotel => {
        const div = document.createElement("div");

        div.style.border = "1px solid black";
        div.style.margin = "10px";
        div.style.padding = "10px";

        div.innerHTML = `
            <h3>${hotel.name}</h3>
            <p>Город: ${hotel.city}</p>
            <p>Свободных номеров: ${hotel.roomsAvailable}</p>
            <button onclick="bookHotel('${hotel.id}')">Забронировать</button>
        `;

        container.appendChild(div);
    });
}

// поиск
document.getElementById("search").addEventListener("input", function () {
    const value = this.value.toLowerCase();

    const filtered = allHotels.filter(h =>
        h.city.toLowerCase().includes(value)
    );

    renderHotels(filtered);
});

// переход к бронированию
function bookHotel(id) {
    window.location.href = `booking.html?id=${id}`;
}

loadHotels();