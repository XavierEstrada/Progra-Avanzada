$(document).ready(function () {
    $(document).on("click", ".btn-eliminar", function () {
        var id = $(this).data("id");

        if (confirm("¿Estás seguro de que deseas eliminar esta película?")) {
            $.ajax({
                type: "POST",
                url: '@Url.Action("EliminarPelicula", "Pelicula")',
                data: { id: id },
                success: function (response) {
                    if (response.success) {
                        alert("Película eliminada con éxito.");
                        location.reload(); // Recarga la página para reflejar los cambios
                    } else {
                        alert(response.message || "Error al eliminar la película.");
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error:", xhr.responseText);
                    alert("Ocurrió un error al procesar la solicitud.");
                }
            });
        }
    });
});
