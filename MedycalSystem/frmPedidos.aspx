<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmPedidos.aspx.cs" Inherits="MedycalSystem.Pedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/umd/popper.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <link href="Content/sidebar.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="contenido">
        <h3>LISTA DE PEDIDOS</h3>
        <label>Buscar por DNI: </label>
        <input id="txtBuscar" type="text" placeholder="DNI" />

        <table id="tabla" class="table table-active">
            <thead>
                <tr>
                    <th scope="col">DNI</th>
                    <th scope="col">APELLIDO PATERNO</th>
                    <th scope="col">APELLIDO MATERNO</th>
                    <th scope="col">MONTO A PAGAR</th>
                    <th scope="col">ESTADO</th>
                </tr>
            </thead>
            <tbody id="tbCuerpo"></tbody>
        </table>



        <button type="button" class="btn btn-primary">DESPACHAR</button>
        <button type="button" onclick="javascript:pagarPedido()"class="btn btn-success">REGISTRAR VENTA</button>
    </div>

    <script type="text/javascript">

         $(function () {
             console.log("pedidos :c");
             $.ajax({
                 method: "POST",
                 url: "https://localhost:44355/wsFarmacia.asmx/ListarPedidos",
                 type: "json",
                 contentType: "application/json; charset=utf-8",
                 success: function (resp) {
                     console.log(resp);
                     $("#tbCuerpo").empty();

                     $.each(resp.d, function (p, d) {
                         console.log(d);
                         $("#tbCuerpo").append(
                             '<tr>' +
                             "<td scope='row'>" + d.dni + "</td>" +
                             "<td>" + d.apellidop + "</td>" +
                             "<td>" + d.apellidom + "</td>" +
                             "<td>" + "Monto" + "</td>" +
                             "<td>" + d.Estado + "</td>" +
                             "</tr>"
                         );
                     });

                     var contenidoFila, coincidencias;
                     $('#txtBuscar').keyup(function () {                      
                         if ($(this).val().length >= 0) {                            
                             filtrarBusqueda($(this).val());
                         }
                     });

                     function filtrarBusqueda(cadena) {
                         $('#tabla tbody tr').each(function () {
                             $(this).removeClass('ocultar');
                             contenidoFila = $(this).find('td:eq(0)').html();
                             var exp = new RegExp(cadena, 'gi');
                             coincidencias = contenidoFila.match(exp);
                             if (coincidencias == null) {
                                 $(this).addClass('ocultar');
                             }
                         });
                     }


                     $("body").on("click", "#tabla tr", function () {

                         var id = $(this).find('td:eq(0)').html();
                         var nombre = $(this).find('td:eq(1)').html();
                         var precio = $(this).find('td:eq(2)').html();

                         $("#tbCarrito").append(
                             "<tr>" +
                             "<th scope='row'>" + id + "</th>" +
                             "<td>" + nombre + "</td>" +
                             "<td>" + precio + "</td>" +
                             "<td>" + 12 + "</td>" +
                             "<td>" + 12 + "</td>" +
                             "</tr>"
                         );
                     });

                     function pagarPedido() {

                     }

                     function despacharPedido(){

                     }
                 },
                 error: function (jqXHR, textStatus, errorThrown) {
                     console.log(errorThrown);
                 }
             })
         });

    </script>
</asp:Content>
