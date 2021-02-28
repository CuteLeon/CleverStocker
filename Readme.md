<div align=center>

![](https://raw.github.com/CuteLeon/CleverStocker/master/CleverStocker.Client/Resources/bull.png)

</div>

# Clever Stocker

## UML

<div align=center>

![](https://raw.github.com/CuteLeon/CleverStocker/master/Documents/UML.png)

</div>



## Technology Stack:

1. UI: **DockPanelSuite 3.0.6**
2. UnitTest：**MSTest 1.4.0**
3. O/RM: **Entity Framework 6.2.0**
4. IoC: **Autofac 4.9.2**
5. HTML-Parsing: **HtmlAgilityPack 1.11.8**
6. Mocking: **Moq 4.12.0**
7. Log: **NLog 4.6.5**
8. DB: **SQLite (CodeFirst) 1.0.111**
9. CodingStandards: **StyleCop.Analyzers 1.1.118**
10. MultiThreading/DataFlow: **TPL 4.9.0**
11. MQ: **ZeroMQ 4.1.0.31**
12. Spider: **正则表达式**



## Features:

1. 内部所有停靠**窗体和服务采用 DI 容器 (Autofac) 托管**，任何需要引用的地方，只需要使用 DI 容器获取即可，在使用时不需要关心被托管的服务的生命周期，只需要在注册时设定生命周期；
2. 停靠**窗口之间通信使用 MQ Pub/Sub 模式实现**，避免窗体之间的强耦合，任何窗体的消息和事件一律通过 MQ 广播出去，由特定的窗口订阅相关主题并选择处理；



## Screen:


![](https://raw.github.com/CuteLeon/CleverStocker/master/Documents/Screen_1.png)

![](https://raw.github.com/CuteLeon/CleverStocker/master/Documents/Screen_2.png)

![](https://raw.github.com/CuteLeon/CleverStocker/master/Documents/Screen_3.png)

