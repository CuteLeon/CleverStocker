# 网易财经

## 历史行情

### 请求

```
http://quotes.money.163.com/service/chddata.html?code=0600086&end=20190101&fields=TCLOSE;HIGH;LOW;TOPEN;LCLOSE;CHG;PCHG;TURNOVER;VOTURNOVER;VATURNOVER;TCAP;MCAP
```

> **说明：**
>
> 1. 获取股票从上市到指定结束日期每个交易日的行情数据；
> 2. 省略 end 字段时，将返回至今的全部行情数据
> 3. 可以通过 fields 指定字段

### 响应

> CSV 文件



## 实时资金流向

### 请求

```
http://qt.gtimg.cn/q=ff_sz000858
```

### 响应

> 以 ~ 分割字符串中内容，下标从0开始，依次为：
>  0: 代码
>  1: 主力流入
>  2: 主力流出
>  3: 主力净流入
>  4: 主力净流入/资金流入流出总和
>  5: 散户流入
>  6: 散户流出
>  7: 散户净流入
>  8: 散户净流入/资金流入流出总和
>  9: 资金流入流出总和1+2+5+6
> 10: 未知
> 11: 未知
> 12: 名字
> 13: 日期
