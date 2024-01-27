const input = document.getElementById("search-input");
const movieContainer = document.getElementById("row");
const inputbtn = document.getElementById("search-button");
if (inputbtn !== null) {
    inputbtn.addEventListener("click", SearchData);
}

function SearchData() {

    if (input.value.length >= 3) {
        window.location.href = `/Search/SearchResults?p=${input.value}`;
    }
  

};

