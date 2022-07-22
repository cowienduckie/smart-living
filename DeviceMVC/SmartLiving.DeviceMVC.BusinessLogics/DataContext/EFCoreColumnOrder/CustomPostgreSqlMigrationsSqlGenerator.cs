using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;

namespace SmartLiving.DeviceMVC.BusinessLogics.DataContext.EFCoreColumnOrder
{
    public class CustomPostgreSqlMigrationsSqlGenerator : NpgsqlMigrationsSqlGenerator
    {
        public CustomPostgreSqlMigrationsSqlGenerator(
            MigrationsSqlGeneratorDependencies dependencies,
            IMigrationsAnnotationProvider migrationsAnnotations)
            : base(dependencies, migrationsAnnotations, new NpgsqlOptions())
        {
        }

        protected override void CreateTableColumns(CreateTableOperation operation, IModel model,
            MigrationCommandListBuilder builder)
        {
            operation.Columns.Sort(new ColumnOrderComparision());
            base.CreateTableColumns(operation, model, builder);
        }

        private class ColumnOrderComparision : IComparer<AddColumnOperation>
        {
            public int Compare(AddColumnOperation x, AddColumnOperation y)
            {
                var orderX = Convert.ToInt32(x.FindAnnotation(CustomAnnotationNames.ColumnOrder)?.Value ?? 0);
                var orderY = Convert.ToInt32(y.FindAnnotation(CustomAnnotationNames.ColumnOrder)?.Value ?? 0);
                return orderX.CompareTo(orderY);
            }
        }
    }
}