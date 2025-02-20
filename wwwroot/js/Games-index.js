$(document).on("click", ".js-delete", function () {
    var button = $(this);
    var gameId = button.data("id");

    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#ff4c4c", // Dark Red for delete button
        cancelButtonColor: "#6c757d", // Gray for cancel button
        confirmButtonText: "Yes, delete it!",
        background: "#333", // Dark background
        color: "#fff" // White text
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Games/Delete/" + gameId, // Ensure this matches your controller route
                type: "DELETE", // Use DELETE instead of POST
                success: function () {
                    Swal.fire({
                        title: "Deleted!",
                        text: "Game deleted successfully.",
                        icon: "success",
                        timer: 1500,
                        showConfirmButton: false,
                        background: "#333", // Dark background
                        color: "#fff" // White text
                    });

                    button.closest(".col-md-6").fadeOut(500, function () {
                        $(this).remove(); // Remove the game card from UI
                    });
                },
                error: function (xhr) {
                    console.log(xhr.responseText); // Log error response
                    Swal.fire({
                        title: "Error!",
                        text: "An error occurred while deleting the game.",
                        icon: "error",
                        background: "#333", // Dark background
                        color: "#fff", // White text
                        confirmButtonColor: "#ff4c4c" // Red for error confirmation
                    });
                }
            });
        }
    });
});
