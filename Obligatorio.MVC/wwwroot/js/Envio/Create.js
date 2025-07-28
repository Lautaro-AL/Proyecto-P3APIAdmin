document.querySelector("#Dto_tipoEnvio").addEventListener('change', CambioDeEnvio)
CambioDeEnvio();
function CambioDeEnvio() {

    let slcValue = document.querySelector("#Dto_tipoEnvio").value;

    if (slcValue == "urgente") {
        document.querySelector("#tipoComun").style.display = "none";
        document.querySelector("#tipoUrgente").style.display = "block";

    } else {
        document.querySelector("#tipoComun").style.display = "block";
        document.querySelector("#tipoUrgente").style.display = "none";
    }

}