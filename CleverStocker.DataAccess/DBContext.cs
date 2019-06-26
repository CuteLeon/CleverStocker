using System.Data.Entity;
using CleverStocker.Model;

namespace CleverStocker.DataAccess
{
    /// <summary>
    /// 数据库交互
    /// </summary>
    public class DBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBContext"/> class.
        /// </summary>
        public DBContext()
            : base("CleverStockerConnect")
        {
            // this.Database.Log = (sql) => CleverStocker.Utils.LogHelper<DBContext>.Trace($"执行SQL=> {sql}");
        }

        /// <summary>
        /// Gets or sets 股票
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
