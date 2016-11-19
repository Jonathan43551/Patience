using System;
using System.Collections.Generic;
using Zenject;
using NUnit.Framework;
using System.Linq;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Validation
{
    [TestFixture]
    public class TestValidate1 : ZenjectUnitTestFixture
    {
        [Test]
        public void Test1()
        {
            Container.Bind<Foo>().AsSingle().NonLazy();
            Container.Bind<Bar>().AsSingle();

            Container.Validate();
        }

        [Test]
        [ExpectedException]
        public void Test2()
        {
            Container.Bind<Foo>().AsSingle().NonLazy();

            Container.Validate();
        }

        public class Foo
        {
            public Foo(Bar bar)
            {
            }
        }

        public class Bar
        {
        }
    }
}


