using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioInfraccional.DataContract
{
    public class Respuesta
    {
        #region Respuestas Genéricas
        public static InfraccionalResponse RespuestaCRUDInvalido()
        {
            InfraccionalResponse resp = new InfraccionalResponse();

            resp.Mensaje = "CRUD ingresado no válido";

            return resp;
        }
        public static InfraccionalResponse RespuestaRegistoExistente()
        {
            InfraccionalResponse resp = new InfraccionalResponse();
   
            resp.Mensaje = "El registro ya existe";
            resp.CodigoRespuesta = "ERROR_EXISTS";
            resp.Json = "";

            return resp;
        }
        public static InfraccionalResponse RespuestaRegistrosInexistente()
        {
            InfraccionalResponse resp = new InfraccionalResponse();

            resp.Mensaje = "No existen registros";
            resp.CodigoRespuesta = "ERROR_OBLIS";
            resp.Json = "";
            return resp;
        }

        public static InfraccionalResponse RespuestaRegistroNoExistente()
        {
            InfraccionalResponse resp = new InfraccionalResponse();
            
            resp.Mensaje = "El registro no existe";
            resp.CodigoRespuesta = "ERROR_NOF";
            resp.Json = "";

            return resp;
        }
        public static InfraccionalResponse RespuestaCodigoEntidadErroneo()
        {
            InfraccionalResponse resp = new InfraccionalResponse();
            
            resp.Mensaje = "El codigo de entidad no es correcto";
            resp.CodigoRespuesta = "ERROR_CODE";
            resp.Json = "";

            return resp;
        }
        public static InfraccionalResponse RespuestaMensajeErroneoPersonalizado(string respuesta)
        {
            InfraccionalResponse resp = new InfraccionalResponse();
            
            resp.Mensaje = respuesta;
            resp.CodigoRespuesta = "ERROR_CODE";
            resp.Json = "";

            return resp;
        }

    
        public static InfraccionalResponse RespuestaPersonalizado(string respuesta, string codigoRespuesta)
        {
            InfraccionalResponse resp = new InfraccionalResponse();
            
            resp.Mensaje = respuesta;
            resp.CodigoRespuesta = codigoRespuesta;
            resp.Json = "";

            return resp;
        }

        public static InfraccionalResponse RespuestaPersonalizado(string respuesta, string codigoRespuesta, string json)
        {
            InfraccionalResponse resp = new InfraccionalResponse();
            
            resp.Mensaje = respuesta;
            resp.CodigoRespuesta = codigoRespuesta;
            resp.Json = json;

            return resp;
        }

        #endregion      

    }
}