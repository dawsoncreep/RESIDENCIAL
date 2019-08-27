using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Web;

namespace AppResidencial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private string usuario;
        private string pass;

        public LoginPage ()
		{
			InitializeComponent ();
           
            btn_iniciar.Clicked += BtnIniciar_Clicked;
            picker_fracc.Items.Add("");
            picker_fracc.Items.Add("Pulgas pandas");

          
        }

       //Boton para iniciar sesion
        private void BtnIniciar_Clicked(object sender, EventArgs e)
        {

            HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://10.92.184.149:5001/oauth2/token");
            myHttpWebRequest.Method = "POST";
            var dataD = new Dictionary<string, string>();
            dataD.Add("username", "admin");
            dataD.Add("password", "Admin123.");
            dataD.Add("grant_type", "password");
            dataD.Add("client_id", "86c6ee593e144cd197611a6da15684b0");

            string postData = "";

            foreach (string key in dataD.Keys)
            {
                postData += HttpUtility.UrlEncode(key) + "="
                      + HttpUtility.UrlEncode(dataD[key]) + "&";
            }

            byte[] data = Encoding.ASCII.GetBytes(postData);

            myHttpWebRequest.Accept = "application/json";
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            myHttpWebRequest.ContentLength = data.Length;

            Stream requestStream = myHttpWebRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            HttpWebResponse myHttpWebResponse;

            try
            {
                var res = myHttpWebRequest.GetResponse();
               
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

             Stream responseStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);
                string pageContent = myStreamReader.ReadToEnd();
                //TokenResult tokenRes = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResult>(myStreamReader.ReadToEnd());
                myStreamReader.Close();

                responseStream.Close();

                myHttpWebResponse.Close();


            }
            catch (Exception ex)
            {

            }

           
            

            
          
            //return pageContent;

            if (usuario != "admin" || pass != "moce650529324")
            {

                DisplayAlert("Error", "Usuario y/o Contraseña incorrecto", "Aceptar");

               
                entry_pass.Text = "";
            }
            else
            {
                Navigation.PushAsync(new HomePage());
               
            }
        }
           
    }
}