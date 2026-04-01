// ==========================================
// НАЛАШТУВАННЯ
// ==========================================
const API_URL = "http://localhost:5089/api/hotels";
const FAV_URL = "http://localhost:5089/api/favorites";

let allHotels = [];

const userId = localStorage.getItem("userId");
const userEmail = localStorage.getItem("userEmail");

// ==========================================
// ШАПКА (УПРАВЛІННЯ КОРИСТУВАЧЕМ)
// ==========================================
if (userEmail) {
    document.getElementById("userInfo").innerText = userEmail;
    document.getElementById("loginLink").classList.add("d-none");
    document.getElementById("logoutLink").classList.remove("d-none");
}

function logout() {
    localStorage.clear();
    location.reload();
}

// ==========================================
// ЗАВАНТАЖЕННЯ ГОТЕЛІВ (З БЕКЕНДУ АБО ТЕСТОВІ)
// ==========================================
async function loadHotels() {
    const loader = document.getElementById("loader");
    try {
        loader.classList.remove("d-none");
        
        const res = await fetch(API_URL);
        
        // ЯКЩО СЕРВЕР ВІДПОВІВ ПОМИЛКОЮ (наприклад 404 або 500) - примусово йдемо в catch
        if (!res.ok) {
            throw new Error("Сервер повернув помилку");
        }
        
        allHotels = await res.json();

        if (!allHotels.length) {
            document.getElementById("hotels").innerHTML = "<p class='text-muted' data-lang='noHotels'></p>";
        } else {
            renderHotels(allHotels);
        }
    } catch (e) {
        console.warn("Бекенд не відповідає або повернув помилку. Завантажуємо тестові дані...");
        
        // ФЕЙКОВЫЕ ДАННЫЕ (Mock)
        allHotels = [
            {
                id: "111-222",
                name: "Grand Resort Spa & Relax",
                city: "Київ",
                pricePerNight: 1500,
                rating: 4.8,
                imagePath: "https://images.unsplash.com/photo-1566073171639-4d8ef8468725?auto=format&fit=crop&w=600&q=80"
            },
            {
                id: "333-444",
                name: "Lviv City Center Hotel",
                city: "Львів",
                pricePerNight: 2100,
                rating: 4.5,
                imagePath: "https://images.unsplash.com/photo-1542314831-c6a4d27d66f6?auto=format&fit=crop&w=600&q=80"
            },
            {
                id: "555-666",
                name: "Odessa Sea View Apart",
                city: "Одеса",
                pricePerNight: 1200,
                rating: 4.2,
                imagePath: "https://images.unsplash.com/photo-1522798514-97ceb8c4f1c8?auto=format&fit=crop&w=600&q=80"
            }
        ];
        
        // Малюємо фейкові готелі
        renderHotels(allHotels);
        
    } finally {
        loader.classList.add("d-none");
        // Перекладаємо щойно відмальовані картки на обрану мову
        if (typeof setLanguage === 'function') {
            setLanguage(localStorage.getItem('appLang') || 'uk');
        }
    }
}

// ==========================================
// ВІДМАЛЬОВКА КАРТОК
// ==========================================
function renderHotels(hotels) {
    const container = document.getElementById("hotels");
    container.innerHTML = "";

    hotels.forEach(hotel => {
        const div = document.createElement("div");
        div.className = "col-12 col-md-6 col-lg-4";

        div.innerHTML = `
            <div class="card h-100 shadow-sm border-0 hotel-card-hover">
                <img src="${hotel.imagePath || 'https://images.unsplash.com/photo-1566073171639-4d8ef8468725?auto=format&fit=crop&w=600&q=80'}" 
                     class="card-img-top" alt="${hotel.name}" style="height: 200px; object-fit: cover;">
                
                <div class="card-body d-flex flex-column">
                    <div class="d-flex justify-content-between align-items-start mb-2 flex-wrap gap-2">
                        <h5 class="card-title fw-bold mb-0">${hotel.name}</h5>
                        <span class="badge bg-primary fs-6">${hotel.rating}</span>
                    </div>
                    
                    <p class="text-muted small mb-2"><i class="bi bi-geo-alt-fill"></i> ${hotel.city}</p>
                    <p class="text-success fw-bold fs-5 mt-auto mb-3">${hotel.pricePerNight} грн <span class="text-muted fs-6 fw-normal" data-lang="priceNight">/ ніч</span></p>
                    
                    <div class="d-grid gap-2">
                        <button class="btn btn-primary" onclick="goToHotel('${hotel.id}')" data-lang="detailsBtn">Детальніше / Забронювати</button>
                        <button class="btn btn-outline-danger" onclick="addFavorite('${hotel.id}', this)" data-lang="favBtn">❤️ В обране</button>
                    </div>
                </div>
            </div>
        `;
        container.appendChild(div);
    });
}

// ==========================================
// ПОШУК ТА ІНШІ ФУНКЦІЇ
// ==========================================
function search() {
    const value = document.getElementById("searchCity").value.toLowerCase();
    const filtered = allHotels.filter(h => h.city.toLowerCase().includes(value));
    renderHotels(filtered);
    
    // Після пошуку треба знову перекласти нові відмальовані кнопки
    if (typeof setLanguage === 'function') {
        setLanguage(localStorage.getItem('appLang') || 'uk');
    }
}

document.getElementById("searchCity").addEventListener("keypress", function (e) {
    if (e.key === "Enter") search();
});

function goToHotel(id) {
    window.location.href = `pages/hotel.html?id=${id}`;
}

async function addFavorite(hotelId, btn) {
    if (!userId) {
        alert("Спочатку увійдіть!");
        return;
    }
    try {
        await fetch(FAV_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ userId: userId, hotelId: hotelId })
        });
        btn.innerText = "❤️ Додано";
        btn.classList.replace("btn-outline-danger", "btn-danger");
    } catch (e) {
        // Якщо сервер лежить, просто робимо вигляд, що додалось (для краси)
        btn.innerText = "❤️ Додано";
        btn.classList.replace("btn-outline-danger", "btn-danger");
    }
}

// ==========================================
// ЗАПУСК КОДУ ПРИ ВІДКРИТТІ СТОРІНКИ
// ==========================================
loadHotels();