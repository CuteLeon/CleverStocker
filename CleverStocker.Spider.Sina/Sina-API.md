# Sina-API

> **相关说明：**
>
> 1. 手 = 100 * 股
> 2. 元 = 10000 * 元


## 查询股票

### 请求：

```
http://hq.sinajs.cn/list=sh601003,sh601001
```

> **说明：**
>
> 1. 股票代码为交易所简称加代码；
> 2. 多支股票代码用 ',' 分割；

### 响应：

```js
var hq_str_sh601006="大秦铁路, 27.55, 27.25, 26.91, 27.55, 26.20, 26.91, 26.92, 22114263, 589824680, 4695, 26.91, 57590, 26.90, 14700, 26.89, 14300, 26.88, 15100, 26.87, 3100, 26.92, 8900, 26.93, 14230, 26.94, 25150, 26.95, 15220, 26.96, 2008-01-11, 15:05:32";
```

> **说明：**
>
> | 序号： | 值：       | 说明：                                   |
> | ------ | ---------- | ---------------------------------------- |
> | 0      | 大秦铁路   | 股票名字                                 |
> | 1      | 27.55      | 今日开盘价                               |
> | 2      | 27.25      | 昨日收盘价                               |
> | 3      | 26.91      | 当前价格                                 |
> | 4      | 27.55      | 今日最高价                               |
> | 5      | 26.20      | 今日最低价                               |
> | 6      | 26.91      | 竞买价，“买一”报价                       |
> | 7      | 26.92      | 竞卖价，“卖一”报价                       |
> | 8      | 22114263   | 成交的股票数(股)                         |
> | 9      | 589824680  | 成交金额(元)                             |
> | 10~19  | ——         | (股数,报价) in (买一 to 买五) (五档盘口) |
> | 20~29  | ——         | (股数,报价) in (卖一 to 卖五) (五档盘口) |
> | 30     | 2008-01-11 | 数据刷新日期                             |
> | 31     | 15:05:32   | 数据刷新时间                             |
>

## 大盘指数

### 请求：

```
http://hq.sinajs.cn/list=s_sh000001,s_sz399001,s_sz300748
```

> **说明：**
>
> 1. 股票代码为 "s_" 加交易所简称加代码；
> 2. 多支股票代码用 ',' 分割；

### 响应：

```js
var hq_str_s_sh000001="上证指数,3094.668,-128.073,-3.97,436653,5458126";
```
> **说明：**
> | 序号： | 值：     | 说明：       |
> | ------ | -------- | ------------ |
> | 0      | 上证指数 | 指数名称     |
> | 1      | 3094.668 | 当前点数     |
> | 2      | -128.073 | 当前价格     |
> | 3      | -3.97    | 涨跌率       |
> | 4      | 436653   | 成交量(手)   |
> | 5      | 5458126  | 成交额(万元) |
>



## 图像

### 分时线

```
http://image.sinajs.cn/newchart/min/n/sh000001.gif
```

### 日K线

```
http://image.sinajs.cn/newchart/daily/n/sh601006.gif
```

### 周K线

```
http://image.sinajs.cn/newchart/weekly/n/sh000001.gif
```

### 月K线

```
http://image.sinajs.cn/newchart/monthly/n/sh000001.gif
```

> **说明：**
>
> 1. 股票代码为交易所简称加代码；



## 公司信息

### 请求：

```
http://vip.stock.finance.sina.com.cn/corp/go.php/vCI_CorpInfo/stockid/600086.phtml
```



## 逐笔/大单 交易

### 请求：

```
// 逐笔
https://vip.stock.finance.sina.com.cn/quotes_service/view/CN_TransListV2.php?num=11&symbol=sh600086
// 大单
https://vip.stock.finance.sina.com.cn/quotes_service/view/CN_BillList.php?sort=ticktime&symbol=sh600086&num=11
```

### 响应：

```
var trade_item_list = new Array(); 
trade_item_list[0] = new Array('13:25:44', '22600', '4.530', 'DOWN'); 
trade_item_list[1] = new Array('13:25:42', '5000', '4.540', 'DOWN'); 
trade_item_list[2] = new Array('13:25:39', '56000', '4.550', 'UP'); 
trade_item_list[3] = new Array('13:25:35', '100', '4.540', 'UP'); 
trade_item_list[4] = new Array('13:25:33', '3000', '4.530', 'DOWN'); 
trade_item_list[5] = new Array('13:25:30', '11500', '4.530', 'DOWN'); 
trade_item_list[6] = new Array('13:25:26', '100', '4.540', 'UP'); 
trade_item_list[7] = new Array('13:25:24', '2200', '4.540', 'UP'); 
trade_item_list[8] = new Array('13:25:21', '700', '4.540', 'DOWN'); 
trade_item_list[9] = new Array('13:25:15', '48800', '4.550', 'UP'); 
trade_item_list[10] = new Array('13:25:12', '5400', '4.540', 'UP'); 
var trade_INVOL_OUTVOL=[49401217.5,58606762.5];
```

> **说明：**
>
> 1. 每个元素：时间、交易量（股）、价格、方向（UP=买入，DOWN=卖出）



## 分价

### 请求：

```
https://vip.stock.finance.sina.com.cn/quotes_service/view/cn_price_list.php?&symbol=sh600086&num=11
```

### 响应：

```
var price_statist_list = new Array();
 price_statist_list[0] = new Array('4.600', '7500397', '6.94%');
 price_statist_list[1] = new Array('4.560', '6524406', '6.04%');
 price_statist_list[2] = new Array('4.500', '5894400', '5.45%');
 price_statist_list[3] = new Array('4.610', '5782835', '5.35%');
 price_statist_list[4] = new Array('4.590', '5724000', '5.30%');
 price_statist_list[5] = new Array('4.540', '5095413', '4.71%');
 price_statist_list[6] = new Array('4.620', '5020703', '4.65%');
 price_statist_list[7] = new Array('4.700', '4743998', '4.39%');
 price_statist_list[8] = new Array('4.750', '4305403', '3.98%');
 price_statist_list[9] = new Array('4.690', '3992511', '3.69%');
 price_statist_list[10] = new Array('4.730', '3943900', '3.65%');
```

> **说明：**
>
> 1. 每个元素：成交价（元）、成交量（股）、占比（%）



## 分时

### 请求：

```
https://vip.stock.finance.sina.com.cn/quotes_service/view/vML_DataList.php?asc=j&symbol=sh600086&num=11
```

### 响应：

```
var minute_data_list = [['13:29:00', '4.52', '126500'],['13:28:00', '4.51', '205300'],['13:27:00', '4.53', '179000'],['13:26:00', '4.53', '65700'],['13:25:00', '4.54', '175000'],['13:24:00', '4.55', '181400'],['13:23:00', '4.55', '145300'],['13:22:00', '4.54', '225400'],['13:21:00', '4.54', '95000'],['13:20:00', '4.54', '124800'],['13:19:00', '4.54', '170200']];
```

> **说明：**
>
> 1. 每个元素：时间、成交价（元）、成交量（股）