using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using ModestTree;
using Assert=ModestTree.Assert;
namespace Zenject.Tests.Factories
{
    [TestFixture]
    public class TestGameObjectFactoryZero : ZenjectIntegrationTestFixture
    {
        const string ResourcePrefix = "TestGameObjectFactoryZero";

        GameObject CubePrefab
        {
            get
            {
                return FixtureUtil.GetPrefab(ResourcePrefix + "/Cube");
            }
        }

        const string GameObjName = "TestObj";

        [Test]
        public void TestGameObjectSelf1()
        {
            Container.BindFactory<GameObject, CubeFactory>().FromGameObject().WithGameObjectName(GameObjName);

            Initialize();

            Container.Resolve<CubeFactory>().Create();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        public void TestGameObjectConcreteSingle()
        {
            Container.BindFactory<UnityEngine.Object, ObjectFactory>().To<GameObject>().FromGameObject().WithGameObjectName(GameObjName);

            Initialize();

            Container.Resolve<ObjectFactory>().Create();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        public void TestPrefabSelfSingle1()
        {
            Container.BindFactory<GameObject, CubeFactory>().FromPrefab(CubePrefab).WithGameObjectName(GameObjName);

            Initialize();

            Container.Resolve<CubeFactory>().Create();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        public void TestPrefabConcreteSingle1()
        {
            Container.BindFactory<UnityEngine.Object, ObjectFactory>().To<GameObject>().FromPrefab(CubePrefab).WithGameObjectName(GameObjName);

            Initialize();

            Container.Resolve<ObjectFactory>().Create();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        public void TestPrefabResourceSelfSingle1()
        {
            Container.BindFactory<GameObject, CubeFactory>()
                .FromPrefabResource(ResourcePrefix + "/Cube").WithGameObjectName(GameObjName);

            Initialize();

            Container.Resolve<CubeFactory>().Create();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        [Test]
        public void TestPrefabResourceConcreteSingle1()
        {
            Container.BindFactory<UnityEngine.Object, ObjectFactory>()
                .To<GameObject>().FromPrefabResource(ResourcePrefix + "/Cube").WithGameObjectName(GameObjName);

            Initialize();

            Container.Resolve<ObjectFactory>().Create();

            FixtureUtil.AssertNumGameObjects(Container, 1);
            FixtureUtil.AssertNumGameObjectsWithName(Container, GameObjName, 1);
        }

        public class ObjectFactory : Factory<UnityEngine.Object>
        {
        }

        public class CubeFactory : Factory<GameObject>
        {
        }
    }
}

