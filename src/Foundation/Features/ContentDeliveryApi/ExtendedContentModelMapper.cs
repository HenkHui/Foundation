using EPiServer.ContentApi.Core.Serialization;
using EPiServer.ContentApi.Core.Serialization.Models;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using System.Collections.Generic;
using System.Web;

namespace Foundation.Features.ContentDeliveryApi
{
    public class ExtendedContentModelMapper : IContentModelMapper
    {
        private readonly IContentModelMapper _defaultContentModelMapper;
        private readonly ServiceAccessor<HttpContextBase> _httpContextAccessor;
        
        public ExtendedContentModelMapper(IContentModelMapper defaultContentModelMapper, ServiceAccessor<HttpContextBase> httpContextAccessor)
        {
           _defaultContentModelMapper = defaultContentModelMapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<IPropertyModelConverter> PropertyModelConverters { get; }

        public ContentApiModel TransformContent(IContent content, bool excludePersonalizedContent = false, string expand = "")
        {
            var contentModel = _defaultContentModelMapper.TransformContent(content, excludePersonalizedContent, expand);

            contentModel.Properties.Add("Custom", new { ComplexString = "Yeah", SubClass = new { SubPropString = "Yeah sub", SubPropInt = 12 } });

            return contentModel;
        }
    }
}