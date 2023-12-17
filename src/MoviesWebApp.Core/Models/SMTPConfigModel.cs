namespace MoviesWebApp.Core.Models
{
    public class SMTPConfigModel
    {
        public string SenderAdress { get;set; }
        public string UserName { get; set; }
       public string   SenderDisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int  Port { get; set; }
        
        public bool EnableSSL { get; set; }
        public bool USeDefaultCredebtials { get; set; }
        public bool IsBodyHTML { get; set; }
        

        
    
    }
}
