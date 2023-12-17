var searchedmovie = JSON.parse(localStorage.getItem('wanteddata'));
const movieContainer = document.getElementById('row-search');
console.log(movieContainer);
if (searchedmovie.length>0) {
    searchedmovie.forEach(movie => {
        // Create an element to display each movie



        movieContainer.innerHTML = `<div class="movie">

          <a href="/PageEachMovie?id=${movie.id}">


         <div class="card-body">

           
           ${
            movie.imageURL ?
            `<img class="card-img-top"  
                src = "../../uploads/images/${movie.imageURL}"

                alt="${movie.title}" />`
            :
            `<img class="card-img-top"  
              src="https://fakeimg.pl/300x300/?text=}${movie.title}"

                alt="${movie.title}" />`
            
           }
           
          

          
          
           <div class="movie-details">
            <h2 class="card-title ">${movie.title}</h2>

        </div>
        <span class="movie-quality-span">HD</span>

        <i class=" fa-solid fa-circle-play"></i>




           </div >

         </a >
        </div >
        `;
      
    });
}
else {
    movieContainer.innerHTML = "";
    // Display a message if no results are found
    var noResultsMessage = document.createElement("div");
    noResultsMessage.textContent = "No results found.";
    movieContainer.appendChild(noResultsMessage);
}