using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CleverStocker.Utils.DIContainerHelper;

namespace CleverStocker.Utils.Tests
{
    public class BaseModel
    {
        public string Text { get; set; } = string.Empty;
    }

    public class ChildModel : BaseModel
    {
        public int Value { get; set; } = 0;
    }

    public class LiteModel : ChildModel
    {
        public string Name { get; set; } = string.Empty;
    }

    [TestClass()]
    public class DIContainerHelperTests
    {
        // 多个单元测试在同一个命名空间中同时访问静态类将导致冲突，lock 保证线程同步
        object LockSeed = new object();

        [TestMethod()]
        public void RegisteTypeAsTypeTests()
        {
            lock (this.LockSeed)
            {
                // 随时新建
                RegisteTypeAsType<ChildModel, BaseModel>(LifetimeScopes.PerDependency);
                Build();

                Assert.IsInstanceOfType(Resolve<BaseModel>(), typeof(ChildModel));
                Assert.AreNotSame(Resolve<BaseModel>(), Resolve<BaseModel>());
                Clear();

                // 命名单实例
                RegisteTypeAsType<ChildModel, BaseModel>(LifetimeScopes.SingleInstance, "One");
                RegisteTypeAsType<ChildModel, BaseModel>(LifetimeScopes.SingleInstance, "Another");
                Build();

                Assert.IsInstanceOfType(Resolve<BaseModel>("One"), typeof(ChildModel));
                Assert.IsInstanceOfType(Resolve<BaseModel>("Another"), typeof(ChildModel));

                Resolve<BaseModel>("One").Text = "I'm One";
                Resolve<BaseModel>("Another").Text = "I'm Another";

                Assert.AreEqual(Resolve<BaseModel>("One").Text, "I'm One");
                Assert.AreEqual(Resolve<BaseModel>("Another").Text, "I'm Another");
                Assert.IsNull(Resolve<string>());

                Clear();
            }
        }

        [TestMethod()]
        public void RegisteTypeAsTypesTest()
        {
            lock (this.LockSeed)
            {
                // 注册为多个类型
                RegisteTypeAsTypes<LiteModel>(LifetimeScopes.PerDependency, typeof(ChildModel), typeof(BaseModel));
                Build();

                Assert.IsInstanceOfType(Resolve<BaseModel>(), typeof(LiteModel));
                Assert.IsInstanceOfType(Resolve<ChildModel>(), typeof(LiteModel));
                Assert.AreNotSame(Resolve<BaseModel>(), Resolve<ChildModel>());
                Clear();

                // 命名单实例
                RegisteTypeAsTypes<LiteModel>(LifetimeScopes.SingleInstance, typeof(ChildModel), typeof(BaseModel));
                Build();

                Assert.IsInstanceOfType(Resolve<BaseModel>(), typeof(LiteModel));
                Assert.IsInstanceOfType(Resolve<ChildModel>(), typeof(LiteModel));

                Assert.AreSame(Resolve<BaseModel>(), Resolve<ChildModel>());
                Assert.IsNull(Resolve<string>());

                Clear();
            }
        }

        [TestMethod()]
        public void RegisterGenericAsTypeTest()
        {
            lock (this.LockSeed)
            {
                RegisterGenericAsType(typeof(List<>), typeof(IList<>), LifetimeScopes.SingleInstance);
                Build();

                var list = Resolve<IList<ChildModel>>();
                Assert.IsInstanceOfType(list, typeof(List<ChildModel>));

                Enumerable.Range(0, 10).Select(i => new ChildModel()).ToList().ForEach(model => list.Add(model));
                Assert.AreEqual(Resolve<IList<ChildModel>>().Count, 10);

                Clear();
            }
        }

        [TestMethod()]
        public void RegisteInstanceAsTypeTest()
        {
            lock (this.LockSeed)
            {
                RegisteInstanceAsType<ChildModel, BaseModel>(new ChildModel() { Text = "I'm Instance" });
                Build();

                Assert.AreSame(Resolve<BaseModel>(), Resolve<BaseModel>());
                Assert.AreEqual(((BaseModel)Resolve(typeof(BaseModel))).Text, "I'm Instance");

                Clear();
            }
        }

        [TestMethod()]
        public void RegisteInstanceAsTypesTest()
        {
            lock (this.LockSeed)
            {
                RegisteInstanceAsTypes<LiteModel>(new LiteModel() { Text = "I'm Instance" }, typeof(ChildModel), typeof(BaseModel));
                Build();

                Assert.AreSame(Resolve<ChildModel>(), Resolve<BaseModel>());
                Assert.AreEqual(((BaseModel)Resolve(typeof(ChildModel))).Text, "I'm Instance");

                Clear();
            }
        }

        [TestMethod()]
        public void IsRegisteredTest()
        {
            lock (this.LockSeed)
            {
                RegisteInstanceAsTypes<LiteModel>(new LiteModel() { Text = "I'm Instance" }, typeof(ChildModel), typeof(BaseModel));
                Build();

                Assert.IsFalse(IsRegistered(typeof(LiteModel)));
                Assert.IsFalse(IsRegistered<LiteModel>());
                Assert.IsTrue(IsRegistered(typeof(ChildModel)));
                Assert.IsTrue(IsRegistered<ChildModel>());
                Assert.IsTrue(IsRegistered(typeof(BaseModel)));
                Assert.IsTrue(IsRegistered<BaseModel>());

                Clear();
            }
        }

        [TestMethod()]
        public void IsRegisteredWithNameTest()
        {
            lock (this.LockSeed)
            {
                RegisteTypeAsType<LiteModel, ChildModel>(LifetimeScopes.PerDependency, "Lite");
                RegisteTypeAsType<ChildModel, BaseModel>(LifetimeScopes.PerDependency);
                Build();

                Assert.IsTrue(IsRegisteredWithName<ChildModel>("Lite"));
                Assert.IsFalse(IsRegisteredWithName<BaseModel>(string.Empty));

                Clear();
            }
        }
    }
}