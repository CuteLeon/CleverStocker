## 债券信息：

### 请求：

```
https://finance.sina.com.cn/otc/activity/sh600086_info.js
```

### 响应：

```
var dongmi_info = {"id":"sh600086","stock":"sh600086","rank":1465,"vote":0,"ok":0,"nor":0,"name":"\u5b8b\u5b5d\u521a","position":"\u4e1c\u65b9\u91d1\u94b0","summary":"\u5b8b\u5b5d\u521a\uff0c\u7537\uff0c\u6c49\u65cf\uff0c1956\u5e7412\u6708\u51fa\u751f\uff0c\u4e2d\u5171\u515a\u5458\uff0c\u5927\u4e13\u6587\u5316\uff0c\u4f1a\u8ba1\u5e08\u3002\u66fe\u4efb\u89e3\u653e\u519b\u67d0\u90e8\u6218\u58eb\u3001\u6392\u957f\u3001\u526f\u8fde\u957f\u3001\u4f1a\u8ba1\uff0c\u6df1\u5733\u53d1\u5c55\u94f6\u884c\u7f57\u6e56\u5206\u7406\u5904\u4e3b\u4efb\uff0c1988\u5e74\u81f32012\u5e744\u6708\u4efb\u6df1\u5733\u5e02\u57ce\u5e02\u5efa\u8bbe\u5f00\u53d1\uff08\u96c6\u56e2\uff09\u516c\u53f8\u8d22\u52a1\u90e8\u526f\u90e8\u957f\u3001\u90e8\u957f\uff0c\u6df1\u5733\u4e16\u7eaa\u661f\u6e90\u80a1\u4efd\u6709\u9650\u516c\u53f8\u8463...","corp_brief":"    \u516c\u53f8\u7cfb\u7531\u539f\u9102\u5dde\u5e02\u670d\u88c5\u603b\u5382\u7b49\u4e8e1993\u5e744\u67082\u65e5\u5171\u540c\u53d1\u8d77\u8bbe\u7acb,\u4ee5\u5176\u7ecf\u8425\u6027\u51c0\u8d44\u4ea7\u6298\u53d1\u8d77\u4eba\u80a12860\u4e07\u80a1,\u5e76\u5b9a\u5411\u52df\u96c6\u804c\u5de5\u80a1300\u4e07\u80a1,1995\u5e746\u6708\u53ca10\u6708\u5206\u522b\u630910:3\u6bd4\u4f8b\u8fdb\u884c\u914d\u80a1\u548c\u8f6c\u589e\u80a1\u672c,1996\u5e743\u6708\u630910:4.5\u53ca10:1\u6bd4\u4f8b\u8fdb\u884c\u9001\u80a1\u548c\u8f6c\u589e,\u7ecf1997\u5e745\u670822\u65e5\u53d1\u884c\u540e,\u4e0a\u5e02\u65f6\u603b\u80a1\u672c\u8fbe11595.99\u4e07\u80a1,\u5176\u804c\u5de5\u80a1816.075\u4e07\u80a1\u5c06\u4e8e\u516c\u4f17\u80a13000\u4e07\u80a11997\u5e746\u67086\u65e5\u5728\u4e0a\u4ea4\u6240\u4e0a\u5e02\u4ea4\u6613\u671f\u6ee1\u4e09\u5e74\u540e\u4e0a\u5e02\u3002","industry":"\u5bb6\u7528\u8f7b\u5de5","pic":"","status":"0","ir_index":"12","research":"--","sharepic":"http:\/\/n.sinaimg.cn\/finance\/798\/w416h382\/20190611\/0296-hyeztys8769891.png"}
/* b+l+FG3NaRskImRavcvwfxUha1WKIQFis9imYY42BWNDVB/to4JMbuB+wtEThop4i3HRPmTkwQtp/w7p+PdSJNCrWIR+UQKOdhzliQamS9c2ELeJ94z8cbLQ8jl1yfVmPqmpxKWrt0mXUT+hu3hGqQPvRSsGAPJt/fbRaM7MwU/crOVFlkZIxCsmV94WTjtjii654VHV+gYBpDKhPG8Vbrhzn1g= */
```

> **注意：**
>
> 1. 内容需要 Unicode 转中文



## 过去5个交易日平均每分钟成交量

### 请求：

```
https://finance.sina.com.cn/realstock/lastfive/sh600086.js
```

### 响应：

```
var lastfivesh600086 = {"lastfive":[{"d":"2019-06-27","c":"4858.29"},{"d":"2019-06-26","c":"4699.8"},{"d":"2019-06-25","c":"4360.53"},{"d":"2019-06-24","c":"4883.17"},{"d":"2019-06-21","c":"4602.48"}]}
/* KQHmMaA5Kl5FlWMiP+qhrKwIXADUnxFQqnruhBmj6NwjM7tfaCH/O4cWiIJ2DDO8NVP0E7+JTGpaEI/6U9kRfQtFMu2ScaBJzV+KrK1N5t8ygnpleZsZCAXLKgGIjossg+t93YA8nqR3jhFbzTasqdrC2R7OoyRB/fX6G171jZ5UTSKcVaNyMaykRAiTn+nHp5Jnzdmvkts= */
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