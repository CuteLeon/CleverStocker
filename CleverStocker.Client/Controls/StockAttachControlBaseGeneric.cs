using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CleverStocker.Model;
using CleverStocker.Utils;

namespace CleverStocker.Client.Controls
{
    /// <summary>
    /// 泛型股票附加数据控件
    /// </summary>
    /// <typeparam name="TAttachEntity">附加实体类型</typeparam>
    public class StockAttachControlBaseGeneric<TAttachEntity> : UserControl, IStockAttachControlBaseGeneric<TAttachEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StockAttachControlBaseGeneric{TAttachEntity}"/> class.
        /// </summary>
        public StockAttachControlBaseGeneric()
            : base()
        {
        }

        #region 属性

        /// <summary>
        /// 标签前景色
        /// </summary>
        private Color labelForecolor;

        /// <summary>
        /// Gets or sets 标签前景色
        /// </summary>
        [Browsable(true)]
        public virtual Color LabelForecolor
        {
            get => this.labelForecolor;
            set
            {
                this.labelForecolor = value;

                this.InvokeIfRequired<ValueType, Action<Color>>(this.SetLabelForecolor, value);
            }
        }

        /// <summary>
        /// 值前景色
        /// </summary>
        private Color valueForecolor;

        /// <summary>
        /// Gets or sets 值前景色
        /// </summary>
        [Browsable(true)]
        public virtual Color ValueForecolor
        {
            get => this.valueForecolor;
            set
            {
                this.valueForecolor = value;

                this.InvokeIfRequired<ValueType, Action<Color>>(this.SetValueForecolor, value);
            }
        }

        /// <summary>
        /// 股票
        /// </summary>
        private Stock stock;

        /// <summary>
        /// Gets or sets 股票
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Stock Stock
        {
            get => this.stock;
            set
            {
                this.stock = value;

                this.InvokeIfRequired<ValueType, Action<Stock>>(this.StockToFace, value);
            }
        }

        /// <summary>
        /// 附加实体
        /// </summary>
        private TAttachEntity attachEntity;

        /// <summary>
        /// Gets or sets 附加实体
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TAttachEntity AttachEntity
        {
            get => this.attachEntity;
            set
            {
                this.attachEntity = value;

                this.InvokeIfRequired<ValueType, Action<TAttachEntity>>(this.AttachEntityToFace, value);
            }
        }
        #endregion

        /// <summary>
        /// 设置标签控件颜色
        /// </summary>
        /// <param name="obj"></param>
        public virtual void SetLabelForecolor(Color obj)
        {
        }

        /// <summary>
        /// 设置数据控件颜色
        /// </summary>
        /// <param name="obj"></param>
        public virtual void SetValueForecolor(Color obj)
        {
        }

        /// <summary>
        /// 显示股票信息
        /// </summary>
        /// <param name="obj"></param>
        public virtual void StockToFace(Stock obj)
        {
        }

        /// <summary>
        /// 显示附加实体信息
        /// </summary>
        /// <param name="entity"></param>
        public virtual void AttachEntityToFace(TAttachEntity entity)
        {
        }
    }
}
