using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartLiving.DeviceMVC.BusinessLogics.DataContext.EFCoreColumnOrder
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