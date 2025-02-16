$(document).ready(function () {
    $('#Cover').on('change', function () {
        let file = this.files[0]; // Get the selected file
        if (file) {
            let imgURL = URL.createObjectURL(file); // Create a temporary URL
            $('.cover-preview').attr('src', imgURL).show(); // Set src and show image
        }
    });
});
