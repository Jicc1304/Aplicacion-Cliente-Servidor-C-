/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicacion Cliente-Servidor.
 * Estudiante:Jose Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */


using LibEntidades;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace AplicacionCliente
{
   /// <summary>
   /// Clase encargada de manejar la conexión TCP con el servidor.
   /// Recibe y envía paquetes, y enruta la lógica hacia los formularios correspondientes.
   /// </summary>
   public static class ConexionTcp
   {
      // Cliente TCP que se conecta al servidor
      private static TcpClient cliente;

      // Flujo de datos asociado al cliente TCP
      private static NetworkStream stream;

      // Buffer de datos para recibir información del servidor
      private static byte[] buffer = new byte[8192];

      // Indica si la conexión está activa
      private static bool conectado = false;

      /// <summary>
      /// Referencia al formulario principal del cliente.
      /// </summary>
      public static FormMenuPrincipal FormMenuPrincipal { get; set; }

      /// <summary>
      /// Obtiene el cliente TCP actual.
      /// </summary>
      public static TcpClient ClienteTcp => cliente;

      // Constructor estático vacío
      static ConexionTcp() { }

      /// <summary>
      /// Establece la conexión con el servidor y lanza el hilo de recepción.
      /// </summary>
      public static void Conectar()
      {
         try
         {
            cliente = new TcpClient("127.0.0.1", 14100);
            stream = cliente.GetStream();
            conectado = true;

            Thread hiloRecepcion = new Thread(RecibirDatos);
            hiloRecepcion.IsBackground = true;
            hiloRecepcion.Start();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
            conectado = false;
         }
      }

      /// <summary>
      /// Envía un paquete serializado al servidor a través del flujo de red.
      /// </summary>
      /// <param name="paquete">El paquete que se enviará al servidor.</param>
      public static void Enviar(Paquete paquete)
      {
         try
         {
            if (!conectado)
               throw new Exception("No hay conexión activa con el servidor.");

            string json = JsonSerializer.Serialize(paquete);
            byte[] datos = Encoding.UTF8.GetBytes(json);
            stream.Write(datos, 0, datos.Length);
            stream.Flush();
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error al enviar datos: " + ex.Message);
         }
      }

      /// <summary>
      /// Hilo encargado de recibir datos del servidor y redirigir los resultados a los formularios correspondientes.
      /// </summary>
      private static void RecibirDatos()
      {
         while (conectado)
         {
            try
            {
               int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
               if (bytesLeidos == 0) continue;

               string jsonRecibido = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
               Paquete paquete = JsonSerializer.Deserialize<Paquete>(jsonRecibido);

               // Procesa el comando recibido desde el servidor
               switch (paquete.Comando)
               {
                  /// <summary>
                  /// Procesa la respuesta tras registrar un tipo de artículo.
                  /// </summary>
                  case "RegistrarTipoArticulo":
                     if (Application.OpenForms["FormTipoArticulo"] is FormTipoArticulo formTA)
                        formTA.Invoke(() => formTA.MostrarRespuesta(paquete.Datos.ToString()));
                     break;

                  /// <summary>
                  /// Procesa la consulta de tipos de artículos (usado por FormArticulo y FormTipoArticulo).
                  /// </summary>
                  case "ConsultarTipoArticulo":
                     var tipoJson = (JsonElement)paquete.Datos;
                     var listaTipos = JsonSerializer.Deserialize<List<TipoArticulo>>(tipoJson.GetRawText());

                     if (Application.OpenForms["FormArticulo"] is FormArticulo formArticulo)
                        formArticulo.Invoke(() => formArticulo.MostrarTiposArticulo(listaTipos));
                     else if (Application.OpenForms["FormTipoArticulo"] is FormTipoArticulo formTipo)
                        formTipo.Invoke(() => formTipo.MostrarTipos(listaTipos));
                     break;

                  /// <summary>
                  /// Procesa la respuesta tras registrar un artículo.
                  /// </summary>
                  case "RRegistrarArticulo":
                     if (Application.OpenForms["FormArticulo"] is FormArticulo form)
                        form.Invoke(() => form.MostrarRespuesta(paquete.Datos.ToString()));
                     break;

                  /// <summary>
                  /// Procesa la respuesta de la consulta de artículos.
                  /// </summary>
                  case "ResultadoConsultaArticulo":
                     if (Application.OpenForms["FormArticulo"] is FormArticulo formC)
                     {
                        var artJson = (JsonElement)paquete.Datos;
                        var lista = JsonSerializer.Deserialize<List<Articulo>>(artJson.GetRawText());
                        formC.Invoke(() => formC.MostrarArticulos(lista));
                     }
                     break;

                  /// <summary>
                  /// Procesa la respuesta tras registrar un cliente.
                  /// </summary>
                  case "ResultadoRegistrarCliente":
                     if (Application.OpenForms["FormCli"] is FormCli formCli)
                        formCli.Invoke(() => formCli.MostrarRespuesta(paquete.Datos.ToString()));
                     break;

                  /// <summary>
                  /// Procesa la respuesta de la consulta de clientes.
                  /// </summary>
                  case "ResultadoConsultaCliente":
                     if (Application.OpenForms["FormCli"] is FormCli formcli)
                     {
                        var json = ((JsonElement)paquete.Datos).GetRawText();
                        var lista = JsonSerializer.Deserialize<List<Clientes>>(json);
                        formcli.Invoke(() => formcli.MostrarClientes(lista));
                     }
                     break;

                  /// <summary>
                  /// Procesa la respuesta tras registrar un repartidor.
                  /// </summary>
                  case "ResultadoRegistrarRepartidor":
                     if (Application.OpenForms["FormRepartidores"] is FormRepartidores formR)
                        formR.Invoke(() => formR.MostrarRespuesta(paquete.Datos.ToString()));
                     break;

                  /// <summary>
                  /// Procesa la respuesta de la consulta de repartidores.
                  /// </summary>
                  case "ResultadoConsultaRepartidores":
                     if (Application.OpenForms["FormRepartidores"] is FormRepartidores formRep)
                     {
                        var lista = JsonSerializer.Deserialize<List<Repartidores>>(((JsonElement)paquete.Datos).GetRawText());
                        formRep.Invoke(() => formRep.MostrarRepartidores(lista));
                     }
                     break;

                  /// <summary>
                  /// Procesa la respuesta tras registrar un pedido, mostrando mensaje y pedido creado.
                  /// </summary>
                  case "ResultadoRegistrarPedido":
                     if (Application.OpenForms["FormPedido"] is FormPedido formPedidos)
                     {
                        using (JsonDocument doc = JsonDocument.Parse(((JsonElement)paquete.Datos).GetRawText()))
                        {
                           string mensaje = doc.RootElement.GetProperty("Mensaje").GetString();
                           var pedidoJson = doc.RootElement.GetProperty("Pedido").GetRawText();
                           Pedidos pedido = JsonSerializer.Deserialize<Pedidos>(pedidoJson);
                           formPedidos.Invoke(() => formPedidos.MostrarRespuesta(mensaje, pedido));
                        }
                     }
                     break;

                  /// <summary>
                  /// Procesa la respuesta de la consulta de pedidos.
                  /// </summary>
                  case "ResultadoConsultaPedido":
                     if (Application.OpenForms["FormPedido"] is FormPedido formPedido)
                     {
                        var lista = JsonSerializer.Deserialize<List<Pedidos>>(((JsonElement)paquete.Datos).GetRawText());
                        if (lista?.Count > 0)
                           formPedido.Invoke(() => formPedido.MostrarPedidos(lista));
                        else
                           MessageBox.Show("No hay pedidos registrados.");
                     }
                     break;

                  /// <summary>
                  /// Procesa la respuesta tras registrar el detalle de pedido.
                  /// </summary>
                  case "ResultadoRegistrarDetallePedido":
                     if (Application.OpenForms["FormDetallePedido"] is FormDetallePedido formRDP)
                     {
                        
                        string mensaje = paquete.Datos.ToString();
                        if (!string.IsNullOrWhiteSpace(mensaje) && mensaje.Contains("completado"))
                        {
                           formRDP.Invoke(() => MessageBox.Show(mensaje));
                        }
                     }
                     break;


                  /// <summary>
                  /// Procesa la consulta de artículos activos para ComboBox.
                  /// </summary>
                  case "ResultadoConsultarArticulosCMB":
                     if (Application.OpenForms["FormDetallePedido"] is FormDetallePedido formDPArt)
                     {
                        var lista = JsonSerializer.Deserialize<List<Articulo>>(((JsonElement)paquete.Datos).GetRawText());
                        formDPArt.Invoke(() => formDPArt.CargarArticulosDesdeServidor(lista));
                     }
                     break;

                  /// <summary>
                  /// Procesa la consulta de detalles de pedido.
                  /// </summary>
                  case "ResultadoConsultarDetallePedido":
                     if (Application.OpenForms["FormDetallePedido"] is FormDetallePedido formDet)
                     {
                        var opciones = new JsonSerializerOptions();
                        opciones.Converters.Add(new ConvertidorDecimalADouble());
                        var lista = JsonSerializer.Deserialize<List<DetallePedidos>>(((JsonElement)paquete.Datos).GetRawText(), opciones);
                        formDet.Invoke(() => formDet.MostrarDetalles(lista));
                     }
                     break;

                  /// <summary>
                  /// Procesa la lista de clientes activos para cargar en ComboBox.
                  /// </summary>
                  case "ResultadoConsultarClientesActivos":
                     if (Application.OpenForms["FormPedido"] is FormPedido formP)
                     {
                        var lista = JsonSerializer.Deserialize<List<Clientes>>(((JsonElement)paquete.Datos).GetRawText());
                        formP.Invoke(() => formP.CargarClientesDesdeServidor(lista));
                     }
                     break;

                  /// <summary>
                  /// Procesa la lista de repartidores activos para cargar en ComboBox.
                  /// </summary>
                  case "ResultadoConsultarRepartidoresActivos":
                     if (Application.OpenForms["FormPedido"] is FormPedido formPed)
                     {
                        var lista = JsonSerializer.Deserialize<List<Repartidores>>(((JsonElement)paquete.Datos).GetRawText());
                        formPed.Invoke(() => formPed.CargarRepartidoresDesdeServidor(lista));
                     }
                     break;

                  /// <summary>
                  /// Procesa el resultado de validación de cliente en login.
                  /// </summary>
                  case "ResultadoValidarCliente":
                     try
                     {
                        if (paquete.Datos is JsonElement jsonElement && jsonElement.ValueKind != JsonValueKind.Null)
                        {
                           var json = jsonElement.GetRawText();
                           Clientes cliente = JsonSerializer.Deserialize<Clientes>(json);

                           FormMenuPrincipal?.Invoke(() =>
                           {
                              if (cliente != null)
                                 FormMenuPrincipal.MostrarClienteValidado(cliente);
                              else
                                 FormMenuPrincipal.MostrarMensajeLogin("Cliente no encontrado.");
                           });
                        }
                     }
                     catch (Exception ex)
                     {
                        MessageBox.Show("Error al procesar la respuesta del servidor: " + ex.Message);
                     }
                     break;

                  /// <summary>
                  /// Muestra mensaje de error proveniente del servidor.
                  /// </summary>
                  case "Error":
                     MessageBox.Show("Servidor: " + paquete.Datos.ToString());
                     break;
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al recibir datos del servidor: " + ex.Message);
               conectado = false;
            }
         }
      }
   }
}
