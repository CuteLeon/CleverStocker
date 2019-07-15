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
        public virtual DbSet<Stock> Stocks { get; set; }

        /// <summary>
        /// Gets or sets 报价
        /// </summary>
        public virtual DbSet<Quota> Quotas { get; set; }

        /// <summary>
        /// Gets or sets 大盘指数
        /// </summary>
        public virtual DbSet<MarketQuota> MarketQuotas { get; set; }

        /// <summary>
        /// Gets or sets 公司
        /// </summary>
        public virtual DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets 最近行情
        /// </summary>
        public virtual DbSet<RecentQuota> RecentQuotas { get; set; }

        /// <summary>
        /// 模型配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks>
        /// 为实体配置索引以加快查询速度
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stock>().HasOptional(stock => stock.Company);
            modelBuilder.Entity<Company>().HasRequired(company => company.Stock);

            modelBuilder.Entity<Stock>().HasIndex(stock => new { stock.Code, stock.Market }).HasName($"{nameof(Stock)}_Index").IsUnique();
            modelBuilder.Entity<Company>().HasIndex(company => new { company.Code, company.Market }).HasName($"{nameof(Company)}_Index").IsUnique();
            modelBuilder.Entity<Quota>().HasIndex(quota => new { quota.Code, quota.Market, quota.UpdateTime }).HasName($"{nameof(Quota)}_Index").IsUnique();
            modelBuilder.Entity<RecentQuota>().HasIndex(recentQuota => new { recentQuota.Code, recentQuota.Market, recentQuota.UpdateTime }).HasName($"{nameof(RecentQuota)}_Index").IsUnique();
            modelBuilder.Entity<MarketQuota>().HasIndex(marketQuota => new { marketQuota.Code, marketQuota.Market, marketQuota.UpdateTime }).HasName($"{nameof(MarketQuota)}_Index").IsUnique();

            Database.SetInitializer(new DataSeed(modelBuilder));
        }
    }
}
