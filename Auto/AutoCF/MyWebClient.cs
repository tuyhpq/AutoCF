namespace AutoCF
{
    public class MyWebClient : System.Net.WebClient
    {
        public MyWebClient() : base()
        {
            this.Encoding = System.Text.Encoding.UTF8;
            this.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            this.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
        }
    }
}
