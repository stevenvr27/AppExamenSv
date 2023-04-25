using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppExamenSv.Models
{
    public  class Answer
    {
        public RestRequest Request { get; set; }
        const string MineType = "application/json";
        const string ContentType = "application/json";

        public Answer()
        {
            
        }
        public long AnswerId { get; set; }
        public int UserId { get; set; }
        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string Answer1 { get; set; } = null!;
        public bool? SetAsCorrect { get; set; }
        public bool? IsStrike { get; set; }

        public virtual Ask Ask { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        public async Task<bool> Validateanswer()
        {
            try
            {
                string RouteSufix = string.Format("Answers/Validateanswer?panswer={0}&pid={1}", this.AnswerId, this.AskId);

                string URL = Services.APIConnection.ProductionURLPrefix + RouteSufix;

                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects. contentType, GlobalObjects.minetype);

                RestResponse response = await client.ExecuteAsync(Request);
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
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
                string Error = ex.Message;
                throw;
            }

        }

        public async Task<bool> Addanswer()
        {
            try
            {
                string RouteSufix = string.Format("Answer");

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


    }
}
