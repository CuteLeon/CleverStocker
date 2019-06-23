using System.Data.Entity;
using CleverStocker.Model;

namespace CleverStocker.DataAccess
{
    public class DBContext : DbContext
    {
        /// <summary>
        /// 数据库交互
        /// </summary>
        public DBContext() :
            base("DBConnect")
        {
        }

        /// <summary>
        /// 股票
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// 模型配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new DataSeed(modelBuilder));
        }
    }
}
