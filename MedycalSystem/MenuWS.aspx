<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuWS.aspx.cs" Inherits="MedycalSystem.MenuWS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MedicalSystem</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet"/>
    <link href="Content/sidebar.css" rel="stylesheet"/>

    <script src="Scripts/umd/popper.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="wrapper">
            <div id="sidebar-wrapper">
                <h2>Medical System</h2>
                <ul class="sidebar-nav">
                    <li>
                        <a href="#">Registro Clientes</a>
                    </li>
                    <li>
                        <a href="javascript:ListarProductos()">Productos</a>
                    </li>
                    <li>
                        <a href="#">Pedidos</a>
                    </li>
                </ul>                    
            </div> 
       </div>
    </form>


    <div class="modal-body">
        <form>
            <table class="table table-dark">
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
        </form>
    </div>

    <script type="text/javascript">
        /*function listarProductos() {
            ListarProductos();
            console.log("PROBANDO2");
        }*/
        
        $(function () {
            console.log("gaaaaaaaaa");
            ListarProductos();        
        });

        function ListarProductos() {
            $.ajax({
                method: "POST",
                url: "http://localhost:44355/wsFarmacia.asmx/ListarProductos",
                type: "json",
                contentType: "application/json; charset=utf-8",
                success: function (resp) {
                    console.log("entro");   
                    console.log(resp);
                    $("#tbCuerpo").empty();

                    $.each(resp.d, function (p, d) {
                        console.log(d);
                        $("#tbCuerpo").append(
                            "<tr>" +
                            "<th scope='row'>" + d.IdProducto + "</th>" +
                            "<td>" + d.Nombre + "</td>" +
                            "<td>" + d.Precio + "</td>" +
                            "<td>" + d.Stock + "</td>" +
                            "</tr>"
                        );

                    });
                   // $(".btnActualizar").click(function (e) {
                  //      $('#actualizar').modal('show');
                  //  });
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
        }
    </script>

</body>

</html>
