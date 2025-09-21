document.addEventListener("DOMContentLoaded", async () => {
    const homeBtn = document.getElementById("home-btn");
    if (homeBtn) {
        homeBtn.addEventListener("click", async () => {
            await loadContacts();
        });
    }

    await loadContacts();
});


async function loadPartial(url) {
    const resp = await fetch(url);
    if (!resp.ok) {
        throw new Error(`Failed to load ${url}`);
    }
    return resp.text();
}

// Load contact list view
async function loadContacts() {
    try {
        document.getElementById("app-content").innerHTML = await loadPartial("/contact/list-view");
        bindContactListEvents();
    } catch (err) {
        console.error(err);
        document.getElementById("app-content").innerHTML = `<p class="error">Could not load contacts.</p>`;
    }
}

function bindContactListEvents() {
    const newBtn = document.getElementById("new-btn");
    if (newBtn) {
        newBtn.addEventListener("click", async () => {
            const res = await fetch("/contact/create-view");
            document.getElementById("app-content").innerHTML = await res.text();
            bindContactFormEvents();
        });
    }
    
    document.querySelectorAll(".details-btn").forEach(btn => {
        btn.addEventListener("click", async (e) => {
            const id = e.target.getAttribute("data-id");
            if (!id) return;

            const isLoggedIn = await checkLoginStatus();
            if (!isLoggedIn) {
                loadLogin();
            } else {
                loadContactDetail(id);
            }
        });
    });

    const categoryFilter = document.getElementById("categoryFilter");
    if (categoryFilter) {
        categoryFilter.addEventListener("change", async (e) => {
            const selected = e.target.value;
            const url = selected ? `/contact/list-view?categoryId=${selected}` : "/contact/list-view";
            try {
                document.getElementById("app-content").innerHTML = await loadPartial(url);
                bindContactListEvents();
            } catch (err) {
                console.error(err);
            }
        });
    }
}

// Load detail view
async function loadContactDetail(id) {
    try {
        document.getElementById("app-content").innerHTML = await loadPartial(`/contact/detail-view/${id}`);
        
        const deleteBtn = document.getElementById("delete-btn");
        const editBtn = document.getElementById("edit-btn");
        const backBtn = document.getElementById("back-btn");
        const contactDetail = document.getElementById("contact-detail");
        if(backBtn){
            backBtn.addEventListener("click", () => {
                loadContacts();
            });
        }
        if (editBtn) {
            editBtn.addEventListener("click", async () => {
                const id = contactDetail.dataset.id;
                const res = await fetch(`/contact/edit-view/${id}`);
                document.getElementById("app-content").innerHTML = await res.text();
                bindContactFormEvents();
            });
        }
        if (deleteBtn) {
            deleteBtn.addEventListener("click", async () => {
                const id = contactDetail.dataset.id;
                if (confirm("Are you sure you want to delete this contact?")) {
                    await fetch(`/contact/delete/${id}`, { method: "POST" });
                    await loadContacts(); // reload after delete
                }
            });
        }
    } catch (err) {
        console.error(err);
        document.getElementById("app-content").innerHTML = `<p class="error">Could not load contact detail.</p>`;
    }
}

// Load login form partial
async function loadLogin() {
    try {
        document.getElementById("app-content").innerHTML = await loadPartial("/auth/login");
        bindLoginEvents();
    } catch (err) {
        console.error(err);
        document.getElementById("app-content").innerHTML = `<p class="error">Could not load login.</p>`;
    }
}

function bindLoginEvents() {
    document.getElementById("login-form")?.addEventListener("submit", async (e) => {
        e.preventDefault();
        const email = document.getElementById("login-email").value;
        const password = document.getElementById("login-password").value;

        const resp = await fetch("/auth/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password })
        });

        if (resp.ok) {
            await loadContacts();
        } else {
            const errJson = await resp.json();
            displayAuthError(errJson.message || "Login failed");
        }
    });

    document.getElementById("go-register")?.addEventListener("click", () => {
        loadRegister();
    });
}

// Load register form partial
async function loadRegister() {
    try {
        document.getElementById("app-content").innerHTML = await loadPartial("/auth/register");
        bindRegisterEvents();
    } catch (err) {
        console.error(err);
        document.getElementById("app-content").innerHTML = `<p class="error">Could not load register.</p>`;
    }
}

function bindRegisterEvents() {
    document.getElementById("register-form")?.addEventListener("submit", async (e) => {
        e.preventDefault();
        const email = document.getElementById("register-email").value;
        const password = document.getElementById("register-password").value;
        const repeat = document.getElementById("register-repeat-password").value;

        if (password !== repeat) {
            displayAuthError("Passwords do not match");
            return;
        }

        const resp = await fetch("/auth/register", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password })
        });

        if (resp.ok) {
            // after register => show contacts
            await loadContacts();
        } else {
            const errJson = await resp.json();
            displayAuthError(errJson.message || "Register failed");
        }
    });

    document.getElementById("go-login")?.addEventListener("click", () => {
        loadLogin();
    });
}

function bindContactFormEvents() {
    const form = document.querySelector("form[data-contact-form]");
    if (!form) return;

    document.querySelector("select[name='CategoryId']")
        .addEventListener("change", function() {
            const otherInput = document.querySelector("input[name='CategoryName']");
            if (this.value === "00000000-0000-0000-0000-000000000000") {
                otherInput.disabled = false;
            } else {
                otherInput.disabled = true;
                otherInput.value = "";
            }
        });
    
    form.addEventListener("submit", async (e) => {
        e.preventDefault();

        const formData = new FormData(form);
        const json = Object.fromEntries(formData.entries());

        const method = form.dataset.method; // "create" or "edit"
        let url = "/contact/create";
        if (method === "edit") {
            const id = form.dataset.id;
            url = `/contact/edit/${id}`;
        }

        const resp = await fetch(url, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(json)
        });

        if (resp.ok) {
            await loadContacts();
        } else {
            const err = await resp.json();
            alert(err.message || "Save failed");
        }
    });

    // Enable "Other category" input
    const categorySelect = document.querySelector("select[name='SelectedCategoryId']");
    const otherInput = document.querySelector("input[name='OtherCategoryName']");
    if (categorySelect && otherInput) {
        categorySelect.addEventListener("change", () => {
            if (!categorySelect.value) {
                otherInput.disabled = false;
            } else {
                otherInput.disabled = true;
                otherInput.value = "";
            }
        });
    }
}

function displayAuthError(msg) {
    const errElem = document.getElementById("auth-error");
    if (errElem) {
        errElem.innerText = msg;
    } else {
        alert(msg);
    }
}

async function checkLoginStatus() {
    const res = await fetch('/auth/is-logged-in');
    const data = await res.json();
    return data.isLoggedIn;
}
