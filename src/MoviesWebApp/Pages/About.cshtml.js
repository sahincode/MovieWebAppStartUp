const inputl = document.getElementById("search-input");
const movieContainer = document.getElementById("row");
const inputbtn = document.getElementById("search-button");
 inputbtn.addEventListener("click", SearchData);

function SearchData() {
    if (inputl.value.length >= 3) {
        
        fetch(`/Logo?handler=GetMovies&input=${inputl.value}`)
            .then(response => response.json())
            .then(data => {

                localStorage.setItem('wanteddata', JSON.stringify(data))
                
                
            }).catch(error => {
                console.error("this error is occured:", error)
            });






    }
    window.location.href = `/Search/SearchResults`;

};

