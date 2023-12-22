window.MensajeAlertaConfirmacion = function (dotnetHelper, id) {
    Swal.fire({
        title: "¿Está seguro de eliminar la tarea?",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Aceptar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            dotnetHelper.invokeMethodAsync("EliminarTarea", id);
        }
    })
}


window.ToastAlert = function (icon, mensaje) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    });

    Toast.fire({
        icon: icon,
        title: mensaje,
    });
}

