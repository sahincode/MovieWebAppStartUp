const input = document.getElementById('subscribe-input');
const button = document.getElementById('subscribe-button');

button?.addEventListener('click', function (e) {
    e.preventDefault();
    fetch(`/Home?handler=Subscribe&email=${input.value}`).
        then(response => {
            if (response.status == 200) {

                Swal.fire({
                    position: "bottom-end",
                    icon: "success",
                    title: "Congrats!You Subscribed succesfully",
                    showConfirmButton: false,
                    timer: 1500,

                    heightauto: false,
                });
            }
            else {
                Swal.fire({
                    position: "bottom-end",
                    icon: "error",
                    title: "Something went wrong.Please try again",
                    showConfirmButton: false,
                    timer: 1500
                });

            }
        })


})
//hamburger click action 
const menuBtn = document.querySelector('.hamburger');
const menuDiv = document.querySelectorAll('.nav-mobile');
const body = document.querySelector('.body-layout');
const divOver = document.querySelector('.div-over');



menuBtn?.addEventListener('click', function () {

    menuBtn.classList.toggle('is-active');
    menuDiv.forEach(menu => menu.classList.toggle('active'));

    divOver.classList.toggle('dark-back');

    body.classList.toggle('o-hidden');

})