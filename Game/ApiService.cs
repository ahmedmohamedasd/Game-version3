using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ApiService
    {
        private HttpClient httpClient;
        public ApiService() 
        {
          httpClient = new HttpClient();
        
        }
        public async Task<ScanModel> ScanQrcode(string apiUrl , string action , Dictionary<string, string> scanFormData)
        {
                ScanModel model = new ScanModel();
            try
            {
                var formContent = new FormUrlEncodedContent(scanFormData);

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl +action , formContent);

                if (response.IsSuccessStatusCode)
                {
                    var resposeresult = await response.Content.ReadAsStringAsync();
                    try
                    {
                        JObject jsonObject = JObject.Parse(resposeresult);
                        if (jsonObject.ContainsKey("user"))
                        {
                             JToken userToken = jsonObject["user"];
                            if(userToken.Type == JTokenType.Array && !userToken.HasValues) {

                                model.user = null;
                                model.status = 404;
                                model.Errors = "User Not Found";
                            }
                            else
                            {
                                model = JsonConvert.DeserializeObject<ScanModel>(resposeresult);
                            }
                        }
                        
                    }
                    catch(Exception _)
                    {

                    }
                   

                }
                else
                {
                    model.status =(int)response.StatusCode;
                }
            }catch (Exception ex)
            {

                model.status = 500;
            }

            return model;
        }

        public async Task<ScanModel> Register( string apiUrl , string action, Dictionary<string, string> formdata)
        {
            string responseContent = string.Empty;
            ScanModel model = new ScanModel();
            try
            {

                var formContent = new FormUrlEncodedContent(formdata);

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + action, formContent);
                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(responseContent);
                    if (jsonObject.ContainsKey("user"))
                    {
                        JToken userToken = jsonObject["user"];
                        if (userToken.Type == JTokenType.Array && !userToken.HasValues)
                        {

                            model.user = null;
                            model.status = 404;
                            model.Errors = "User Not Found";
                        }
                        else
                        {
                            model = JsonConvert.DeserializeObject<ScanModel>(responseContent);
                        }
                    }

                }
                else
                {
                    model.status = (int)response.StatusCode;
                    model.Errors = "Can not Add User";
                }
            }catch(Exception ex)
            {
                model.status = 600;
                model.Errors = ex.Message;

            }
            return model;
        }

        public async Task<GameStatus> StartGame(string apiUrl ,string action , Dictionary<string,string> formData)
        {
            string responseContent = string.Empty;
            GameStatus model = new GameStatus();
            try
            {
                var Data = new FormUrlEncodedContent(formData);
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + action, Data);
                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                  
                    model = JsonConvert.DeserializeObject<GameStatus>(responseContent);

                }
                else
                {
                    model.status = (int)response.StatusCode;
                    model.Errors = "Can not Start Game";
                }

            }
            catch(Exception ex )
            {
                model.Errors = ex.Message;
            }
            return model;
        }

        public async Task<GameStatus> EndGame(string apiUrl, string action, Dictionary<string, string> formData)
        {
            string responseContent = string.Empty;
            GameStatus model = new GameStatus();
            try
            {
                var Data = new FormUrlEncodedContent(formData);
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + action, Data);
                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();

                    model = JsonConvert.DeserializeObject<GameStatus>(responseContent);

                }
                else
                {
                    model.status = (int)response.StatusCode;
                    model.Errors = "Can not End Game";
                }

            }
            catch (Exception ex)
            {
                model.Errors = ex.Message;
            }
            return model;
        }


        public async Task<GameStatus> ForceEndGame(string apiUrl, string action, Dictionary<string, string> formData)
        {
            string responseContent = string.Empty;
            GameStatus model = new GameStatus();
            try
            {
                var Data = new FormUrlEncodedContent(formData);
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + action, Data);
                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();

                    model = JsonConvert.DeserializeObject<GameStatus>(responseContent);
                }
                else
                {
                    model.status = (int)response.StatusCode;
                    model.Errors = "Can not be Forced End Game";
                }
            }
            catch (Exception ex)
            {
                model.Errors = ex.Message;
            }
            return model;
        }
        public async Task<GameStatus> CheckingGame(string apiUrl, string action, Dictionary<string, string> formData)
        {
            string responseContent = string.Empty;
            GameStatus model = new GameStatus();
            try
            {
                var Data = new FormUrlEncodedContent(formData);
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl + action, Data);
                if (response.IsSuccessStatusCode)
                {
                    responseContent = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<GameStatus>(responseContent);
                }
                else
                {
                    model.status = (int)response.StatusCode;
                    model.Errors = "Can not chek Game";
                }
            }
            catch (Exception ex)
            {
                model.Errors = ex.Message;
            }
            return model;
        }
    }
}
