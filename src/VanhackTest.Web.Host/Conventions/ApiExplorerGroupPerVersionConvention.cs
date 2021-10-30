using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace VanhackTest.Web.Host.Conventions
{
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            //var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.V1"

            var version = controller.Attributes.FirstOrDefault(a => a.GetType() == typeof(ApiVersionAttribute)) as ApiVersionAttribute;
            controller.ApiExplorer.GroupName = "1";

            if (version != null)
                controller.ApiExplorer.GroupName = version.Versions.First().ToString();
        }
    }
}