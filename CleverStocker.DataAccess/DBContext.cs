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
            // this.Database.Log = (sql) => Utils.LogHelper<DBContext>.Trace($"执行SQL=> {sql}");
        }

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        public DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// Gets or sets 报价
        /// </summary>
        public DbSet<Quota> Quotas { get; set; }

        /// <summary>
        /// Gets or sets 大盘指数
        /// </summary>
        public DbSet<MarketQuota> MarketQuotas { get; set; }

        /// <summary>
        /// Gets or sets 公司
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets 最近行情
        /// </summary>
        public DbSet<RecentQuota> RecentQuotas { get; set; }

        /// <summary>
        /// Gets or sets 交易
        /// </summary>
        public DbSet<Trade> Trades { get; set; }

        /// <summary>
        /// 模型配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>().HasIndex(stock => new { stock.Market, stock.Code }).IsUnique();

            Database.SetInitializer(new DataSeed(modelBuilder));
        }
    }
}
