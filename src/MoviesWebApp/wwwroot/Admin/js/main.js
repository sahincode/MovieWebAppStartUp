const deleteForm = document.querySelectorAll('.btn-delete');
console.log(deleteForm);
deleteForm.forEach(df => {
    const urlDelete = df.getAttribute('action');
    console.log(urlDelete);
    df.addEventListener('submit', function (e) {
        e.preventDefault();
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Yes, delete it!"
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(`/admin/adminabout/Index?handler=OnPostDelete&id=18`, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },

                }).then(response => {
                    if (response.status == 200) {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Your Entity has been deleted.",
                            icon: "success"
                        });
                    }
                    else {
                        Swal.fire({
                            title: "Something went wrong!",
                            text: "Please try again.",
                            icon: "error"
                        });
                    }
                })

            }
        });

    })
})
