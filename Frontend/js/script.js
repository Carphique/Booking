async function addFavorite(hotelId, btn) {
    const userId = localStorage.getItem("userId");
    const token = localStorage.getItem("jwtToken");

    if (!userId || !token) {
        alert("Спочатку увійдіть!");
        return;
    }
    try {
        const res = await fetch(FAV_URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}` // <-- Відправляємо токен
            },
            body: JSON.stringify({ userId: userId, hotelId: hotelId })
        });

        if (res.ok) {
            btn.innerText = "❤️ Додано";
            btn.classList.replace("btn-outline-danger", "btn-danger");
        } else {
            alert("Помилка авторизації (можливо час дії токена вийшов)");
        }
    } catch (e) {
        console.error(e);
    }
}