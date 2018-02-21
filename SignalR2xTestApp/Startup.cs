using System.Configuration;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalR2xTestApp.Startup))]

namespace SignalR2xTestApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var redisConnectionString = ConfigurationManager.AppSettings["redis:connection"];
            if (!string.IsNullOrEmpty(redisConnectionString))
            {
                GlobalHost.DependencyResolver.UseRedis(new RedisScaleoutConfiguration(redisConnectionString, "SignalR2xTestApp"));
            }

            app.MapSignalR();
        }
    }
}
