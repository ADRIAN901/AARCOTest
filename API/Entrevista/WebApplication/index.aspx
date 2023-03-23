<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication.index" %>

<!DOCTYPE html>

<link href="css/bootstrap.css" rel="stylesheet" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row" style="padding:10px">
            <div class="col-lg-6">
                <section id="secVehiculo" style="border:double">                            
                    <div class="row">
                        <div class="col-lg-12">
                            <center><h2>Vehiculo</h2></center>
                        </div>                
                    </div>
                    <div class="row" style="padding:10px">
                        <div class="col-lg-2">
                            Marca: 
                        </div>  
                        <div class="col-lg-10">
                            <asp:DropDownList runat="server" ID="ddlMarca" Width="100%" />
                        </div>                
                    </div>
                    <div class="row" style="padding:12px 10px">
                        <div class="col-lg-2">
                            Submarca: 
                        </div> 
                        <div class="col-lg-10">
                            <asp:DropDownList runat="server" ID="ddlSubmarca" Width="100%" />
                        </div> 
                    </div>
                    <div class="row" style="padding:12px 10px">
                        <div class="col-lg-2">
                            Modelo: 
                        </div>     
                        <div class="col-lg-10">
                            <asp:DropDownList runat="server" ID="ddlModelo" Width="100%" />
                        </div>     
                    </div>
                    <div class="row" style="padding:12px 10px">
                        <div class="col-lg-2">
                            Descripcion:
                        </div>  
                        <div class="col-lg-10">
                            <asp:DropDownList runat="server" ID="ddlDescripcion" Width="100%" />
                        </div>  
                    </div>                        
                </section>
            </div>     
            <div class="col-lg-6">
                <section id="secDomicilio" style="border:double">                            
                    <div class="row">
                        <div class="col-lg-12">
                            <center><h2>Domicilio</h2></center>
                        </div>                
                    </div>
                    <div class="row" style="padding:10px">
                        <div class="col-lg-2">
                            C.P: 
                        </div>     
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="txtCodigoPostal" Width="100%" AutoPostBack="true" OnTextChanged="txtCodigoPostal_TextChanged" MaxLength="5" onkeydown = "return (event.keyCode >= 48 && event.keyCode <= 57)"  />                            
                        </div>     
                    </div>
                    <div class="row" style="padding:10px">
                        <div class="col-lg-2">
                            Estado: 
                        </div>     
                        <div class="col-lg-10">
                            <input runat="server" type="text" id="txtEstado" placeholder="Estado" required style="width:100%;" disabled="disabled" >
                        </div>     
                    </div>
                    <div class="row" style="padding:10px">
                        <div class="col-lg-2">
                            Municipio: 
                        </div>     
                        <div class="col-lg-10">
                            <input runat="server" type="text" id="txtMunicipio" placeholder="Municipio" required style="width:100%;" disabled="disabled" >
                        </div>     
                    </div>
                    <div class="row" style="padding:10px">
                        <div class="col-lg-2">
                            Colonia: 
                        </div>       
                        <div class="col-lg-10">
                            <asp:DropDownList runat="server" ID="ddlColonia" Width="100%"  />
                        </div>       
                    </div>                        
                </section>
            </div>     
        </div>
        
        <div class="row" style="padding:10px">
            <div class="col-lg-12">                                     
                <section id="secCotizacion" style="border:double">                            
                    <div class="row">
                        <div class="col-lg-12">
                            <center><h2>Cotizacion</h2></center>
                        </div>                
                    </div>

                    <div class="row">
                        <div class="col-lg-1">
                            &nbsp;
                        </div>
                        <div class="col-lg-2">
                            <div class="row">
                                <img src="img/AXA.png" class="img-fluid" />                                
                            </div>
                            <div class="row">
                                <center><asp:Label runat="server" ID="lblAxa" Text="$0.00" /></center>
                            </div>
                        </div>                
               
                        <div class="col-lg-2">
                            <div class="row">
                                <img src="img/ZURICH.png" />                                
                            </div>
                            <div class="row">
                                <center><asp:Label runat="server" ID="lblZurich" Text="$0.00" /></center>
                            </div>
                        </div>                
               
                        <div class="col-lg-2">
                            <div class="row">
                                <img src="img/HDI.png" />                                
                            </div>
                            <div class="row">
                                <center><asp:Label runat="server" ID="lblHdi" Text="$0.00" /></center>
                            </div>
                        </div>                
               
                        <div class="col-lg-2">
                            <div class="row">
                                <img src="img/CHUBB.png" />                                
                            </div>
                            <div class="row">
                                <center><asp:Label runat="server" ID="lblChubb" Text="$0.00" /></center>
                            </div>
                        </div>     
                        
                        <div class="col-lg-2">
                            <div class="row">
                                <img src="img/QUALITAS.png" />                          
                            </div>
                            <div class="row">
                                <center><asp:Label runat="server" ID="lblQualitas" Text="$0.00" /></center>
                            </div>
                        </div>  
                        <div class="col-lg-1">
                            &nbsp;
                        </div>
                    </div>
                </section>
            </div>
        </div>

    </form>
</body>
</html>
