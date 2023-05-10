// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const toggle = document.getElementById('toggleDark');
const body = document.querySelector('body');
const theme = localStorage.getItem("theme")



toggle.addEventListener('click', function () {
    this.classList.toggle('bi-moon');
    if (this.classList.toggle('bi-brightness-high-fill')) {
        body.style.background = 'white';
        body.style.color = 'black';
        body.style.transition = '2s';
        localStorage.setItem("theme","white")
    } else {
        body.style.background = 'black';
        body.style.color = 'white';
        body.style.transition = '2s';
        localStorage.setItem("theme","black")
    }
});