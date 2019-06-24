using System.Data.Entity;
using CleverStocker.Utils;
using SQLite.CodeFirst;

namespace CleverStocker.DataAccess
{
    /// <summary>
    /// 种子数据
    /// </summary>
    public class DataSeed : SqliteDropCreateDatabaseWhenModelChanges<DBContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataSeed"/> class.
        /// </summary>
        /// <param name="modelBuilder"></param>
        public DataSeed(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        {
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="context"></param>
        public override void InitializeDatabase(DBContext context)
        {
            LogHelper<DBContext>.Debug("初始化数据库 ...");
            base.InitializeDatabase(context);
            LogHelper<DBContext>.Debug("初始化数据库完成");
        }

        /// <summary>
        /// 填充种子数据
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DBContext context)
        {
            LogHelper<DBContext>.Debug("填充种子数据 ...");
            base.Seed(context);
            LogHelper<DBContext>.Debug("填充种子数据完成");
        }
    }
}
