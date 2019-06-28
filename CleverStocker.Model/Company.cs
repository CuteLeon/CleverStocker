using System;
using System.ComponentModel.DataAnnotations;

namespace CleverStocker.Model
{
    /// <summary>
    /// 公司
    /// </summary>
    public class Company : ICopyable<Company>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Company"/> class.
        /// </summary>
        public Company()
        {
        }

        /// <summary>
        /// Gets or sets iD
        /// </summary>
        [Key]
        [Required]
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// Gets or sets 评级
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets 投票
        /// </summary>
        public int Vote { get; set; }

        /// <summary>
        /// Gets or sets 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets 位置
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets 概要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets 行业
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// Gets or sets 简介
        /// </summary>
        public string Brief { get; set; }

        /// <summary>
        /// Gets or sets 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="entity"></param>
        public void CopyTo(Company entity)
        {
            if (entity == null)
            {
                entity = new Company();
            }

            entity.Brief = this.Brief;
            entity.Industry = this.Industry;
            entity.Name = this.Name;
            entity.Position = this.Position;
            entity.Rank = this.Rank;
            entity.Status = this.Status;
            entity.Summary = this.Summary;
            entity.UpdateTime = this.UpdateTime;
            entity.Vote = this.Vote;
        }
    }
}
