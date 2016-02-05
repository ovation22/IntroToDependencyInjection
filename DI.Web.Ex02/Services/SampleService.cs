namespace DI.Web.Ex02.Services
{
    /// <summary>
    /// Business logic would go here
    /// </summary>
    public class SampleService
    {
        public string GetMessage(int id)
        {
            switch (id)
            {
                case 1:
                    return "ASP.NET";
                case 2:
                    return "Your application description page.";
                case 3:
                    return "Your contact page.";
                default:
                    return string.Empty;
            }
        }
    }
}