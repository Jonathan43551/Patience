using System;
using System.Collections.Generic;
using Zenject;
using NUnit.Framework;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.BindFeatures
{
    [TestFixture]
    public class TestWithArguments : ZenjectUnitTestFixture
    {
        [Test]
        public void Test1()
        {
            Container.Bind<Foo>().AsTransient().WithArguments(3).NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.Resolve<Foo>().Value, 3);
        }

        [Test]
        public void TestSingleSameArgument()
        {
            Container.Bind<IFoo>().To<Foo>().AsSingle().WithArguments(3).NonLazy();
            Container.Bind<Foo>().AsSingle().WithArguments(3).NonLazy();

            Container.Validate();

            Assert.IsNotNull(Container.Resolve<IFoo>());
            Assert.IsEqual(Container.Resolve<IFoo>(), Container.Resolve<Foo>());
        }

        [Test]
        [ExpectedException]
        public void TestSingleDifferentArguments()
        {
            Container.Bind<IFoo>().To<Foo>().AsSingle().WithArguments(3);
            Container.Bind<Foo>().AsSingle().WithArguments(2);

            Container.Resolve<IFoo>();
        }

        interface IFoo
        {
        }

        class Foo : IFoo
        {
            public Foo(
                int value,
                [InjectOptional]
                string value2)
            {
                Value = value;
            }

            public int Value
            {
                get;
                private set;
            }
        }
    }
}

