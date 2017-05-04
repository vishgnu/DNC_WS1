using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNC_WS
{
    public static class ReinRausMiddlewareExtension
    {
        public static IServiceCollection AddReinRaus(this IServiceCollection serviceCollection,
            Action<ReinRausOptions> setupAction)
        {
            if (setupAction != null)
            {
                serviceCollection.Configure(setupAction);
            }
            return serviceCollection;
        }
    }
}
