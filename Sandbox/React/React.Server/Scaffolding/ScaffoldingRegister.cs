namespace Sandbox.Scaffolding
{
    public static class ScaffoldingRegister
    {
        /// <summary>
        /// Adds all scoped services in a project e.g. adds IMyService for dependency injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblyName"></param>
        /// <param name="configuration"></param>
        /// <returns>IServiceCollection it modified</returns>
        /// <exception cref="Exception"></exception>
        public static IServiceCollection RegisterServices(this IServiceCollection services, string assemblyName, IConfiguration? configuration = null)
        {
            var appServices = System.Reflection.Assembly.Load(assemblyName)
                .GetTypes()
                .Where(s => s.Name.EndsWith(assemblyName) && s.IsInterface == false)
                .ToList();

            foreach (var appService in appServices)
            {
                Type? serviceInterface = appService.GetInterface($"I{appService.Name}");

                if (serviceInterface != null)
                {
                    services.Add(new ServiceDescriptor(serviceInterface, appService, ServiceLifetime.Scoped));
                }
                else
                {
                    throw new Exception($"Unable to register class {appService.Name}");
                }
            }
            return services;
        }
    }
}
