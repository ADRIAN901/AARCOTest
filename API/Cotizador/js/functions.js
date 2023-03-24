function error(mensaje) {

    swal({
        title: "Ups!",
        text: mensaje,
        type: "error",
        showCancelButton: false,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: ""
    });

}