using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartLiving.Data.EFCoreColumnOrder;

namespace Microsoft.EntityFrameworkCore
{
    public static class CustomPropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> HasColumnOrder<TProperty>(
            this PropertyBuilder<TProperty> propertyBuilder, int order)
        {
            propertyBuilder.HasAnnotation(CustomAnnotationNames.ColumnOrder, order);
            return propertyBuilder;
        }
    }
}