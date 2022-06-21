namespace SmartLiving.Domain.DbInfo
{
    public class DbInfo
    {
        public DbInfo(string connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        private string ConnectionStrings { get; }
    }
}