using EPiServer.ContentApi.Cms;
using EPiServer.ContentApi.Core.Serialization;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using System.Web;

namespace Foundation.Features.ContentDeliveryApi
{
    [InitializableModule]
    [ModuleDependency(typeof(ServiceContainerInitialization), typeof(ContentApiCmsInitialization))]
    public class SiteInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Intercept<IContentModelMapper>((locator, defaultModelMapper) =>
                new ExtendedContentModelMapper(
                    defaultModelMapper,
                    locator.GetInstance<ServiceAccessor<HttpContextBase>>())
            );
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}