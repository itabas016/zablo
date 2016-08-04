using Microsoft.Extensions.DependencyInjection;

namespace zablo.Domains
{
    public class Register
    {
        public IServiceCollection _services { get; set; }
        public Register(IServiceCollection services)
        {
            this._services = services;
        }

        public void Init()
        {
            _services.AddSingleton<ITodoRepository, TodoRepository>();
        }
    }
}
