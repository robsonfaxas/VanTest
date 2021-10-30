using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace VanhackTest.Web.Host.Conventions
{
    public class DefaultRoutePrefixConvention : IApplicationModelConvention
    {
        private readonly string _versionConstraintTemplate;
        private readonly string _versionedControllerTemplate;

        public DefaultRoutePrefixConvention()
        {
            _versionConstraintTemplate = "v{version:apiVersion}";
            _versionedControllerTemplate = $"{_versionConstraintTemplate}/api/services/app/[controller]/[action]";
        }
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                if ((controller.ControllerName == "TokenAuth") || (controller.ControllerName.ToLower().Contains("abp")))
                    continue;

                foreach (var controllerSelector in controller.Selectors)
                {
                    if (controllerSelector.AttributeRouteModel != null)
                    {

                        var versionedConstraintRouteModel = new AttributeRouteModel
                        {
                            Template = _versionConstraintTemplate
                        };

                        controllerSelector.AttributeRouteModel =
                            AttributeRouteModel.CombineAttributeRouteModel(versionedConstraintRouteModel,
                                controllerSelector.AttributeRouteModel);
                    }
                }
            }
        }
    }
}