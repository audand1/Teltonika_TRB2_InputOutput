using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace TRB2_InputOutput
{
     class CommunicationManager
    {
        private string Username;
        private string Password;
        private string URL;
        private string Token;

        public  CommunicationManager()
        {
            Username = string.Empty;
            Password = string.Empty;
            URL = string.Empty;
            Token = string.Empty;
      
        }


        public int  SetupParameters(string Username, string Password, string URL)
        {

            if(!ValidateUsernamePassword(Username))
            {
                return 1;
            }

            if(!ValidateUsernamePassword(Password))
            {
                return 2;
            }

            if (!ValidateURL(URL))
            {
                return 3;
            }


            this.Username = Username;
            this.Password = Password;
            this.URL = URL;
            


            return 0;
        }
        public int updateFromDevice()
        {

            if (String.IsNullOrEmpty(Token))
                if (login() != 0)
                    return 1;

            if (adc() != 0)
                if (login() != 0)  // try relogin
                    return 1;
                else if (adc() != 0)
                    return 2;
     
            if (getDIO(0) != 0)
                return 3;
 
            if (getDIO(1) != 0)
                return 4;
       
            if (getDIO(2) != 0)
                return 5; 

            return 0;
        }

        public int updateToDevice()
        {
           
            if (String.IsNullOrEmpty(Token))
                if (login() != 0)
                    return 1;

 
            if (setDIO(0) != 0)
                if (login() != 0)  // try relogin
                    return 1;
                else if(setDIO(0) != 0)
                    return 3;
                
            if (setDIO(1) != 0)
                return 4;

            if (setDIO(2) != 0)
                return 5;

            return 0;
        }



        private bool ValidateURL(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return false;

            // string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            var regexItem = new Regex("^[a-zA-Z0-9./:-~_?]*$");

            if (regexItem.IsMatch(input))
            {
                return true;
            }

            return false;

        }
        private bool ValidateUsernamePassword(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                return false;

           // string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";

            var regexItem = new Regex("^[a-zA-Z0-9_]*$");

            if (regexItem.IsMatch(input)) 
            {
                return true;
            }
           
            return false;
        
        }      
        private int login()
        {
            string RequestData = "{\"jsonrpc\":\"2.0\", \"id\":1, \"method\":\"call\"," +
                         "\"params\":[\"00000000000000000000000000000000\", \"session\", \"login\",{" +
                         "\"username\":\"" + Username + "\", \"password\":\""+  Password +"\" } ] }";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "/ubus");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = RequestData.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(RequestData);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    JsonRPC rpc = JsonConvert.DeserializeObject<JsonRPC>(response);

                    if (rpc.error != null)
                        return 1;

                    if (int.Parse(rpc.result[0].ToString()) == 0)
                    {
                        Token = rpc.result[1]["ubus_rpc_session"].ToString();
                        return 0;
                    }
                    else
                        return int.Parse(rpc.result[0].ToString());
     
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return -1;
        }
        private int adc()
        {
            string getADC = "{\"jsonrpc\":\"2.0\", \"id\":1, \"method\":\"call\"," +
                       "\"params\":[\"" + Token + "\", \"ioman.adc.adc0\", \"status\",{ } ] }";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "/ubus");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = getADC.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(getADC);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    JsonRPC rpc = JsonConvert.DeserializeObject<JsonRPC>(response);

                    if (rpc.error != null)
                        return 1;

                    if (int.Parse(rpc.result[0].ToString()) == 0)
                    {
                        TRB2DIOState.I.ADCValue = double.Parse(rpc.result[1]["value"].ToString());
                        return 0;
                    }
                    else
                        return int.Parse(rpc.result[0].ToString());

                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return -1;
        }
        private int getDIO(int no)
        {
            if (no > 2 || no < 0)
                return -1;

            string getdio = "{\"jsonrpc\":\"2.0\", \"id\":1, \"method\":\"call\"," +
                       "\"params\":[\"" + Token + "\", \"ioman.gpio.dio"+ no +"\", \"status\",{ } ] }";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "/ubus");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = getdio.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(getdio);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    JsonRPC rpc = JsonConvert.DeserializeObject<JsonRPC>(response);

                    if (rpc.error != null)
                        return 1;

                    if (int.Parse(rpc.result[0].ToString()) == 0)
                    {
                        int tmp = int.Parse(rpc.result[1]["value"].ToString());
                        if (tmp == 1)
                            TRB2DIOState.I.DIOState[no] = true;
                        else
                            TRB2DIOState.I.DIOState[no] = false;

                        if (rpc.result[1]["direction"].ToString().CompareTo("in") == 0)
                            TRB2DIOState.I.DIODirection[no] = true;
                        else if (rpc.result[1]["direction"].ToString().CompareTo("out") == 0)
                            TRB2DIOState.I.DIODirection[no] = false;
                        else
                            return -1;

                        return 0;
                    }
                    else
                        return int.Parse(rpc.result[0].ToString());

                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return -1;
        }
        private int setDIO(int no)
        {
            if (no > 2 || no < 0)
                return -1;

            string setdio = "{\"jsonrpc\":\"2.0\", \"id\":1, \"method\":\"call\"," +
                       "\"params\":[\"" + Token + "\", \"ioman.gpio.dio" + no + "\", \"update\",{" +
                       "\"save_conf\":"+ TRB2DIOState.I.DIOSaveConfig[no].ToString() + "," +
                       "\"direction\":\"" + (TRB2DIOState.I.DIODirection[no] ? "in" : "out\", " +
                       "\"value\":\"" +  (TRB2DIOState.I.DIOState[no]? "1" : "0")  ) + "\" } ] }";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "/ubus");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = setdio.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(setdio);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    JsonRPC rpc = JsonConvert.DeserializeObject<JsonRPC>(response);

                    if (rpc.error != null)
                        return 1;

                    if (int.Parse(rpc.result[0].ToString()) == 0)
                    {                       
                        return 0;
                    }
                    else
                        return int.Parse(rpc.result[0].ToString());

                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return -1;
        }
    }

    class JsonRPC
    {
        public string jsonrpc { get; set; }
        public string id { get; set; }
        public JToken  error { get; set; }
        public IList<JToken> result { get; set; }
    }




}
