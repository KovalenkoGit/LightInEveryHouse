<script>
    $(function () {
        $("#addressFilter").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '@Url.Action("GetAddressSuggestions", "Schedule")',
                    data: { term: request.term },
                    dataType: 'json',
                    success: function (data) {
                        console.log("Received data:", data); // Перевіряємо отримані дані
                        response(data); //Передаємо масив рядків
                    },
                    error: function (xhr, status, error) {
                        console.error("AJAX Error:", status, error); // Обробка помилок
                    }
                });
            },
            minLength: 2 // Починає показувати пропозиції після введення 2 і більше символів
        });
    });
</script>