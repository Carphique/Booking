const API_URL = "http://localhost:5089/api/hotels";
const FAV_URL = "http://localhost:5089/api/favorites";

let allHotels = [];

const userId = localStorage.getItem("userId");
const userEmail = localStorage.getItem("userEmail");

// показать пользователя
if (userEmail) {
    document.getElementById("userInfo").innerText = userEmail;
}

// загрузка
async function loadHotels() {
    const loader = document.getElementById("loader");

    try {
        loader.style.display = "block";

        const res = await fetch(API_URL);
        const hotels = await res.json();

        if (!hotels.length) {
            document.getElementById("hotels").innerHTML =
                "<p>Немає доступних готелів(</p>";
        }

        renderHotels(hotels);

    } catch (e) {
        document.getElementById("hotels").innerHTML =
            "<p>Помилка завантаження(</p>";
    } finally {
        loader.style.display = "none";
    }
}

// рейтинг текст
function getRatingText(rating) {
    if (rating >= 4.5) return "Відмінно";
    if (rating >= 4) return "Дуже добре";
    if (rating >= 3) return "Добре";
    return "Нормально";
}

// рендер
function renderHotels(hotels) {
    const container = document.getElementById("hotels");
    container.innerHTML = "";

    hotels.forEach(hotel => {
        const div = document.createElement("div");
        div.className = "hotel-card";

        div.innerHTML = `
            <div class="hotel-img">
                <img src="${hotel.imagePath || 'https://via.placeholder.com/200'}" />
            </div>

            <div class="hotel-content">
                <div class="hotel-title">${hotel.name}</div>
                <div class="hotel-city">${hotel.city}</div>

                <div class="rating">
                    ${getRatingText(hotel.rating)} ⭐ ${hotel.rating}
                </div>

                <div class="hotel-price">${hotel.pricePerNight} грн / ніч</div>

                <button class="btn" onclick="bookHotel('${hotel.id}')">
                    Забронювати
                </button>

                <button class="btn btn-fav" onclick="addFavorite('${hotel.id}', this)">
                    ❤️ В обране
                </button>
            </div>
        `;

        container.appendChild(div);
    });
}

// поиск
function search() {
    const value = document.getElementById("searchCity").value.toLowerCase();

    const filtered = allHotels.filter(h =>
        h.city.toLowerCase().includes(value)
    );

    renderHotels(filtered);
}

// ENTER поиск
document.getElementById("searchCity")
    .addEventListener("keypress", function (e) {
        if (e.key === "Enter") search();
    });

// бронирование
function bookHotel(id) {
    window.location.href = `booking.html?id=${id}`;
}

// избранное
async function addFavorite(hotelId, btn) {
    if (!userId) {
        alert("Спочатку увійдіть!");
        return;
    }

    await fetch(FAV_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            userId: userId,
            hotelId: hotelId
        })
    });

    btn.innerText = "Додано";
    btn.style.background = "gray";
}

// logout
function logout() {
    localStorage.clear();
    location.reload();
}

loadHotels();