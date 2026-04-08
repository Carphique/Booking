// --- ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ ---
function getUserIdFromToken() {
    const token = localStorage.getItem("jwtToken");
    if (!token) return null;
    try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        return payload.nameid || payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    } catch (e) { return null; }
}

// --- ГЛАВНАЯ СТРАНИЦА: ЗАГРУЗКА ОТЕЛЕЙ ---
async function loadHotels(cityQuery = "") {
    const container = document.getElementById("hotels");
    const countSpan = document.getElementById("hotelCount");
    const loader = document.getElementById("loader");
    if (!container) return;

    if (loader) loader.classList.remove("d-none");

    try {
        let url = "/api/Hotels";
        if (cityQuery) url += `?City=${encodeURIComponent(cityQuery)}`;

        const res = await fetch(url);
        const hotels = await res.json();

        if (countSpan) countSpan.innerText = hotels.length;

        if (hotels.length === 0) {
            container.innerHTML = `<h5 class="text-muted mt-4">На жаль, за вашим запитом нічого не знайдено.</h5>`;
        } else {
            container.innerHTML = hotels.map(h => createHotelCard(h)).join("");
        }

        if (!cityQuery) {
            renderFeaturedHotels(hotels);
        }

    } catch (e) {
        container.innerHTML = "Помилка з'єднання з сервером.";
    } finally {
        if (loader) loader.classList.add("d-none");
    }
}

// --- ОТРИСОВКА КАРУСЕЛИ ТОП-ОТЕЛЕЙ ---
function renderFeaturedHotels(allHotels) {
    const container = document.getElementById("featuredHotels");
    if (!container) return;

    const topHotels = [...allHotels].sort((a, b) => b.rating - a.rating).slice(0, 8);

    container.innerHTML = topHotels.map(h => {
        let imgUrl = h.imagePath || "https://picsum.photos/seed/hotel1/800/500";
        const rating = h.rating > 0 ? h.rating.toFixed(1) : "9.0";

        return `
        <div class="carousel-card position-relative">
            <button class="btn btn-light rounded-circle shadow-sm position-absolute top-0 end-0 m-2 d-flex align-items-center justify-content-center" 
                    onclick="toggleFavorite('${h.id}', this)" 
                    style="z-index: 10; width: 32px; height: 32px;">
                <i class="bi bi-heart fs-6 text-secondary"></i>
            </button>
            
            <img src="${imgUrl}" onerror="this.onerror=null;this.src='https://placehold.co/800x500/003580/FFF?text=Фото+готелю';" class="carousel-img" onclick="location.href='/pages/hotel.html?id=${h.id}'" style="cursor: pointer;">
            
            <div class="p-2">
                <h6 class="fw-bold mb-0 text-truncate" onclick="location.href='/pages/hotel.html?id=${h.id}'" style="cursor: pointer; color: #003580;">${h.name}</h6>
                <p class="text-muted small mb-2">${h.city}, Україна</p>
                
                <div class="d-flex align-items-center gap-2 mb-3">
                    <div class="bg-primary text-white rounded px-2 py-1 fw-bold" style="font-size: 0.85rem;">${rating}</div>
                    <span class="small fw-bold text-dark">Потрясаюче</span>
                </div>
                
                <div class="text-end">
                    <span class="text-muted small">Від </span>
                    <span class="fw-bold fs-6">UAH ${h.pricePerNight}</span>
                </div>
            </div>
        </div>`;
    }).join("");
}

// --- ГЕНЕРАЦИЯ КАРТОЧКИ В СПИСКЕ ---
function createHotelCard(hotel) {
    let imgUrl = hotel.imagePath || "https://picsum.photos/seed/hotel1/800/500";
    const rating = hotel.rating > 0 ? hotel.rating.toFixed(1) : "9.0";

    return `
    <div class="booking-card d-flex flex-column flex-md-row position-relative mb-3 border rounded shadow-sm bg-white overflow-hidden">
        <button class="btn btn-light rounded-circle shadow position-absolute top-0 end-0 m-2" onclick="toggleFavorite('${hotel.id}', this)" style="z-index: 10; width: 40px; height: 40px;">
            <i class="bi bi-heart fs-5 text-secondary"></i>
        </button>
        <img src="${imgUrl}" onerror="this.onerror=null;this.src='https://placehold.co/800x500/003580/FFF?text=Фото+готелю';" class="hotel-img-container" style="width: 250px; height: 200px; object-fit: cover; cursor: pointer;" onclick="location.href='/pages/hotel.html?id=${hotel.id}'">
        <div class="p-3 w-100 d-flex flex-column justify-content-between">
            <div>
                <div class="d-flex justify-content-between align-items-start">
                    <h4 class="text-primary fw-bold mb-1" style="cursor: pointer;" onclick="location.href='/pages/hotel.html?id=${hotel.id}'">${hotel.name}</h4>
                    <div class="rating-badge bg-primary text-white p-2 rounded fw-bold">${rating}</div>
                </div>
                <p class="text-muted small"><i class="bi bi-geo-alt-fill"></i> ${hotel.city}</p>
                <p class="text-success fw-bold small">Безкоштовне скасування</p>
            </div>
            <div class="d-flex justify-content-between align-items-end">
                <div><span class="fs-4 fw-bold">UAH ${hotel.pricePerNight}</span><br><span class="text-muted small">за 1 ніч</span></div>
                <button class="btn btn-primary fw-bold" onclick="location.href='/pages/hotel.html?id=${hotel.id}'">Переглянути ціни</button>
            </div>
        </div>
    </div>`;
}

// --- БРОНИРОВАНИЕ ---
async function createBooking() {
    const from = document.getElementById("dateFrom")?.value || document.getElementById("from")?.value;
    const to = document.getElementById("dateTo")?.value || document.getElementById("to")?.value;

    if (!from || !to) return Swal.fire('Увага', 'Оберіть дати заїзду та виїзду!', 'warning');

    const token = localStorage.getItem("jwtToken");
    const userId = getUserIdFromToken();
    const urlParams = new URLSearchParams(window.location.search);
    const hotelId = urlParams.get('id');

    if (!token || !userId) {
        return Swal.fire('Помилка', 'Увійдіть в акаунт для бронювання.', 'error').then(() => window.location.href = "/pages/login.html");
    }

    const data = { hotelId, roomId: "00000000-0000-0000-0000-000000000000", userId, dateFrom: from, dateTo: to };

    try {
        const res = await fetch("/api/Bookings", {
            method: "POST",
            headers: { "Content-Type": "application/json", "Authorization": `Bearer ${token}` },
            body: JSON.stringify(data)
        });

        if (res.ok) {
            Swal.fire({ icon: 'success', title: 'Бронювання успішне!', text: 'Переходимо до вашого кабінету...', timer: 2000, showConfirmButton: false })
                .then(() => window.location.href = "/pages/profile.html");
        } else {
            Swal.fire('Помилка', 'Місця на ці дати вже зайняті.', 'error');
        }
    } catch (e) { Swal.fire('Помилка', 'Сервер не відповідає.', 'error'); }
}

// --- ДОБАВЛЕНИЕ В ИЗБРАННОЕ ---
async function toggleFavorite(hotelId, btn) {
    const token = localStorage.getItem("jwtToken");
    if (!token) return Swal.fire('Увага', 'Увійдіть в акаунт, щоб зберігати готелі.', 'info');

    const userId = getUserIdFromToken();
    const res = await fetch("/api/Favorites", {
        method: "POST",
        headers: { "Content-Type": "application/json", "Authorization": `Bearer ${token}` },
        body: JSON.stringify({ userId, hotelId })
    });
    if (res.ok) {
        btn.querySelector('i').classList.replace('bi-heart', 'bi-heart-fill');
        btn.querySelector('i').classList.add('text-danger');
        Swal.fire({ icon: 'success', title: 'Збережено!', timer: 1000, showConfirmButton: false });
    }
}

// --- СТРАНИЦА ОДНОГО ОТЕЛЯ ---
async function loadSingleHotel() {
    const id = new URLSearchParams(window.location.search).get('id');
    if (!id) return;
    try {
        const res = await fetch(`/api/Hotels/${id}`);
        const h = await res.json();
        document.getElementById("hotelName").innerText = h.name;
        document.getElementById("hotelCity").innerText = h.city;
        document.getElementById("hotelPrice").innerText = `UAH ${h.pricePerNight}`;
        const imgUrl = h.imagePath || "https://picsum.photos/seed/hotel1/800/500";

        // Додаємо захист і сюди!
        document.querySelectorAll('img[alt="Main"], img[alt="Sub"]').forEach(img => {
            img.onerror = function () { this.onerror = null; this.src = 'https://placehold.co/800x500/003580/FFF?text=Фото+готелю'; };
            img.src = imgUrl;
        });
    } catch (e) { console.error(e); }
}

// --- ПРОФИЛЬ: ИЗБРАННОЕ И БРОНИ ---
async function loadFavorites() {
    const container = document.getElementById("favoritesList");
    if (!container) return;
    const userId = getUserIdFromToken();
    try {
        const res = await fetch(`/api/Favorites/user/${userId}`);
        const hotels = await res.json();
        container.innerHTML = hotels.length ? hotels.map(h => createHotelCard(h)).join("") : "<h5 class='text-muted'>Ви ще нічого не зберегли.</h5>";
    } catch (e) { container.innerHTML = "Помилка завантаження."; }
}

async function loadBookings() {
    const container = document.getElementById("bookingsList");
    if (!container) return;
    const userId = getUserIdFromToken();
    try {
        const res = await fetch(`/api/Bookings/user/${userId}`);
        const bookings = await res.json();
        container.innerHTML = bookings.length ? bookings.map(b => `
            <div class="card shadow-sm mb-3 border-start border-primary border-5">
                <div class="card-body">
                    <h5 class="fw-bold">${b.hotel ? b.hotel.name : "Готель"}</h5>
                    <p class="mb-1"><i class="bi bi-calendar-check"></i> Заїзд: <b>${new Date(b.dateFrom).toLocaleDateString()}</b> — Виїзд: <b>${new Date(b.dateTo).toLocaleDateString()}</b></p>
                    <span class="badge bg-success fs-6">Бронь підтверджена</span>
                </div>
            </div>
        `).join("") : "<h5 class='text-muted'>У вас поки немає бронювань.</h5>";
    } catch (e) { container.innerHTML = "Помилка завантаження."; }
}

// ==========================================
// ЛОГИКА ВЫПАДАЮЩЕГО СПИСКА ГОРОДОВ
// ==========================================
const ukraineCities = [
    "Київ", "Одеса", "Львів", "Харків", "Дніпро",
    "Вінниця", "Луцьк", "Донецьк", "Житомир", "Ужгород",
    "Запоріжжя", "Івано-Франківськ", "Кропивницький", "Луганськ",
    "Миколаїв", "Полтава", "Рівне", "Суми", "Тернопіль",
    "Херсон", "Хмельницький", "Черкаси", "Чернівці", "Чернігів", "Сімферополь", "Ялта", "Буковель"
];

function showCityDropdown() {
    const dropdown = document.getElementById("cityDropdown");
    if (dropdown) {
        dropdown.classList.remove("d-none");
        renderCities(ukraineCities);
    }
}

function hideCityDropdown() {
    setTimeout(() => {
        const dropdown = document.getElementById("cityDropdown");
        if (dropdown) dropdown.classList.add("d-none");
    }, 200);
}

function filterCities() {
    const inputVal = document.getElementById("searchCity").value.toLowerCase();
    const filtered = ukraineCities.filter(city => city.toLowerCase().includes(inputVal));
    renderCities(filtered);
}

function renderCities(citiesList) {
    const dropdown = document.getElementById("cityDropdown");
    if (!dropdown) return;

    if (citiesList.length === 0) {
        dropdown.innerHTML = `<div class="p-3 text-muted">Нічого не знайдено</div>`;
        return;
    }

    dropdown.innerHTML = citiesList.map(city => `
        <div class="p-2 border-bottom" style="cursor: pointer;" 
             onmouseover="this.style.backgroundColor='#f0f8ff'" 
             onmouseout="this.style.backgroundColor='transparent'"
             onclick="selectCity('${city}')">
            <i class="bi bi-geo-alt text-secondary me-2"></i> <span class="fw-bold text-dark">${city}</span>
        </div>
    `).join("");
}

function selectCity(city) {
    document.getElementById("searchCity").value = city;
    document.getElementById("cityDropdown").classList.add("d-none");
    search();
}

// --- ИНИЦИАЛИЗАЦИЯ ---
document.addEventListener("DOMContentLoaded", () => {
    const email = localStorage.getItem("userEmail");
    if (email && document.getElementById("userInfo")) {
        document.getElementById("userInfo").innerHTML = `<a href="/pages/profile.html" class="text-white text-decoration-none"><i class="bi bi-person-circle"></i> ${email}</a>`;
        document.getElementById("userInfo").classList.remove("d-none");
        document.getElementById("loginGroup")?.classList.add("d-none");
        document.getElementById("logoutLink")?.classList.remove("d-none");
    }

    if (document.getElementById("hotels")) loadHotels();
    if (window.location.pathname.includes("hotel.html")) loadSingleHotel();
    if (window.location.pathname.includes("profile.html")) {
        loadFavorites();
        loadBookings();
    }
});

function search() {
    const recSection = document.getElementById("recommendationsSection");
    if (recSection) recSection.classList.add("d-none");

    loadHotels(document.getElementById("searchCity").value.trim());
}
function logout() { localStorage.clear(); window.location.href = "/index.html"; }