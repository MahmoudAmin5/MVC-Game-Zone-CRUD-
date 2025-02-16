<script>
    $(document).ready(function () {
        console.log("Document Ready!");  // Debugging
    console.log(typeof $.fn.select2); // Check if Select2 is loaded

    $('.select2').select2({
        placeholder: "Select an option",
    allowClear: true,
    width: '100%',
    theme: 'bootstrap-5'
            });
        });
</script>