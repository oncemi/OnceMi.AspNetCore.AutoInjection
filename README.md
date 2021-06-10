# OnceMi.AspNetCore.AutoInjection

1. 安装

   通过Nuget安装：[![](https://img.shields.io/nuget/v/OnceMi.AspNetCore.AutoInjection.svg)](https://www.nuget.org/packages/OnceMi.AspNetCore.AutoInjection)

2. 配置注入

   在```Startup```中的```ConfigureServices```中配置服务：

   ```c#
	public void ConfigureServices(IServiceCollection services)
	{
		//配置自动注入
		services.AddAutoInjection();

		services.AddControllersWithViews();
	}
   ```

3. 使用

   在需要注入的类中，使用```AutoInjection```标记，自动注册服务会通过反射自动将有此特性的类注册到DI容器中：

   ```c#
	[AutoInjection(typeof(ITestService), InjectionType.Singleton)]
	public class TestServiceC : ITestService
	{
		private readonly ILogger<TestServiceC> _logger;

		public TestServiceC(ILogger<TestServiceC> logger)
		{
			_logger = logger;
		}

		public void Test()
		{
			_logger.LogInformation($"This is {this.GetType().Name} inject by AutoInjection.");
		}
	}
   ```

4. 说明
	```AutoInjectionAttribute```有四种构造方式：

	|  属性 | 说明  | 生命周期  |
	| ------------ | ------------ |------------ |
	| [AutoInjection]  | 默认方式，不包含接口，直接注入当前类  | Scoped |
	| [AutoInjection(typeof(ITestService))]  | 接口注入，注入指定的接口，当前类需要是指定接口的实现类  | Scoped |
	| [AutoInjection(InjectionType.Singleton)]  | 不包含接口，直接注入当前类  | 指定的生命周期（Singleton） |
	| [AutoInjection(typeof(ITestService), InjectionType.Singleton)]  | 接口注入，注入指定的接口，当前类需要是指定接口的实现类  | 指定的生命周期（Singleton） |

   

