    <%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="frmProductos.aspx.cs" Inherits="MedycalSystem.frmProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/umd/popper.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <link href="Content/sidebar.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="contenido">
        <h3>LISTA DE PRODUCTOS</h3>
        <label>Buscar Producto: </label>
        <input id="txtBuscar" type="text" placeholder="Nombre del producto" />

        <table id="tablaProducto" class="table table-active">
            <thead>
                <tr>
                    <th scope="col">ID PRODUCTO</th>
                    <th scope="col">NOMBRE</th>
                    <th scope="col">PRECIO</th>
                    <th scope="col">STOCK</th>
                </tr>
            </thead>
            <tbody id="tbCuerpo"></tbody>
        </table>


        <label>Carrito de Compras</label>
        <table id="tablaCarrito" class="table table-dark">
            <thead>
                <tr>
                    <th scope="col">Codigo</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Precio Unitario</th>
                    <th scope="col">Cantidad</th>
                    <th scope="col">Total</th>
                </tr>
            </thead>
            <tbody id="tbCarrito"></tbody>
        </table>
        <label>Total:</label>
        <input type="text" />
        <button type="button" class="btn btn-danger">Quitar</button>
        <button type="button" onclick="javascript:registrarPedido()"class="obtener btn btn-dark">Registrar Pedido</button>
    </div>


     <script type="text/javascript">

         $(function () {
             $.ajax({
                 method: "POST",
                 url: "https://localhost:44355/wsFarmacia.asmx/ListarProductos",
                 type: "json",
                 contentType: "application/json; charset=utf-8",
                 success: function (resp) {
                     console.log(resp);
                     $("#tbCuerpo").empty();

                     $.each(resp.d, function (p, d) {
                         //console.log(d);
                         $("#tbCuerpo").append(
                             '<tr>' +
                             "<td scope='row'>" + d.IdProducto + "</td>" +
                             "<td>" + d.Nombre + "</td>" +
                             "<td>" + d.Precio + "</td>" +
                             "<td>" + d.Stock + "</td>" +
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
                         $('#tablaProducto tbody tr').each(function () {
                             $(this).removeClass('ocultar');
                             contenidoFila = $(this).find('td:eq(1)').html();
                             var exp = new RegExp(cadena, 'gi');
                             coincidencias = contenidoFila.match(exp);
                             if (coincidencias == null) {
                                 $(this).addClass('ocultar');
                             }
                         });
                     }

                     $("body").on("click", "#tablaProducto tr", function () {

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

                     /*var data = function (tbody, table) {
                         $(tbody).on("click", ".obtener", function () {
                             var data2 = table.row($(this).parents("tr")).data();

                             //console.log(data2);
                         });
                         //table.row().data();
                     }*/
                 },
                 error: function (jqXHR, textStatus, errorThrown) {
                     console.log(errorThrown);
                 }
             })
         })

        /* function jalar() {
             console.log("gaa");
             //console.log($('#tablaCarrito tbody').row().data());

             /*var data = function (tbody, table) {
                 $(tbody).on("click", ".obtener", function () {
                     var data2 = table.row().data();
                     
                     console.log(data2);
                 });
                 //table.row().data();
             }*/
             //console.log($("#tablaCarrito tbody tr").val("dsad"));
         //}
         function registrarPedido() {
             var data = {
                 objDetalle: {
                     PedidoID: "O0006",
                     ProductoID: "P0012",
                     Cantidad: 2
                 }
             };

             $.ajax({
                 method: "POST",
                 url: "https://localhost:44355/wsFarmacia.asmx/GuardarPedido",
                 data: JSON.stringify(data),
                 type: "JSON",                
                 contentType: "application/json; charset=utf-8",
                 success: function (e) {
                     alert("Se ha registrado con éxito tu producto");
                 },
                 error: function (jqXHR, textStatus, errorThrown) {
                     console.log(errorThrown);
                 }
             });
         }

         /*window.onload = function () {

             creamos los eventos para cada elemento con la clase "boton"
             let elementos = document.getElementsByClassName("obtener");
             console.log(elementos[0]);
                 elementos[0].addEventListener("click", obtenerValores);
         }

          funcion que se ejecuta cada vez que se hace clic
         function obtenerValores(e) {
             console.log(e);
             var valores = "";

              vamos al elemento padre (<tr>) y buscamos todos los elementos <td>
              que contenga el elemento padre
             var elementosTD = e.srcElement.parentElement.getElementsByTagName('td');

             // recorremos cada uno de los elementos del array de elementos <td>
            /for (let i = 0; i < elementosTD.length; i++) {

                  obtenemos cada uno de los valores y los ponemos en la variable "valores"
                 valores += elementosTD[i].innerHTML + "\n";
             }

             console.log(elementosTD[5].innerHTML);
         }*/

    </script>

</asp:Content>
