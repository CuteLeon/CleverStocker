using System;
using System.Data.Entity;
using CleverStocker.Model;
using CleverStocker.Utils;
using SQLite.CodeFirst;
using static CleverStocker.Common.CommonStandard;

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

            context.Stocks.AddRange(new[]
            {
                new Stock("000001", Markets.ShangHai, "上证指数")
                {
                     IsSelfSelect = true,
                },
                new Stock("399001", Markets.ShenZhen, "深证成指")
                {
                     IsSelfSelect = true,
                },
                new Stock("399006", Markets.ShenZhen, "创业板指")
                {
                     IsSelfSelect = true,
                },
            });
            context.SaveChanges();

            LogHelper<DBContext>.Debug("填充种子数据完成");
        }
    }
}
