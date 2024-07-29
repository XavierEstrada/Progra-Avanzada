document.addEventListener('DOMContentLoaded', function () {
    var imageUrlInput = document.getElementById('PosterUrlInput');
    var imagePreview = document.getElementById('imagePreview');

    imageUrlInput.addEventListener('input', function () {
        var imageUrl = this.value;

        var img = new Image();
        img.onload = function () {
            var maxWidth = 200;
            var maxHeight = 200;

            var width = img.width;
            var height = img.height;
            if (width > maxWidth) {
                height *= maxWidth / width;
                width = maxWidth;
            }
            if (height > maxHeight) {
                width *= maxHeight / height;
                height = maxHeight;
            }
            imagePreview.src = imageUrl;
            imagePreview.style.width = width + 'px';
            imagePreview.style.height = height + 'px';
        }
        img.src = imageUrl;
    });
});
