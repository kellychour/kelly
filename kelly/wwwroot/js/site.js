// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const buttons = document.querySelectorAll("[data-carousel-button]");

buttons.forEach(button => {
    button.addEventListener("click", () => {
        const offset = button.dataset.carouselButton === "next" ? 1 : -1;
        const slides = button.closest("[data-carousel]").querySelector("[data-slides]");
        const activeSlide = slides.querySelector("[data-active]");
        let newIndex = [...slides.children].indexOf(activeSlide) + offset;
        if (newIndex < 0) newIndex = slides.children.length - 1;
        if (newIndex >= slides.children.length) newIndex = 0;

        slides.children[newIndex].dataset.active = true;
        delete activeSlide.dataset.active;
    });
});

const nextButton = document.querySelector(".carousel-button-next");
function nextSlide() {
    nextButton.click();
}

// Automatically advance to the next slide every 3 seconds
setInterval(nextSlide, 3000);

// banh mi dropdown box
const checkboxes = document.querySelectorAll('input[type="checkbox"]');
const toggleButtons = document.querySelectorAll('.dropdown-toggle');
const dropdownMenus = document.querySelectorAll('.dropdown-menu');

checkboxes.forEach((checkbox) => {
    checkbox.addEventListener('change', (event) => {
        const checkedCount = document.querySelectorAll(
            'input[type="checkbox"]:checked'
        ).length;

        const parentBox = event.target.closest('.box');
        const boxTitle = parentBox.querySelector('h3').textContent;

        if (boxTitle === 'Choose 1 half') {
            if (checkedCount > 1) {
                event.target.checked = false;
            }
        } else if (boxTitle === 'Choose 2 halves') {
            if (checkedCount > 2) {
                event.target.checked = false;
            }
        }
    });
});

toggleButtons.forEach((toggleButton, index) => {
    toggleButton.addEventListener('click', () => {
        dropdownMenus[index].classList.toggle('show');
    });
});

/*for side nav*/
function openNav() {
    document.getElementById("mySidepanel").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidepanel").style.width = "0";
}

