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
    public class TestBindGameObject : ZenjectIntegrationTestFixture
    {
        const string GameObjName = "TestObj";

        GameObject CubePrefab
        {
            get
            {
                return (GameObject)Resources.Load("TestBindGameObject/Cube");
            }
        }

        [Test]
        public void TestGameObjectSelfSingle1()
        {
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();
            Container.BindRootResolve<GameObject>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        public void TestGameObjectSelfSingle2()
        {
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();
            Container.Bind<GameObject>().WithId("asdf").FromGameObject().WithGameObjectName(GameObjName).AsSingle();

            Container.BindRootResolve<GameObject>();
            Container.BindRootResolve<GameObject>("asdf");

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        [ExpectedException]
        public void TestGameObjectSelfSingleConflict()
        {
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName("asdf").AsSingle();

            Container.BindRootResolve<GameObject>();

            Initialize();
        }

        [Test]
        public void TestGameObjectSelfTransient()
        {
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName(GameObjName).AsTransient();
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName(GameObjName).AsTransient();
            Container.Bind<GameObject>().FromGameObject().WithGameObjectName("asdf").AsTransient();
            Container.BindRootResolve<GameObject>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 3);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 2);
        }

        [Test]
        public void TestGameObjectConcreteSingle()
        {
            Container.Bind<UnityEngine.Object>().To<GameObject>().FromGameObject().WithGameObjectName(GameObjName).AsSingle();

            Container.BindRootResolve<UnityEngine.Object>();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        public void TestPrefabSelfSingle1()
        {
            Container.Bind<GameObject>().FromPrefab(CubePrefab)
                .WithGameObjectName(GameObjName).AsSingle().NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);

            Assert.IsNotNull(Container.Resolve<GameObject>().GetComponent<BoxCollider>());
        }

        [Test]
        public void TestPrefabConcreteSingle1()
        {
            Container.Bind<UnityEngine.Object>().To<GameObject>()
                .FromPrefab(CubePrefab).WithGameObjectName(GameObjName).AsSingle().NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);

            Assert.IsNotNull(((GameObject)Container.Resolve<UnityEngine.Object>()).GetComponent<BoxCollider>());
        }

        [Test]
        public void TestPrefabResourceSelfSingle1()
        {
            Container.Bind<GameObject>().FromPrefabResource("TestBindGameObject/Cube").WithGameObjectName(GameObjName).AsSingle().NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);

            Assert.IsNotNull(Container.Resolve<GameObject>().GetComponent<BoxCollider>());
        }

        [Test]
        public void TestPrefabResourceConcreteSingle1()
        {
            Container.Bind<UnityEngine.Object>().To<GameObject>()
                .FromPrefabResource("TestBindGameObject/Cube").WithGameObjectName(GameObjName).AsSingle().NonLazy();

            Initialize();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);

            Assert.IsNotNull(((GameObject)Container.Resolve<UnityEngine.Object>()).GetComponent<BoxCollider>());
        }
    }
}
