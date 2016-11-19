using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestFromGameObject : ZenjectIntegrationTestFixture
    {
        const string GameObjName = "TestObj";

        [Test]
        public void TestBasic()
        {
            Container.Bind<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();
            Container.BindRootResolve<Foo>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
        }

        [Test]
        public void TestSingle()
        {
            Container.Bind<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();
            Container.Bind<IFoo>().To<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();

            Container.BindRootResolve<IFoo>();
            Container.BindRootResolve<Foo>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
        }

        [Test]
        public void TestTransient()
        {
            Container.Bind<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsTransient();
            Container.Bind<IFoo>().To<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsTransient();

            Container.BindRootResolve<IFoo>();
            Container.BindRootResolve<Foo>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 2);
            FixtureUtil.AssertComponentCount<Foo>(Container, 2);
        }

        [Test]
        public void TestCached1()
        {
            Container.Bind<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsCached();
            Container.Bind<IFoo>().To<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsCached();

            Container.BindRootResolve<IFoo>();
            Container.BindRootResolve<Foo>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 2);
            FixtureUtil.AssertComponentCount<Foo>(Container, 2);
        }

        [Test]
        public void TestCached2()
        {
            Container.Bind(typeof(Foo), typeof(IFoo)).To<Foo>().FromGameObject().WithGameObjectName(GameObjName).AsCached();

            Container.BindRootResolve<IFoo>();
            Container.BindRootResolve<Foo>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
        }

        [Test]
        public void TestMultipleConcreteTransient1()
        {
            Container.Bind<IFoo>().To(typeof(Foo), typeof(Bar)).FromGameObject()
                .WithGameObjectName(GameObjName);

            Container.BindRootResolve<IFoo>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 2);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertComponentCount<Bar>(Container, 1);
        }

        [Test]
        public void TestMultipleConcreteTransient2()
        {
            Container.Bind(typeof(IFoo), typeof(IBar)).To(new List<Type>() {typeof(Foo), typeof(Bar)}).FromGameObject()
                .WithGameObjectName(GameObjName).AsTransient();

            Container.BindRootResolve<IFoo>();
            Container.BindRootResolve<IBar>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 4);
            FixtureUtil.AssertComponentCount<Foo>(Container, 2);
            FixtureUtil.AssertComponentCount<Bar>(Container, 2);
        }

        [Test]
        public void TestMultipleConcreteCached()
        {
            Container.Bind(typeof(IFoo), typeof(IBar)).To(new List<Type>() {typeof(Foo), typeof(Bar)}).FromGameObject()
                .WithGameObjectName(GameObjName).AsCached();

            Container.BindRootResolve<IFoo>();
            Container.BindRootResolve<IBar>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 2);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertComponentCount<Bar>(Container, 1);
        }

        [Test]
        public void TestMultipleConcreteSingle()
        {
            Container.Bind(typeof(IFoo), typeof(IBar)).To(new List<Type>() {typeof(Foo), typeof(Bar)}).FromGameObject()
                .WithGameObjectName(GameObjName).AsSingle();

            Container.BindRootResolve<IFoo>();
            Container.BindRootResolve<IBar>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 2);
        }

        public interface IBar
        {
        }

        public interface IFoo
        {
        }

        public class Foo : MonoBehaviour, IFoo, IBar
        {
        }

        public class Bar : MonoBehaviour, IFoo, IBar
        {
        }
    }
}
