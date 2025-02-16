document.addEventListener("DOMContentLoaded", function () {
    const input = document.getElementById("selectedDevices");
    const dropdown = document.getElementById("deviceOptions");
    const tagContainer = document.getElementById("selectedTags");

    input.addEventListener("focus", function () {
        dropdown.classList.add("show"); // Show dropdown on focus
    });

    dropdown.addEventListener("click", function (event) {
        if (event.target.classList.contains("dropdown-item")) {
            const value = event.target.getAttribute("data-value");

            // Check if tag already exists
            if (!document.querySelector(`#selectedTags span[data-value="${value}"]`)) {
                const tag = document.createElement("span");
                tag.classList.add("badge", "bg-primary", "me-2", "p-2");
                tag.setAttribute("data-value", value);
                tag.innerHTML = `${value} <span class="ms-2" style="cursor:pointer;">&times;</span>`;

                tag.querySelector("span").addEventListener("click", function () {
                    tag.remove();
                });

                tagContainer.appendChild(tag);
            }
        }
    });

    document.addEventListener("click", function (event) {
        if (!input.contains(event.target) && !dropdown.contains(event.target)) {
            dropdown.classList.remove("show"); // Hide dropdown when clicking outside
        }
    });
});
