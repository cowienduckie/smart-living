using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartLiving.Data.EFCoreColumnOrder
{
    public static class CustomAnnotationNames
    {
        public const string Collation = RelationalAnnotationNames.Prefix + "Collation";
        public const string AlwaysEncrypt = RelationalAnnotationNames.Prefix + "AlwaysEncrypt";
        public const string ColumnOrder = "ColumnOrder";
    }
}