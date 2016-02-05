using DI.Web.Ex05.Repositories;

namespace DI.Web.Ex05.Services
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
        private readonly IRepository<string> _repository;

        public SampleService() : this(new Repository<string>())
        {
        }

        public SampleService(IRepository<string> repository)
        {
            _repository = repository;
        }

        public string GetMessage(int id)
        {
            switch (id)
            {
                case 1:
                    return "ASP.NET " + _repository.Get(id);
                case 2:
                    return "Your application description page. " + _repository.Get(id);
                case 3:
                    return "Your contact page. " + _repository.Get(id);
                default:
                    return string.Empty;
            }
        }
    }
}