using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Zenject;
using System.Linq;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Other
{
    [TestFixture]
    public class TestValidateInstaller : ZenjectUnitTestFixture
    {
        [Test]
        public void TestBasicSuccess()
        {
            Container.Bind<IFoo>().To<Foo>().AsSingle().NonLazy();
            Container.Bind<Bar>().AsSingle().NonLazy();

            Container.Validate();
        }

        [Test]
        public void TestBasicFailure()
        {
            Container.Bind<IFoo>().To<Foo>().AsSingle().NonLazy();

            Assert.Throws(() => Container.Validate());
        }

        [Test]
        public void TestList()
        {
            Container.Bind<IFoo>().To<Foo>().AsSingle().NonLazy();
            Container.Bind<IFoo>().To<Foo2>().AsSingle().NonLazy();

            Container.Bind<Bar>().AsSingle().NonLazy();

            Container.Bind<Qux>().AsSingle().NonLazy();

            Container.Validate();
        }

        [Test]
        public void TestValidateNestedContainerSuccess()
        {
            var nestedContainer = Container.CreateSubContainer();

            nestedContainer.Bind<Foo>().AsSingle().NonLazy();

            // Should fail without Bar<> bound
            Assert.Throws(() => nestedContainer.Validate());

            Container.Bind<Bar>().AsSingle().NonLazy();

            Container.Validate();
            nestedContainer.Validate();
        }

        [Test]
        public void TestValidateNestedContainerList()
        {
            var nestedContainer = Container.CreateSubContainer();

            Container.Bind<IFoo>().To<Foo>().AsSingle().NonLazy();
            Container.Bind<IFoo>().To<Foo2>().AsSingle().NonLazy();

            Container.Bind<Bar>().AsSingle().NonLazy();

            Container.Validate();

            // Should not throw
            nestedContainer.Resolve<List<IFoo>>();
        }

        interface IFoo
        {
        }

        class Foo : IFoo
        {
            public Foo(Bar bar)
            {
            }
        }

        class Foo2 : IFoo
        {
            public Foo2(Bar bar)
            {
            }
        }

        class Bar
        {
        }

        class Qux
        {
            public Qux(List<IFoo> foos)
            {
            }
        }
    }
}
