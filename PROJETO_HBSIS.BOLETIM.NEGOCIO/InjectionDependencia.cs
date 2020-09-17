using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;

namespace PROJETO_HBSIS.BOLETIM.NEGOCIO
{
    public static class InjectionDependencia
    {
        public static void Injetar(this IServiceCollection services, string connection)
        {
            services.AddDbContext<BancoContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IBoletimNegocio, BoletimNegocio>();
        }

    }
}
