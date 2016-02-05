namespace DI.Web.Ex08.Repositories
{
    public interface IRepository<T>
    {
        string Get(int id);
    }

    /// <summary>
    /// Let's pretend we're hitting a database here
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        public string Get(int id)
        {
            switch (id)
            {
                case 1:
                    return "ID: 1 called";
                case 2:
                    return "Something returned from database";
                case 3:
                    return "Something else from database";
                default:
                    return string.Empty;
            }
        }
    }
}