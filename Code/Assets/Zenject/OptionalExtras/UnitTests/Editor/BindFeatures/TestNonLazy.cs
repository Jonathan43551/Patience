using NUnit.Framework;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestNonLazy : ZenjectUnitTestFixture
    {
        [Test]
        public void Test1()
        {
            Container.Bind<Foo>().AsSingle().NonLazy();

            Assert.Throws(() => Container.Validate());
            Assert.Throws(() => Container.ResolveDependencyRoots());
        }

        [Test]
        public void Test2()
        {
            Container.Bind<Foo>().AsSingle();

            Container.Validate();
            Container.ResolveDependencyRoots();
        }

        [Test]
        public void Test3()
        {
            Container.Bind<Foo>().AsSingle().NonLazy();
            Container.Bind<Bar>().AsSingle();

            Container.Validate();
            Container.ResolveDependencyRoots();
        }

        public class Foo
        {
            public Foo(Bar bar)
            {
            }
        }

        public class Bar
        {
        }
    }
}
