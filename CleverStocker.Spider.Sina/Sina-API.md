## 过去5个交易日平均每分钟成交量

### 请求：

```
https://finance.sina.com.cn/realstock/lastfive/sh600086.js
```

### 响应：

```
var lastfivesh600086 = {"lastfive":[{"d":"2019-06-27","c":"4858.29"},{"d":"2019-06-26","c":"4699.8"},{"d":"2019-06-25","c":"4360.53"},{"d":"2019-06-24","c":"4883.17"},{"d":"2019-06-21","c":"4602.48"}]}
```



## 获取系统时间

### 请求：

```
https://hq.sinajs.cn/?list=sys_time
```

### 响应：

```
var hq_str_sys_time="1561652531";
```



## 获取最近采样数据

### 请求：

```
https://quotes.sina.cn/cn/api/jsonp_v2.php/sh600086/CN_MarketDataService.getKLineData?symbol=sh600086&scale=5&ma=no&datalen=12
```

> **说明：**
>
> 1. 第一个出现的债券代码只是字符串变量，可以随意修改
> 2. symbol 传入股票交易市场和代码
> 3. scale 为采样间隔分钟数，可取 5、10、15、30、60
> 4. datalen 为返回的数据条数，几十、几百、几千 随意

## 响应：

```
sh600086([{
    "day": "2019-06-27 14:05:00",
    "open": "4.470",
    "high": "4.470",
    "low": "4.450",
    "close": "4.460",
    "volume": "732300"
}, {
    "day": "2019-06-27 14:10:00",
    "open": "4.460",
    "high": "4.560",
    "low": "4.460",
    "close": "4.550",
    "volume": "3020600"
}]);
```

> **说明：**
>
> 1. day 时间
> 2. open 开盘价格 (元)
> 3. close 收盘价格 (元)
> 4. high 最高价格 (元)
> 5. low 最低价格 (元)
> 6. volume 成交量 (股)
> 7. 交易所四个小时营业时间，只需要五分钟采样48次即可，满足当天数据



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