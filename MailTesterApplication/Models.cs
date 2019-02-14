namespace MailTestApplication
{
    public class MailStatus
    {
        public string IPAddress { get; set; }
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string MailServer { get; set; }
        public int PortNumber { get; set; }
        public string TimeSent { get; set; }
    }
}
