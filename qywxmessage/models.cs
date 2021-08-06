namespace qywxmessage
{
    public class Qywxrespone
    {
        public int errcode   { get; set; }
        public string errmsg   { get; set; }
        public string access_token   { get; set; }
        public int expires_in   { get; set; }
    }
    
    public class Qywsendcontent
    {
        public string content   { get; set; }
    }
    
    public class Qywsendmessage
    {
        public string touser   { get; set; }
        public string agentid   { get; set; }
        public string msgtype   { get; set; }
        public int safe   { get; set; }
        public Qywsendcontent text   { get; set; }
    }
}