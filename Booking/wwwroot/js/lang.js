const translations = {
    uk: {
        // Загальне
        langMenu: "🌍 Мова",
        loginLink: "Увійти",
        logoutLink: "Вийти",
        backHome: "На головну",
        
        // Головна
        searchPlaceholder: "Куди поїдемо?",
        searchBtn: "Пошук",
        recommendedTitle: "Рекомендовані готелі",
        loadError: "Помилка завантаження. Перевірте, чи працює сервер.",
        noHotels: "Немає доступних готелів :(",
        detailsBtn: "Детальніше / Забронювати",
        favBtn: "❤️ В обране",
        favAdded: "❤️ Додано",

        // Вхід
        loginTitle: "Вхід",
        emailLabel: "Email адреса",
        passLabel: "Пароль",
        loginBtn: "Увійти",
        noAccount: "Немає акаунту?",
        registerLink: "Зареєструватися",

        // Реєстрація
        regTitle: "Створити акаунт",
        firstName: "Ім'я",
        lastName: "Прізвище",
        phoneLabel: "Номер телефону",
        dobLabel: "Дата народження",
        regBtn: "Зареєструватися",
        haveAccount: "Вже є акаунт?",

        // Профіль
        profileTitle: "Особистий кабінет",
        editProfile: "Редагувати профіль",
        historyTitle: "Історія бронювань",
        confirmed: "Підтверджено",
        cancelled: "Скасовано",
        cancelBtn: "Скасувати бронь",

        // Готель
        aboutHotel: "Про готель",
        hotelDesc1: "Цей розкішний готель розташований у самому центрі міста. До послуг гостей спа-центр, критий басейн та ресторан високої кухні.",
        hotelDesc2: "Ідеальне місце для відпочинку або ділової поїздки.",
        availRooms: "Доступні номери",
        standRoom: "Стандартний номер",
        cap2: "Вмістимість: 2 гостя",
        luxRoom: "Люкс з видом на місто",
        cap3: "Вмістимість: 3 гостя",
        bookBtn: "Забронювати",
        priceNight: "/ ніч",

        // Бронювання
        backHotels: "Назад до готелів",
        bookTitle: "Оформлення бронювання",
        bookDesc: "Будь ласка, оберіть дати вашого візиту",
        dateFrom: "Дата заїзду",
        dateTo: "Дата виїзду",
        priceLabel: "Ціна за ніч",
        totalLabel: "До сплати на місці:",
        notCalc: "Поки не розраховано",
        confirmBook: "Підтвердити бронювання"
    },
    en: {
        // General
        langMenu: "🌍 Language",
        loginLink: "Login",
        logoutLink: "Logout",
        backHome: "Back to Home",
        
        // Home
        searchPlaceholder: "Where are we going?",
        searchBtn: "Search",
        recommendedTitle: "Recommended Hotels",
        loadError: "Loading error. Check if the server is running.",
        noHotels: "No hotels available :(",
        detailsBtn: "Details / Book",
        favBtn: "❤️ Add to favorites",
        favAdded: "❤️ Added",

        // Login
        loginTitle: "Login",
        emailLabel: "Email address",
        passLabel: "Password",
        loginBtn: "Sign in",
        noAccount: "Don't have an account?",
        registerLink: "Register",

        // Register
        regTitle: "Create Account",
        firstName: "First Name",
        lastName: "Last Name",
        phoneLabel: "Phone Number",
        dobLabel: "Date of Birth",
        regBtn: "Register",
        haveAccount: "Already have an account?",

        // Profile
        profileTitle: "My Profile",
        editProfile: "Edit Profile",
        historyTitle: "Booking History",
        confirmed: "Confirmed",
        cancelled: "Cancelled",
        cancelBtn: "Cancel Booking",

        // Hotel
        aboutHotel: "About Hotel",
        hotelDesc1: "This luxury hotel is located in the heart of the city. It features a spa, indoor pool, and fine dining restaurant.",
        hotelDesc2: "Perfect place for leisure or business trips.",
        availRooms: "Available Rooms",
        standRoom: "Standard Room",
        cap2: "Capacity: 2 guests",
        luxRoom: "City View Suite",
        cap3: "Capacity: 3 guests",
        bookBtn: "Book Now",
        priceNight: "/ night",

        // Booking
        backHotels: "Back to Hotels",
        bookTitle: "Complete Booking",
        bookDesc: "Please select your visit dates",
        dateFrom: "Check-in Date",
        dateTo: "Check-out Date",
        priceLabel: "Price per night",
        totalLabel: "Total to pay at property:",
        notCalc: "Not calculated yet",
        confirmBook: "Confirm Booking"
    }
};

function setLanguage(lang) {
    localStorage.setItem('appLang', lang);

    const langMenuBtn = document.getElementById('langDropdown');
    if (langMenuBtn) {
        langMenuBtn.innerText = translations[lang].langMenu;
    }

    const elements = document.querySelectorAll('[data-lang]');
    elements.forEach(el => {
        const key = el.getAttribute('data-lang');
        if (translations[lang][key]) {
            if (el.tagName === 'INPUT') {
                el.placeholder = translations[lang][key];
            } else {
                el.innerText = translations[lang][key];
            }
        }
    });
}

document.addEventListener("DOMContentLoaded", () => {
    const savedLang = localStorage.getItem('appLang') || 'uk';
    setLanguage(savedLang);
});