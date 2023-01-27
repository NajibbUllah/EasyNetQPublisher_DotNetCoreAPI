namespace EasyNetQueueExample.PublisherAPI.Commom
{
    public static class ServiceExtentions
    {

        /// <summary>
        /// RegisterServices into Program.cs
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            try
            {
                //Log.Information("Started RegisterServices");
            }
            catch (Exception ex)
            {
                //Log.Error("Started RegisterServices");
            }
            return services;
        }
    }
}
