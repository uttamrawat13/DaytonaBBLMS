using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualStudio.Services.WebApi; /* for PATCH */
using BBDNRESTDemoCSharp;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml;
 


namespace BBDNRESTDemoCSharp
{
    public class UserService : IRestService<User>, IDisposable
    {
        HttpClient client;


        public UserService(Token token)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
        }

        public async Task<User> CreateObject(User newUser)
        {
            User user = new User();
            var uri = new Uri(Constants.HOSTNAME + Constants.USER_PATH);
            try
            {
                var json = JsonConvert.SerializeObject(newUser);
                var body = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, body);
                Constants.RESPONSERESULT = "Fail";
                if (response.IsSuccessStatusCode)
                {
                    Constants.RESPONSERESULT = "Create";
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                    Debug.WriteLine(@"User successfully created.");
                }
                else
                {
                    if (response.ToString().Contains("409"))
                    {
                        Constants.RESPONSERESULT = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return user;
        }

        public async Task<User> ReadObject()
        {
            User user = new User();
          //  var uri = new Uri(Constants.HOSTNAME + Constants.USER_PATH + "/externalId:" + Constants.USER_ID);
            var uri = new Uri(Constants.HOSTNAME + Constants.USER_PATH + "/externalId:" + Constants.USER_ID);
          
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"			ERROR {0}", ex.Message);
            }
            return user;
        }
        public async Task<DataTable> ReadAllObject()
        {
            DataTable dt = new DataTable();
                    
            List<User> users = new List<User>();
           // DataSet dsResult = new DataSet();  
            //  var uri = new Uri(Constants.HOSTNAME + Constants.USER_PATH + "/externalId:" + Constants.USER_ID);
            var uri = new Uri(Constants.HOSTNAME + Constants.USER_PATH);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //user = JsonConvert.DeserializeObject<User>(content);
                   // List<User> weapons = new List<User>();

                   // weapons = JsonConvert.SerializeObject(content); ;// JsonConvert.DeserializeObject<User>(content, typeof(User));

                   // var content = await response.Content.ReadAsStringAsync();

                   /* var jserializer = new JavaScriptSerializer();
                    jserializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                    dynamic objgetuser = jserializer.Deserialize(content, typeof(object));


                    int count = 0;
                    count = objgetuser.results.Length;
                    User user = new User();
            
                    for (int i = 0; i < count; i++)
                    {
                        user.address = objgetuser[i].address;
                        user.name = objgetuser[i].name;
                        user.userName = objgetuser[i].userName;
                        user.uuid = objgetuser[i].uuid;
                        users.Add(user);
                    }*/
                    DataTable dsuser = new DataTable();
                    DataSet dsMyData = new DataSet();
                    XmlDocument xdMyData = new XmlDocument();
                    string sData = "{ \"results\": {" + content.Trim().TrimStart('{').TrimEnd('}') + "} }";
                    xdMyData = (XmlDocument)JsonConvert.DeserializeXmlNode(sData);
                    dsMyData.ReadXml(new XmlNodeReader(xdMyData));
                    if (dsMyData.Tables.Count >= 1)
                    {
                        dt = dsMyData.Tables[0];
                        dt = dsMyData.Tables[1];
                        dt = dsMyData.Tables[2];
                        dt = dsMyData.Tables[3];
                        dt = dsMyData.Tables[4];
                        dt = dsMyData.Tables[5];
                        dt = dsMyData.Tables[6];
                       /*   User user = new User();
                        foreach (DataRow dr in dsMyData.Tables[0].Rows)
                        {

                            user.uuid = Convert.ToString(dr["uuid"]);
                            user.gender = Convert.ToString(dr["gender"]);
                            user.userName = Convert.ToString(dr["userName"]);
                            user.id = Convert.ToString(dr["id"]);
                            users.Add(user);
                        }*/
                   }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"			ERROR {0}", ex.Message);
            }
            return dt;
        }


        public async Task<User> UpdateObject(User updateuser)
        {
            User user = new User();

            try
            {
                #region "Set Updateuser User"

                UpdateUser upuser = new UpdateUser();
                upuser.externalId = updateuser.externalId;
                upuser.password = updateuser.password;
                upuser.userName =  updateuser.userName;
                upuser.studentId = updateuser.studentId;
                //user.educationLevel = string.Empty;
                //user.gender = string.Empty;
                //user.birthDate = string.Empty;


                upuser.systemRoleIds = updateuser.systemRoleIds;
                upuser.availability = updateuser.availability;
                upuser.name = updateuser.name;

                //job.title = string.Empty;
                //job.department = string.Empty;
                //job.company = string.Empty;
                upuser.job = updateuser.job;

                upuser.contact = updateuser.contact;

                upuser.address = updateuser.address;
                upuser.locale = updateuser.locale;

                #endregion

                var json = JsonConvert.SerializeObject(upuser);
                var body = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClientExtensions.PatchAsync(client, Constants.HOSTNAME + Constants.USER_PATH + "/externalId:" + Constants.USER_ID, body);

                Constants.RESPONSERESULT = "Fail";
 
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"				User successfully updated.");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(content);
                        Constants.RESPONSERESULT = "Update";
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return user; 
        }

        public async Task<User> DeleteObject()
        {
            User user = new User();
            var uri = new Uri(Constants.HOSTNAME + Constants.USER_PATH + "externalId:" + Constants.USER_ID);

            try
            {
                var response = await client.DeleteAsync(uri);
                Constants.RESPONSERESULT = "Fail";
                
                if (response.IsSuccessStatusCode)
                {
                    Constants.RESPONSERESULT = "Update";
                
                    Debug.WriteLine(@"				User successfully deleted.");
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return (user);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                client.Dispose();

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~UserService() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}

