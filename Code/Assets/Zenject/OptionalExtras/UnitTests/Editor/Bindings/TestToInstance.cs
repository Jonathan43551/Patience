using System;
using System.Collections.Generic;
using Zenject;
using NUnit.Framework;
using System.Linq;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestToInstance : ZenjectUnitTestFixture
    {
        [Test]
        public void TestTransient()
        {
            var foo = new Foo();

            Container.Bind<IFoo>().FromInstance(foo).NonLazy();
            Container.Bind<Foo>().FromInstance(foo).NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.Resolve<Foo>(), Container.Resolve<IFoo>());
            Assert.IsEqual(Container.Resolve<Foo>(), foo);
        }

        [Test]
        [ExpectedException]
        public void TestSingle()
        {
            Container.Bind<Foo>().FromInstance(new Foo()).AsSingle().NonLazy();
            Container.Bind<Foo>().AsSingle().NonLazy();

            Container.Validate();

            Container.Resolve<Foo>();
        }

        // There's really no good reason to do this but it is part of the api
        [Test]
        public void TestCached()
        {
            var foo = new Foo();

            Container.Bind<IFoo>().FromInstance(foo).AsCached().NonLazy();
            Container.Bind<Foo>().FromInstance(foo).AsCached().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.Resolve<Foo>(), Container.Resolve<IFoo>());
            Assert.IsEqual(Container.Resolve<Foo>(), foo);
        }

        interface IFoo
        {
        }

        class Foo : IFoo
        {
        }
    }
}

