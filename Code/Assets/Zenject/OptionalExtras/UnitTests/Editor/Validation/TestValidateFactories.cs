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
    public class TestValidateFactories : ZenjectUnitTestFixture
    {
        [Test]
        public void Test1()
        {
            Container.BindFactory<Foo, Foo.Factory>();
            Container.Bind<Bar>().AsSingle();

            Container.Validate();
        }

        [Test]
        [ExpectedException]
        public void Test2()
        {
            Container.BindFactory<Foo, Foo.Factory>();

            Container.Validate();
        }

        public class Foo
        {
            public Foo(Bar bar)
            {
            }

            public class Factory : Factory<Foo>
            {
            }
        }

        public class Bar
        {
        }
    }
}
