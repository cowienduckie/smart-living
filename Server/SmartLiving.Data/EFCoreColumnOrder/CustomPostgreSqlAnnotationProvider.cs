using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;

namespace SmartLiving.Data.EFCoreColumnOrder
{
    public class CustomPostgreSqlAnnotationProvider : NpgsqlMigrationsAnnotationProvider
    {
        public CustomPostgreSqlAnnotationProvider(MigrationsAnnotationProviderDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IEnumerable<IAnnotation> For(IProperty property)
        {
            var baseAnnotations = base.For(property);

            var orderAnnotation = property.FindAnnotation(CustomAnnotationNames.ColumnOrder);

            return orderAnnotation == null
                ? baseAnnotations
                : baseAnnotations.Concat(new[] {orderAnnotation});
        }
    }
}