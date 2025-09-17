document.addEventListener("DOMContentLoaded", () => {
    const content = document.getElementById("content");
    const loginBtn = document.getElementById("login-btn");
    const registerBtn = document.getElementById("register-btn");

    // -----------------------------
    // Load Login Partial
    // -----------------------------
    async function loadLogin() {
        const res = await fetch("/auth/login");
        content.innerHTML = await res.text();
        bindLoginEvents();
    }

    function bindLoginEvents() {
        document.getElementById("login-form").addEventListener("submit", async e => {
            e.preventDefault();
            const email = document.getElementById("login-email").value;
            const password = document.getElementById("login-password").value;

            const res = await fetch("/auth/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ email, password })
            });

            if (res.ok) {
                loadContacts(); // after login, load contact list
            } else {
                alert("Login failed");
            }
        });

        document.getElementById("go-register").addEventListener("click", loadRegister);
    }

    // -----------------------------
    // Load Register Partial
    // -----------------------------
    async function loadRegister() {
        const res = await fetch("/auth/register");
        content.innerHTML = await res.text();
        bindRegisterEvents();
    }

    function bindRegisterEvents() {
        document.getElementById("register-form").addEventListener("submit", async e => {
            e.preventDefault();
            const email = document.getElementById("register-email").value;
            const password = document.getElementById("register-password").value;
            const repeat = document.getElementById("register-repeat-password").value;

            if (password !== repeat) {
                alert("Passwords do not match");
                return;
            }

            const res = await fetch("/auth/register", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ email, password })
            });

            if (res.ok) {
                loadContacts();
            } else {
                alert("Register failed");
            }
        });

        document.getElementById("go-login").addEventListener("click", loadLogin);
    }

    // -----------------------------
    // Load Contact List Placeholder
    // -----------------------------
    async function loadContacts() {
        const res = await fetch("/contacts");
        if (res.ok) {
            content.innerHTML = await res.text();
        }
    }

    // -----------------------------
    // Initial button bindings
    // -----------------------------
    loginBtn.addEventListener("click", loadLogin);
    registerBtn.addEventListener("click", loadRegister);
});
