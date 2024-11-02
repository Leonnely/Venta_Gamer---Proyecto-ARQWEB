<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalGeneral.ascx.cs" Inherits="GUI.WebForms.Models.ModalGeneral" %>

<style>
    /* Aquí van los estilos del modal */
    .modal {
        display: none;
        position: fixed;
        z-index: 1;
        padding-top: 100px;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgba(0, 0, 0, 0.4);
    }

    .modal-content {
        background-color: #fefefe;
        margin: auto;
        padding: 20px;
        border: 1px solid #888;
        width: 80%;
    }

    .close {
        color: #aaa;
        float: right;
        font-size: 28px;
        font-weight: bold;
    }

    .close:hover,
    .close:focus {
        color: black;
        text-decoration: none;
        cursor: pointer;
    }
</style>

<div id="miModal" runat="server" class="modal">
    <div class="modal-content">
        <span class="close">&times;</span>
        <h2><asp:Label ID="lblTitle" runat="server" Text="Título del Modal"></asp:Label></h2>
        <p><asp:Label ID="lblContent" runat="server" Text="Contenido del modal"></asp:Label></p>
        <div>
            <button type="button" onclick="btnYesClick()">Sí</button>
            <button type="button" onclick="btnNoClick()">No</button>
        </div>

    </div>
</div>

<script>
    function abrirModal(titulo, contenido) {
        var modal = document.getElementById("<%= miModal.ClientID %>"); // Asegura que sea el ID único generado por ASP.NET
        var lblTitle = document.getElementById("<%= lblTitle.ClientID %>");
        var lblContent = document.getElementById("<%= lblContent.ClientID %>");
        var span = document.getElementsByClassName("close")[0];

        if (modal && lblTitle && lblContent) {
            lblTitle.innerText = titulo;
            lblContent.innerText = contenido;
            modal.style.display = "block";

            // Evento para cerrar el modal al hacer clic en el botón de cierre
            span.onclick = function () {
                modal.style.display = "none";
            }

            // Evento para cerrar el modal al hacer clic fuera de él
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }
        } else {
            console.error("No se pudo encontrar el modal o sus elementos internos.");
        }
    }

    span.onclick = function () {
        modal.style.display = "none";
    }

    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

    function btnYesClick() {
        // Lógica de JavaScript para el botón Sí
    }

    function btnNoClick() {
        // Lógica de JavaScript para el botón No
    }
</script>
