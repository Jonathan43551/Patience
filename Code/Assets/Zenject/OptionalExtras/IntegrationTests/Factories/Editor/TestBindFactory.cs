using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using ModestTree;
using Assert=ModestTree.Assert;
using Zenject.Tests.Factories.BindFactory;

namespace Zenject.Tests.Factories
{
    [TestFixture]
    public class TestBindFactory : ZenjectIntegrationTestFixture
    {
        GameObject FooPrefab
        {
            get
            {
                return FixtureUtil.GetPrefab("TestBindFactory/Foo");
            }
        }

        GameObject FooSubContainerPrefab
        {
            get
            {
                return FixtureUtil.GetPrefab("TestBindFactory/FooSubContainer");
            }
        }

        [Test]
        public void TestToGameObjectSelf()
        {
            Container.BindFactory<Foo, Foo.Factory>().FromGameObject();

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        [Test]
        [ExpectedException]
        public void TestToGameObjectSelfFail()
        {
            Container.BindFactory<Foo2, Foo2.Factory>().FromGameObject();

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);
        }

        [Test]
        public void TestToGameObjectConcrete()
        {
            Container.BindFactory<IFoo, IFooFactory>().To<Foo>().FromGameObject();

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<IFoo, IFooFactory>(Container);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        [Test]
        public void TestToMonoBehaviourSelf()
        {
            var gameObject = Container.CreateEmptyGameObject("foo");

            Container.BindFactory<Foo, Foo.Factory>().FromComponent(gameObject);

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        [Test]
        [ExpectedException]
        public void TestToMonoBehaviourSelfFail()
        {
            Container.BindFactory<Foo2, Foo2.Factory>().FromComponent((GameObject)null);

            Initialize();
        }

        [Test]
        public void TestToMonoBehaviourConcrete()
        {
            var gameObject = Container.CreateEmptyGameObject("foo");

            Container.BindFactory<IFoo, IFooFactory>().To<Foo>().FromComponent(gameObject);

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<IFoo, IFooFactory>(Container);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        [Test]
        public void TestToPrefabSelf()
        {
            Container.BindFactory<Foo, Foo.Factory>().FromPrefab(FooPrefab).WithGameObjectName("asdf");

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, "asdf", 1);
        }

        [Test]
        [ExpectedException]
        public void TestToPrefabSelfFail()
        {
            // Foo3 is not on the prefab
            Container.BindFactory<Foo3, Foo3.Factory>().FromPrefab(FooPrefab);

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo3, Foo3.Factory>(Container);
        }

        [Test]
        public void TestToPrefabConcrete()
        {
            Container.BindFactory<IFoo, IFooFactory>().To<Foo>().FromPrefab(FooPrefab).WithGameObjectName("asdf");

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<IFoo, IFooFactory>(Container);

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, "asdf", 1);
        }

        [Test]
        public void TestToResourceSelf()
        {
            Container.BindFactory<Texture, Factory<Texture>>()
                .FromResource("TestBindFactory/TestTexture");
            Container.BindRootResolve<Factory<Texture>>();

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Texture, Factory<Texture>>(Container);
        }

        [Test]
        public void TestToResource()
        {
            Container.BindFactory<UnityEngine.Object, Factory<UnityEngine.Object>>()
                .To<Texture>().FromResource("TestBindFactory/TestTexture");
            Container.BindRootResolve<Factory<UnityEngine.Object>>();

            Initialize();
        }

        [Test]
        public void TestToPrefabResourceSelf()
        {
            Container.BindFactory<Foo, Foo.Factory>().FromPrefabResource("TestBindFactory/Foo").WithGameObjectName("asdf");

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, "asdf", 1);
        }

        [Test]
        public void TestToPrefabResourceConcrete()
        {
            Container.BindFactory<Foo, Foo.Factory>().To<Foo>().FromPrefabResource("TestBindFactory/Foo").WithGameObjectName("asdf");

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, "asdf", 1);
        }

        [Test]
        public void TestToSubContainerPrefabSelf()
        {
            Container.BindFactory<Foo, Foo.Factory>().FromSubContainerResolve().ByPrefab(FooSubContainerPrefab);

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        [Test]
        public void TestToSubContainerPrefabConcrete()
        {
            Container.BindFactory<IFoo, IFooFactory>()
                .To<Foo>().FromSubContainerResolve().ByPrefab(FooSubContainerPrefab);

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<IFoo, IFooFactory>(Container);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        [Test]
        public void TestToSubContainerPrefabResourceSelf()
        {
            Container.BindFactory<Foo, Foo.Factory>()
                .FromSubContainerResolve().ByPrefabResource("TestBindFactory/FooSubContainer");

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<Foo, Foo.Factory>(Container);

            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        [Test]
        public void TestToSubContainerPrefabResourceConcrete()
        {
            Container.BindFactory<IFoo, IFooFactory>()
                .To<Foo>().FromSubContainerResolve().ByPrefabResource("TestBindFactory/FooSubContainer");

            Initialize();

            FixtureUtil.CallFactoryCreateMethod<IFoo, IFooFactory>(Container);
            FixtureUtil.AssertComponentCount<Foo>(Container, 1);
            FixtureUtil.AssertNumGameObjects(Container, 1);
        }

        public class Foo3 : MonoBehaviour
        {
            public class Factory : Factory<Foo3>
            {
            }
        }

        public class Foo2 : MonoBehaviour
        {
            [Inject]
            int _value;

            public class Factory : Factory<Foo2>
            {
            }
        }
    }
}
