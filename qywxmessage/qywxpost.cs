using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace qywxmessage
{
    public class easywxpost
    {
        public static string sendpack(string message)
        {
            var corp_id = ""; // Your corp_id
            var app_secret = ""; // Your app_secret
            var app_id = ""; // Your app_id
            HttpWebRequest req =  
                (HttpWebRequest)HttpWebRequest.Create("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid="+corp_id+"&corpsecret="+app_secret); 
            req.Method = "GET"; 
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                var encoding = Encoding.GetEncoding(response.CharacterSet);

                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream, encoding))
                {
                    string qywxres = reader.ReadToEnd();
                    string getsring = JsonSerializer.Deserialize<Qywxrespone>(qywxres).access_token;
                    
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token="+getsring);
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        var sendcontent = new Qywsendmessage();
                        var sendmessage = new Qywsendcontent();
                        sendmessage.content = message;
                        sendcontent.agentid = app_id;
                        sendcontent.touser = "@all";
                        sendcontent.msgtype = "text";
                        sendcontent.safe = 0;
                        sendcontent.text = sendmessage;
                        string json = JsonSerializer.Serialize(sendcontent);
                        Console.WriteLine(json);
                        streamWriter.Write(json);
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var postresult = streamReader.ReadToEnd();
                        return "Hi there! From Guide ☺\n" + message + " sent @" + DateTime.Now + "\n" + postresult;
                    }
                    
                }

                
            }

        }
    }
}