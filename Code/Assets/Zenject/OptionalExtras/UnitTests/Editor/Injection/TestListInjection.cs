using System;
using System.Collections.Generic;
using Zenject;
using NUnit.Framework;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Injection
{
    [TestFixture]
    public class TestListInjection : ZenjectUnitTestFixture
    {
        class Test1
        {
            public Test1(List<int> values)
            {
            }
        }

        class Test2
        {
            public Test2( 
                [InjectOptional] List<int> values)
            {
            }
        }

        class Test3
        {
            [Inject]
            public List<int> values = null;
        }

        class Test4
        {
            [InjectOptional]
            public List<int> values = null;
        }

        [Test]
        [ExpectedException]
        public void TestCase1()
        {
            Container.Bind<Test1>().AsSingle();

            Container.ResolveAll<Test1>();
        }

        [Test]
        public void TestCase2()
        {
            Container.Bind<Test2>().AsSingle();

            var result = Container.ResolveAll<Test2>();

            Assert.That(result != null);
        }

        [Test]
        [ExpectedException]
        public void TestCase3()
        {
            Container.Bind<Test3>().AsSingle();

            Container.ResolveAll<Test3>();
        }

        [Test]
        public void TestCase4()
        {
            Container.Bind<Test4>().AsSingle();

            var result = Container.ResolveAll<Test4>();

            Assert.That(result != null);
        }
    }
}



