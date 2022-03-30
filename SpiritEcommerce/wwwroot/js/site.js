// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById("more").addEventListener("click", (e) => {
    document.querySelector(".nav-bar2").style.display = "block";
    document.getElementById("nav-link-wrapper").style.display = "flex";
    document.getElementById("more").style.display = "none";
    document.getElementById("nav-link-wrapper").style.flexDirection = "column";
});