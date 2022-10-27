using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace WebApplication3.Entites
{
    public static class EdmModel
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            return builder.GetEdmModel();
        }
    }
}
