namespace DI.Web.Ex04.Services
{
    public interface ISampleService
    {
        string GetMessage(int id);
    }

    /// <summary>
    /// Business logic would go here
    /// </summary>
    public class SampleService : ISampleService
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