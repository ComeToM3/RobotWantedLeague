document.addEventListener("DOMContentLoaded", function () {
    const toggleDetailsLinks = document.querySelectorAll(".toggle-details");

    toggleDetailsLinks.forEach(function (link) {
        link.addEventListener("click", function (e) {
            e.preventDefault();
            
            // Récupère tous les éléments de détails (divs) sauf celui qui a été cliqué
            const allDetailsDivs = document.querySelectorAll(".hidden");
            const clickedDetailsDiv = link.nextElementSibling;

            // Masque tous les éléments de détails
            allDetailsDivs.forEach(function (div) {
                if (div !== clickedDetailsDiv) {
                    div.style.display = "none";
                }
            });

            // Affiche ou masque les détails du robot associé au lien cliqué
            clickedDetailsDiv.style.display = (clickedDetailsDiv.style.display === "block") ? "none" : "block";
        });
    });
});


$(document).ready(function () {
    $('#searchInput').on('input', function () {
        let searchText = $(this).val().toLowerCase();
        $('.list-group-item').each(function () {
            let itemText = $(this).text().toLowerCase(); // Texte complet de l'élément
            if (itemText.indexOf(searchText) !== -1) {
                $(this).show(); // Affiche les éléments qui correspondent
            } 
        });
    });
});


