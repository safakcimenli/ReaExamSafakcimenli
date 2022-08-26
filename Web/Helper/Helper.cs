namespace Web.Helper
{
    public class Helper
    {
        public class API
        {
            
            public HttpClient initial()
            {
                var client = new HttpClient();
                //You have to edit this area for your pc
                client.BaseAddress = new Uri("https://localhost:7255/");
                return client;
            }
            
        }
    }
}
