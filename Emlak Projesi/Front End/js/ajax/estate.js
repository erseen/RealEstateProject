function AddRealEstate() {
    // FormData nesnesini oluştur
    var formData = new FormData(document.getElementById('realEstateForm'));


    // AJAX isteğini gönder
    $.ajax({
        url: 'https://localhost:7233/api/RealEstate',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (data) {
            window.alert("Başarıyla eklendi")
            location.reload();
        },
        error: function (error) {
            console.error('Error:', error);
        }
    });
}



