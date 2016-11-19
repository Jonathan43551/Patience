﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestFromSiblingComponent : ZenjectIntegrationTestFixture
    {
        [Test]
        public void TestBasic()
        {
            Container.Bind<Bar>().FromGameObject().AsSingle().NonLazy();
            Container.Bind<Foo>().FromSiblingComponent();

            Initialize();

            Assert.IsEqual(Container.Resolve<Bar>().gameObject.GetComponents<Foo>().Length, 1);
        }

        [Test]
        [ExpectedException]
        public void TestInvalidUse()
        {
            Container.Bind<Qux>().NonLazy();
            Container.Bind<Foo>().FromSiblingComponent();

            Initialize();
        }

        [Test]
        public void TestBasic2()
        {
            var gameObject = Container.CreateEmptyGameObject("Test");

            Container.Bind<Gorp>().FromComponent(gameObject).AsSingle().NonLazy();
            Container.Bind<Bar>().FromComponent(gameObject).AsSingle().NonLazy();

            Container.Bind<Foo>().FromSiblingComponent();

            Initialize();

            var bar = Container.Resolve<Bar>();
            var gorp = Container.Resolve<Gorp>();

            Assert.IsEqual(bar.gameObject.GetComponents<Foo>().Length, 1);
            Assert.IsEqual(bar.Foo, gorp.Foo);
        }

        public class Qux
        {
            public Qux(Foo foo)
            {
            }
        }

        public class Foo : MonoBehaviour
        {
        }

        public class Bar : MonoBehaviour
        {
            [Inject]
            public Foo Foo;
        }

        public class Gorp : MonoBehaviour
        {
            [Inject]
            public Foo Foo;
        }
    }
}
