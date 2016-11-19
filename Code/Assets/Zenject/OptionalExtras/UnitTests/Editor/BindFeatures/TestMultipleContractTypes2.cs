using System;
using System.Collections.Generic;
using Zenject;
using NUnit.Framework;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.BindFeatures
{
    [TestFixture]
    public class TestMultipleContractTypes2 : ZenjectUnitTestFixture
    {
        public class Bar
        {
        }

        public interface IFoo
        {
        }

        public interface IQux
        {
        }

        public class Foo : IQux, IFoo
        {
        }

        [Test]
        public void Test1()
        {
            var types = new Type[]
            {
                typeof(Bar),
                typeof(Foo),
            };

            Container.Bind(types).AsSingle().NonLazy();

            Container.Validate();

            Container.Resolve<Bar>();
            Container.Resolve<Foo>();
        }

        [Test]
        [ExpectedException]
        public void TestInterfaces()
        {
            Container.Bind<IFoo>().AsSingle().NonLazy();

            Container.Validate();
        }

        [Test]
        public void TestAllInterfaces()
        {
            Container.BindAllInterfaces<Foo>().To<Foo>().AsSingle().NonLazy();

            Container.Validate();

            Assert.IsNull(Container.TryResolve<Foo>());
            Assert.IsNotNull(Container.Resolve<IFoo>());
            Assert.IsNotNull(Container.Resolve<IQux>());
        }

        [Test]
        public void TestAllInterfacesAndSelf()
        {
            Container.BindAllInterfacesAndSelf<Foo>().To<Foo>().AsSingle().NonLazy();

            Container.Validate();

            Assert.IsNotNull(Container.Resolve<Foo>());
            Assert.IsNotNull(Container.Resolve<IFoo>());
            Assert.IsNotNull(Container.Resolve<IQux>());
        }

        [Test]
        [ExpectedException]
        public void TestAllInterfacesMistake()
        {
            Container.BindAllInterfaces<Foo>().AsSingle().NonLazy();
            Container.FlushBindings();

            Container.Validate();

            Assert.IsNotNull(Container.Resolve<IFoo>());
            Assert.IsNotNull(Container.Resolve<IQux>());
        }
    }
}



