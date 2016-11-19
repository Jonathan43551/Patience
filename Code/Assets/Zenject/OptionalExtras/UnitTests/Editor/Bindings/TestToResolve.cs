using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using NUnit.Framework;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestToResolve : ZenjectUnitTestFixture
    {
        [Test]
        public void TestTransient()
        {
            var foo = new Foo();

            Container.BindInstance(foo).NonLazy();
            Container.Bind<IFoo>().To<Foo>().FromResolve().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.Resolve<IFoo>(), Container.Resolve<Foo>());
            Assert.IsEqual(Container.Resolve<IFoo>(), foo);
        }

        [Test]
        public void TestIdentifier()
        {
            var foo = new Foo();

            Container.Bind<Foo>().WithId("foo").FromInstance(foo).NonLazy();
            Container.Bind<IFoo>().To<Foo>().FromResolve("foo").NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.Resolve<IFoo>(), Container.Resolve<Foo>("foo"));
            Assert.IsEqual(Container.Resolve<IFoo>(), foo);
        }

        [Test]
        public void TestCached()
        {
            Container.Bind<Foo>().AsTransient().NonLazy();

            Container.Bind<IFoo>().To<Foo>().FromResolve().AsCached().NonLazy();

            Container.Validate();

            Assert.IsNotEqual(Container.Resolve<Foo>(), Container.Resolve<Foo>());
            Assert.IsEqual(Container.Resolve<IFoo>(), Container.Resolve<IFoo>());
        }

        [Test]
        public void TestSingle()
        {
            Container.Bind<Foo>().FromInstance(new Foo()).NonLazy();

            Container.Bind<IFoo>().To<Foo>().FromResolve().AsSingle().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.Resolve<IFoo>(), Container.Resolve<IFoo>());
            Assert.IsEqual(Container.Resolve<IFoo>(), Container.Resolve<Foo>());
        }

        [Test]
        [ExpectedException]
        public void TestSingleFailure()
        {
            Container.Bind<Foo>().AsSingle().NonLazy();
            Container.Bind<IFoo>().To<Foo>().FromResolve().AsSingle().NonLazy();

            Container.Validate();

            Container.Resolve<IFoo>();
        }

        [Test]
        public void TestInfiniteLoop()
        {
            Container.Bind<IFoo>().To<IFoo>().FromResolve().AsSingle().NonLazy();

            Assert.Throws(() => Container.Validate());

            Assert.Throws(() => Container.Resolve<IFoo>());
        }

        [Test]
        public void TestResolveManyTransient()
        {
            Container.Bind<Foo>().NonLazy();
            Container.Bind<Foo>().FromInstance(new Foo()).NonLazy();

            Container.Bind<IFoo>().To<Foo>().FromResolve().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.ResolveAll<IFoo>().Count, 2);
        }

        [Test]
        public void TestResolveManyTransient2()
        {
            Container.Bind<Foo>().NonLazy();
            Container.Bind<Foo>().FromInstance(new Foo()).NonLazy();

            Container.Bind(typeof(IFoo), typeof(IBar)).To<Foo>().FromResolve().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.ResolveAll<IFoo>().Count, 2);
            Assert.IsEqual(Container.ResolveAll<IBar>().Count, 2);
        }

        [Test]
        public void TestResolveManyCached()
        {
            Container.Bind<Foo>().NonLazy();
            Container.Bind<Foo>().NonLazy();

            Container.Bind<IFoo>().To<Foo>().FromResolve().AsCached().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.ResolveAll<IFoo>().Count, 2);
            Assert.That(Enumerable.SequenceEqual(Container.ResolveAll<IFoo>(), Container.ResolveAll<IFoo>()));
        }

        [Test]
        public void TestResolveManyCached2()
        {
            Container.Bind<Foo>().NonLazy();
            Container.Bind<Foo>().NonLazy();

            Container.Bind(typeof(IFoo), typeof(IBar)).To<Foo>().FromResolve().AsCached().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.ResolveAll<IBar>().Count, 2);
            Assert.IsEqual(Container.ResolveAll<IFoo>().Count, 2);
            Assert.That(Enumerable.SequenceEqual(Container.ResolveAll<IFoo>().Cast<object>(), Container.ResolveAll<IBar>().Cast<object>()));
        }

        [Test]
        public void TestResolveManyCached3()
        {
            Container.Bind<Foo>().NonLazy();
            Container.Bind<Foo>().NonLazy();

            Container.Bind<IFoo>().To<Foo>().FromResolve().AsCached().NonLazy();
            Container.Bind<IBar>().To<Foo>().FromResolve().AsCached().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.ResolveAll<IFoo>().Count, 2);
            Assert.IsEqual(Container.ResolveAll<IBar>().Count, 2);
            Assert.That(!Enumerable.SequenceEqual(Container.ResolveAll<IFoo>().Cast<object>(), Container.ResolveAll<IBar>().Cast<object>()));
        }

        [Test]
        public void TestResolveManySingle()
        {
            Container.Bind<Foo>().NonLazy();
            Container.Bind<Foo>().NonLazy();

            // This is a bit weird since it's a singleton but matching multiple... but valid
            Container.Bind<IFoo>().To<Foo>().FromResolve().AsSingle().NonLazy();
            Container.Bind<IBar>().To<Foo>().FromResolve().AsSingle().NonLazy();

            Container.Validate();

            Assert.IsEqual(Container.ResolveAll<IFoo>().Count, 2);
            Assert.IsEqual(Container.ResolveAll<IBar>().Count, 2);
            Assert.That(Enumerable.SequenceEqual(Container.ResolveAll<IFoo>().Cast<object>(), Container.ResolveAll<IBar>().Cast<object>()));
        }

        interface IBar
        {
        }

        interface IFoo
        {
        }

        class Foo : IFoo, IBar
        {
        }
    }
}
