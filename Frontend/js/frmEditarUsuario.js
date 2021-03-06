﻿window.addEventListener('load', function () {
    var button = document.getElementById('content_btnEditar');
    button.addEventListener('click', function (event) {
        var txtNombre = document.getElementById('content_txtNombre');
        var txtPaterno = document.getElementById('content_txtPaterno');
        var txtMaterno = document.getElementById('content_txtMaterno');
        var txtCorreo = document.getElementById('content_txtCorreo');

        try {
            txtNombre.classList.remove('is-valid', 'is-invalid');
            txtPaterno.classList.remove('is-valid', 'is-invalid');
            txtMaterno.classList.remove('is-valid', 'is-invalid');
            txtCorreo.classList.remove('is-valid', 'is-invalid');

            var nombre = txtNombre.value.trim();
            var paterno = txtPaterno.value.trim();
            var materno = txtMaterno.value.trim();
            var correo = txtCorreo.value.trim();

            var v2 = validateName(nombre) && nombre != "" ? true : false;
            var v3 = validateName(paterno) && paterno != "" ? true : false;
            var v4 = validateEmail(correo) && correo != "" ? true : false;
            var v8 = validateName(materno) || materno == "" ? true : false;

            if (!(v2 && v3 && v4)) {
                if (v2) {
                    txtNombre.classList.add('is-valid');
                } else {
                    txtNombre.classList.add('is-invalid');
                }
                if (v3) {
                    txtPaterno.classList.add('is-valid');
                } else {
                    txtPaterno.classList.add('is-invalid');
                }
                if (v4) {
                    txtCorreo.classList.add('is-valid');
                } else {
                    txtCorreo.classList.add('is-invalid');
                }
                if (v8) {
                    txtMaterno.classList.add('is-valid');
                } else {
                    txtMaterno.classList.add('is-invalid');
                }
                event.preventDefault();
            }

        } catch (e) {
            event.preventDefault();
        }
    });
});