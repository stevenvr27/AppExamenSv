using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace AppExamenSv.Models
{
    
    public  class Ask
    {
        RestRequest RestRequest { get; set; }
        public RestRequest Request { get; set; }
        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Ask1 { get; set; } = null!;
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string? ImageUrl { get; set; }
        public string? AskDetail { get; set; }

        public virtual AskStatus? AskStatus { get; set; } = null!;
        public virtual User? User { get; set; } = null!;

        public async Task<bool> Addasknew()
        {
            try
            {
                string RouteSufix = string.Format("Asks");

                //con esto obtenemos la ruta completa de consumo del API 
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos la info de la llave de seguridad (ApiKey) 
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.contentType, GlobalObjects.minetype);

                //En este caso tenemos que enviar un JSON al API con la data del usuario que se quiere
                //agregar
                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel, GlobalObjects.minetype);

                //ejecución de la llamada al controlador 
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                //almacenar registro de errores en una bitacora para analisis posterior 
                //también puede ser enviarlos a un servidor de captura de errores

                throw;
            }

        }


        public async Task<List<Ask>> GetAllask()
        {
            try
            {
                string RouteSufix = string.Format("Asks");

                //con esto obtenemos la ruta completa de consumo del API 
                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos la info de la llave de seguridad (ApiKey) 
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.contentType, GlobalObjects.minetype);

                //ejecución de la llamada al controlador 
                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    //usamos newtonsoft para descomponer el paquete json que nos llega
                    //desde el API
                    var list = JsonConvert.DeserializeObject<List<Ask>>(response.Content);
                    return list;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;

                //almacenar registro de errores en una bitacora para analisis posterior 
                //también puede ser enviarlos a un servidor de captura de errores

                throw;
            }

        }

















    }
}
