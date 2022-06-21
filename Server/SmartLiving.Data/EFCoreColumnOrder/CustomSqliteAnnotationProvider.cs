using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Sqlite.Migrations.Internal;

namespace Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal
{
    public class CustomSqliteAnnotationProvider : SqliteMigrationsAnnotationProvider
    {
        public CustomSqliteAnnotationProvider(MigrationsAnnotationProviderDependencies dependencies)
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