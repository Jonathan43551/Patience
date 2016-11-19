using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using ModestTree;
using Assert=ModestTree.Assert;
using Zenject.Tests.Bindings.FromPrefab;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestFromPrefab : ZenjectIntegrationTestFixture
    {
        GameObject FooPrefab
        {
            get
            {
                return GetPrefab("Foo");
            }
        }

        GameObject FooPrefab2
        {
            get
            {
                return GetPrefab("Foo2");
            }
        }

        GameObject GorpAndQuxPrefab
        {
            get
            {
                return GetPrefab("GorpAndQux");
            }
        }

        GameObject NorfPrefab
        {
            get
            {
                return GetPrefab("Norf");
            }
        }

        GameObject JimAndBobPrefab
        {
            get
            {
                return GetPrefab("JimAndBob");
            }
        }

        [Test]
        public void TestTransient()
        {
            Container.Bind<Foo>().FromPrefab(FooPrefab).AsTransient();
            Container.Bind<Foo>().FromPrefab(FooPrefab).AsTransient();

            Container.BindRootResolve<Foo>();

            Initialize();

            FixtureUtil.AssertComponentCount<Foo>(Container, 2);
        }

        [Test]
        public void TestSingle()
        {
            Container.Bind<IFoo>().To<Foo>().FromPrefab(FooPrefab).AsSingle().NonLazy();
            Container.Bind<Foo>().FromPrefab(FooPrefab).AsSingle().NonLazy();

            Initialize();

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
        }

        [Test]
        public void TestSingle2()
        {
            // For ToPrefab, the 'AsSingle' applies to the prefab and not the type, so this is valid
            Container.Bind<IFoo>().To<Foo>().FromPrefab(FooPrefab).AsSingle();
            Container.Bind<Foo>().FromPrefab(FooPrefab2).AsSingle();
            Container.Bind<Foo>().FromMethod(ctx => ctx.Container.CreateEmptyGameObject("Foo").AddComponent<Foo>());

            Container.BindRootResolve<Foo>();
            Container.BindRootResolve<IFoo>();

            Initialize();

            FixtureUtil.AssertComponentCount<Foo>(Container, 3);
            FixtureUtil.AssertNumGameObjects(Container, 3);
        }

        [Test]
        public void TestSingleIdentifiers()
        {
            Container.Bind<Foo>().FromPrefab(FooPrefab).WithGameObjectName("Foo").AsSingle().NonLazy();
            Container.Bind<Bar>().FromPrefab(FooPrefab).WithGameObjectName("Foo").AsSingle().NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertComponentCount<Bar>(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, "Foo", 1);
        }

        [Test]
        public void TestCached1()
        {
            Container.Bind(typeof(Foo), typeof(Bar)).FromPrefab(FooPrefab).WithGameObjectName("Foo").AsCached().NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertComponentCount<Bar>(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, "Foo", 1);
        }

        [Test]
        [ExpectedException]
        public void TestWithArgumentsFail()
        {
            // They have required arguments
            Container.Bind(typeof(Gorp), typeof(Qux)).FromPrefab(GorpAndQuxPrefab).AsCached().NonLazy();

            Initialize();
        }

        [Test]
        public void TestWithArguments()
        {
            Container.Bind(typeof(Gorp), typeof(Qux))
                .FromPrefab(GorpAndQuxPrefab).WithGameObjectName("GorpAndQux").AsCached()
                .WithArguments(5, "test1").NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertComponentCount<Gorp>(Container, 1);
            FixtureUtil.AssertComponentCount<Qux>(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, "GorpAndQux", 1);
        }

        [Test]
        public void TestWithAbstractSearch()
        {
            // There are three components that implement INorf on this prefab
            // and so this should result in a list of 3 INorf's
            Container.Bind<INorf>().FromPrefab(NorfPrefab).NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertComponentCount<INorf>(Container, 3);
            FixtureUtil.AssertResolveCount<INorf>(Container, 3);
        }

        [Test]
        public void TestAbstractBindingConcreteSearch()
        {
            // Should ignore the Norf2 component on it
            Container.Bind<INorf>().To<Norf>().FromPrefab(NorfPrefab).NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertResolveCount<INorf>(Container, 2);
        }

        [Test]
        public void TestCircularDependencies()
        {
            // Jim and Bob both depend on each other
            Container.Bind(typeof(Jim), typeof(Bob)).FromPrefab(JimAndBobPrefab).AsCached().NonLazy();
            Container.BindAllInterfaces<JimAndBobRunner>().To<JimAndBobRunner>().AsSingle().NonLazy();

            Initialize();
        }

        GameObject GetPrefab(string name)
        {
            return FixtureUtil.GetPrefab("TestFromPrefab/{0}".Fmt(name));
        }

        public class JimAndBobRunner : IInitializable
        {
            readonly Bob _bob;
            readonly Jim _jim;

            public JimAndBobRunner(Jim jim, Bob bob)
            {
                _bob = bob;
                _jim = jim;
            }

            public void Initialize()
            {
                Assert.IsNotNull(_jim.Bob);
                Assert.IsNotNull(_bob.Jim);

                Log.Info("Jim and bob successfully got the other reference");
            }
        }
    }
}
