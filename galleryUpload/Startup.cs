using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(galleryUpload.Startup))]
namespace galleryUpload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
