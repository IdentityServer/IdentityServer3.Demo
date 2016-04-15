using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dispatcher;

namespace AzureWebSitesDeployment.Api
{
    class TypeResolver : IHttpControllerTypeResolver
    {
        private readonly IEnumerable<Type> _types;

        public TypeResolver(params Type[] types)
        {
            _types = types;
        }

        public ICollection<Type> GetControllerTypes(IAssembliesResolver _)
        {
            return _types.ToList();
        }
    }
}