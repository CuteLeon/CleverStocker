代码规范：
	1. 引用> 分析器> StyleCop.Analyzer Nuget
	2. 规则配置文件：CleverStocker.ruleset
	3. 解决方案资源管理器：
		3.1. 右击项目> 添加> 添加现有项> {找到 CleverStocker.ruleset 文件}> 添加为链接
		3.2. 右击 CleverStocker.ruleset 项> 设置为活动规则集

生成目录：
	..\Build\Debug
	..\Build\Release

注册服务
	Autofac.json> 新建 components 内的 {} 块> 配置 type 和 services
	类型跨多个项目时，type 属性需要指定程序集