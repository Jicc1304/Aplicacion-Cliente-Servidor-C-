/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicacion Cliente-Servidor.
 * Estudiante:Jose Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using LibDatos;
using LibEntidades;
using LibNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace AplicacionServidor
{
   /// <summary>
   /// Clase encargada de gestionar el servidor TCP que escucha y procesa solicitudes desde clientes.
   /// </summary>
   public class ServidorTCP
   {
      private TcpListener receptor; // Componente que escucha las conexiones entrantes.
      private bool enEjecucion = false; // Indica si el servidor está activo o detenido.
      private int clientesConectados = 0; // Lleva la cuenta de clientes conectados actualmente.

      // Delegados para mostrar mensajes en una bitácora visual y actualizar el contador de clientes.
      public Action<string> MostrarEnBitacora;
      public Action<int> ActualizarCantidadClientes;

      /// <summary>
      /// Método para iniciar el servidor en el puerto 14100.
      /// </summary>
      public void Iniciar()
      {
         receptor = new TcpListener(IPAddress.Parse("127.0.0.1"), 14100);
         receptor.Start();
         enEjecucion = true;

         MostrarEnBitacora?.Invoke("El Servidor se ha iniciado, efectivamente");

         // Se crea un hilo aparte para escuchar nuevos clientes sin bloquear el hilo principal.
         Thread hiloEscucha = new Thread(EscucharClientes);
         hiloEscucha.Start();
      }

      /// <summary>
      /// Hilo que escucha constantemente nuevas conexiones de clientes.
      /// </summary>
      private void EscucharClientes()
      {
         while (enEjecucion)
         {
            try
            {
               TcpClient cliente = receptor.AcceptTcpClient();
               Interlocked.Increment(ref clientesConectados);
               ActualizarCantidadClientes?.Invoke(clientesConectados);
               MostrarEnBitacora?.Invoke("Cliente conectado.");

               // Cada cliente se procesa en un hilo independiente.
               Thread hiloCliente = new Thread(() => ProcesarCliente(cliente));
               hiloCliente.Start();
            }
            catch
            {
               // Se ignoran errores para que el bucle continúe funcionando.
            }
         }
      }

      /// <summary>
      /// Método que maneja la comunicación con un cliente específico.
      /// </summary>
      private void ProcesarCliente(TcpClient cliente)
      {
         try
         {
            NetworkStream stream = cliente.GetStream();
            byte[] buffer = new byte[8192];
            NegocioPedido negocioPedido = new NegocioPedido();

            while (true)
            {
               int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
               if (bytesLeidos == 0)
               {
                  MostrarEnBitacora?.Invoke("El cliente se desconectó.");
                  break;
               }

               string json = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
               MostrarEnBitacora?.Invoke($"Mensaje recibido: {json}");

               Paquete paquete = JsonSerializer.Deserialize<Paquete>(json);

               if (paquete == null || string.IsNullOrWhiteSpace(paquete.Comando))
               {
                  ResponderError(stream, "Comando no válido o paquete vacío.");
                  continue;
               }

               // Aquí se procesan todos los comandos que pueden llegar desde el cliente
               switch (paquete.Comando)
               {
                  // Valida si un cliente existe por su ID
                  case "ValidarCliente":
                     try
                     {
                        int id = int.Parse(paquete.Datos.ToString());
                        var clienteEncontrado = NegocioCliente.BuscarPorId(id);

                        EnviarPaquete(stream, new Paquete
                        {
                           Comando = "ResultadoValidarCliente",
                           Datos = clienteEncontrado
                        });
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al validar cliente: " + ex.Message);
                     }
                     break;

                  // Registra un nuevo tipo de artículo
                  case "RegistrarTipoArticulo":
                     try
                     {
                        var rawTipoArticulo = ((JsonElement)paquete.Datos).GetRawText();
                        TipoArticulo nuevoTipo = JsonSerializer.Deserialize<TipoArticulo>(rawTipoArticulo);
                        string resultadoTipoArt = NegocioTipoArticulo.RegistrarTipoArticulo(nuevoTipo);

                        EnviarPaquete(stream, new Paquete
                        {
                           Comando = "RegistrarTipoArticulo",
                           Datos = resultadoTipoArt
                        });
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al registrar tipo de artículo: " + ex.Message);
                     }
                     break;

                  // Devuelve la lista de tipos de artículo
                  case "ConsultarTipoArticulo":
                     try
                     {
                        var listaTipoArt = NegocioTipoArticulo.Consultar();
                        EnviarPaquete(stream, new Paquete
                        {
                           Comando = "ConsultarTipoArticulo",
                           Datos = listaTipoArt
                        });
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al consultar tipos de artículo: " + ex.Message);
                     }
                     break;

                  // Registra un nuevo artículo
                  case "RegistrarArticulo":
                     try
                     {
                        var rawArticulo = ((JsonElement)paquete.Datos).GetRawText();
                        Articulo nuevoArticulo = JsonSerializer.Deserialize<Articulo>(rawArticulo);
                        string resultadoArticulo = NegocioArticulo.RegistrarArticulo(nuevoArticulo);

                        EnviarPaquete(stream, new Paquete
                        {
                           Comando = "RRegistrarArticulo",
                           Datos = resultadoArticulo
                        });
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al registrar el artículo: " + ex.Message);
                     }
                     break;

                  // Devuelve la lista completa de artículos
                  case "ConsultarArticulo":
                     try
                     {
                        List<Articulo> listaArticulo = NegocioArticulo.Consultar();

                        Paquete respuesta = new Paquete
                        {
                           Comando = "ResultadoConsultaArticulo",
                           Datos = listaArticulo
                        };

                        EnviarPaquete(stream, respuesta);
                        MostrarEnBitacora?.Invoke($"Se enviaron {listaArticulo.Count} artículos al cliente.");
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al consultar artículos: " + ex.Message);
                     }
                     break;

                  // Registra un nuevo cliente
                  case "RegistrarCliente":
                     try
                     {
                        var raw = ((JsonElement)paquete.Datos).GetRawText();
                        Clientes nuevo = JsonSerializer.Deserialize<Clientes>(raw);
                        string resultadoCli = NegocioCliente.RegistrarCliente(nuevo);

                        EnviarPaquete(stream, new Paquete
                        {
                           Comando = "ResultadoRegistrarCliente",
                           Datos = resultadoCli
                        });
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al registrar el cliente: " + ex.Message);
                     }
                     break;

                  // Consulta todos los clientes
                  case "ConsultarCliente":
                     try
                     {
                        List<Clientes> listaClientes = NegocioCliente.Consultar();

                        Paquete respuesta = new Paquete
                        {
                           Comando = "ResultadoConsultaCliente",
                           Datos = listaClientes
                        };

                        EnviarPaquete(stream, respuesta);
                        MostrarEnBitacora?.Invoke($"Se enviaron {listaClientes.Count} clientes al cliente.");
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al consultar clientes: " + ex.Message);
                     }
                     break;

                  // Registra un nuevo repartidor
                  case "RegistrarRepartidor":
                     try
                     {
                        var rawRepartidor = ((JsonElement)paquete.Datos).GetRawText();
                        Repartidores nuevo = JsonSerializer.Deserialize<Repartidores>(rawRepartidor);
                        string resultadoRepa = NegocioRepartidores.RegistrarRepartidores(nuevo);

                        EnviarPaquete(stream, new Paquete
                        {
                           Comando = "ResultadoRegistrarRepartidor",
                           Datos = resultadoRepa
                        });
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al registrar repartidor: " + ex.Message);
                     }
                     break;

                  // Consulta todos los repartidores
                  case "ConsultarRepartidores":
                     try
                     {
                        List<Repartidores> listaRepartidores = NegocioRepartidores.Consultar();

                        Paquete respuesta = new Paquete
                        {
                           Comando = "ResultadoConsultaRepartidores",
                           Datos = listaRepartidores
                        };

                        EnviarPaquete(stream, respuesta);
                        MostrarEnBitacora?.Invoke($"Se enviaron {listaRepartidores.Count} repartidores al cliente.");
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al consultar repartidores: " + ex.Message);
                     }
                     break;

                  // Devuelve solo clientes activos
                  case "ConsultarClientesActivos":
                     try
                     {
                        List<Clientes> listaClientes = NegocioCliente.ConsultarActivos();
                        Paquete respuesta = new Paquete
                        {
                           Comando = "ResultadoConsultarClientesActivos",
                           Datos = listaClientes
                        };
                        EnviarPaquete(stream, respuesta);
                        MostrarEnBitacora?.Invoke($"Se enviaron {listaClientes.Count} clientes activos.");
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al consultar clientes activos: " + ex.Message);
                     }
                     break;

                  // Devuelve solo repartidores activos
                  case "ConsultarRepartidoresActivos":
                     try
                     {
                        List<Repartidores> listaRepartidores = NegocioRepartidores.ConsultarActivos();
                        Paquete respuesta = new Paquete
                        {
                           Comando = "ResultadoConsultarRepartidoresActivos",
                           Datos = listaRepartidores
                        };
                        EnviarPaquete(stream, respuesta);
                        MostrarEnBitacora?.Invoke($"Se enviaron {listaRepartidores.Count} repartidores activos.");
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al consultar repartidores activos: " + ex.Message);
                     }
                     break;

                  // Registra un nuevo pedido y devuelve el objeto actualizado
                  case "RegistrarPedido":
                     try
                     {
                        var rawPedido = ((JsonElement)paquete.Datos).GetRawText();
                        Pedidos nuevoPedido = JsonSerializer.Deserialize<Pedidos>(rawPedido);
                        string resultado = NegocioPedido.RegistrarPedidos(nuevoPedido);

                        EnviarPaquete(stream, new Paquete
                        {
                           Comando = "ResultadoRegistrarPedido",
                           Datos = new { Mensaje = resultado, Pedido = nuevoPedido }
                        });
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al registrar pedido: " + ex.Message);
                     }
                     break;

                  // Devuelve todos los pedidos registrados
                  case "ConsultarPedido":
                     try
                     {
                        List<Pedidos> listaPedido = NegocioPedido.Consultar();
                        Paquete respuesta = new Paquete
                        {
                           Comando = "ResultadoConsultaPedido",
                           Datos = listaPedido
                        };
                        EnviarPaquete(stream, respuesta);
                        MostrarEnBitacora?.Invoke($"Se enviaron {listaPedido.Count} pedidos al cliente.");
                     }
                     catch (Exception ex)
                     {
                        ResponderError(stream, "Error al consultar pedidos: " + ex.Message);
                     }
                     break;

                  // Registra un detalle de pedido
                  case "RegistrarDetallePedido":
                     var rawDetalle = ((JsonElement)paquete.Datos).GetRawText();
                     DetallePedidos detalle = JsonSerializer.Deserialize<DetallePedidos>(rawDetalle);
                     string resultadoDetalle = NegocioDetallePedido.RegistrarDetalle(detalle);
                     EnviarPaquete(stream, new Paquete
                     {
                        Comando = "ResultadoRegistrarDetallePedido",
                        Datos = resultadoDetalle
                     });
                     break;

                  // Consulta los detalles de pedido registrados
                  case "ConsultarDetallePedido":
                     var listaDetalles = NegocioDetallePedido.Consultar();
                     EnviarPaquete(stream, new Paquete
                     {
                        Comando = "ResultadoConsultarDetallePedido",
                        Datos = listaDetalles
                     });
                     break;

                  // Devuelve los pedidos para llenar un ComboBox
                  case "ConsultarPedidosCMB":
                     var listaPedidos = NegocioPedido.Consultar() ?? new List<Pedidos>();
                     EnviarPaquete(stream, new Paquete
                     {
                        Comando = "ResultadoConsultarPedidosCMB",
                        Datos = listaPedidos
                     });
                     break;

                  // Devuelve los artículos activos para un ComboBox
                  case "ConsultarArticulosCMB":
                     var listaArticulos = NegocioArticulo.ConsultarActivos() ?? new List<Articulo>();
                     EnviarPaquete(stream, new Paquete
                     {
                        Comando = "ResultadoConsultarArticulosCMB",
                        Datos = listaArticulos
                     });
                     break;

                  // Respuesta genérica para confirmar conexión
                  case "Conectando":
                     EnviarPaquete(stream, new Paquete { Comando = "Conectado", Datos = "Conexión establecida correctamente." });
                     break;
               }
            }
         }
         catch (Exception ex)
         {
            MostrarEnBitacora?.Invoke("Error en cliente: " + ex.Message);
         }
         finally
         {
            cliente.Close();
            Interlocked.Decrement(ref clientesConectados);
            ActualizarCantidadClientes?.Invoke(clientesConectados);
            MostrarEnBitacora?.Invoke("Cliente desconectado.");
         }
      }

      /// <summary>
      /// Método que se encarga de serializar y enviar un paquete al cliente.
      /// </summary>
      private void EnviarPaquete(NetworkStream stream, Paquete paquete)
      {
         string json = JsonSerializer.Serialize(paquete);
         byte[] datos = Encoding.UTF8.GetBytes(json);
         stream.Write(datos, 0, datos.Length);
         stream.Flush();
      }

      /// <summary>
      /// Envía un mensaje de error al cliente ante cualquier excepción o problema.
      /// </summary>
      private void ResponderError(NetworkStream stream, string mensaje)
      {
         EnviarPaquete(stream, new Paquete { Comando = "Error", Datos = mensaje });
      }

      /// <summary>
      /// Detiene el servidor y libera los recursos asociados.
      /// </summary>
      public void Detener()
      {
         enEjecucion = false;
         receptor.Stop();
         MostrarEnBitacora?.Invoke("Servidor detenido.");
      }
   }
}
