using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ModestTree;
using Assert=ModestTree.Assert;
using Zenject;

namespace Zenject.Tests
{
    [TestFixture]
    public class TestCommandsOne : ZenjectUnitTestFixture
    {
        [Test]
        public void TestToSingle1()
        {
            Bar.Value = null;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsSingle();

            Container.BindCommand<DoSomethingCommand, string>()
                .To<Bar>(x => x.Execute).AsSingle();

            Container.Resolve<Bar>();
            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsEqual(Bar.InstanceCount, 1);
            Assert.IsNull(Bar.Value);

            cmd.Execute("asdf");

            Assert.IsEqual(Bar.Value, "asdf");
            Assert.IsEqual(Bar.InstanceCount, 1);
        }

        [Test]
        public void TestToTransient1()
        {
            Bar.Value = null;
            Bar.InstanceCount = 0;

            Container.BindCommand<DoSomethingCommand, string>()
                .To<Bar>(x => x.Execute).AsTransient();

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsEqual(Bar.InstanceCount, 0);
            Assert.IsNull(Bar.Value);

            cmd.Execute("asdf");

            Assert.IsEqual(Bar.Value, "asdf");
            Assert.IsEqual(Bar.InstanceCount, 1);

            Bar.Value = null;

            cmd.Execute("zxcv");

            Assert.IsEqual(Bar.InstanceCount, 2);
            Assert.IsEqual(Bar.Value, "zxcv");
        }

        [Test]
        public void TestToCached1()
        {
            Bar.Value = null;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsCached();

            Container.BindCommand<DoSomethingCommand, string>()
                .To<Bar>(x => x.Execute).AsCached();

            Container.Resolve<Bar>();
            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsEqual(Bar.InstanceCount, 1);
            Assert.IsNull(Bar.Value);

            cmd.Execute("asdf");

            Assert.IsEqual(Bar.Value, "asdf");
            Assert.IsEqual(Bar.InstanceCount, 2);

            Bar.Value = null;
            cmd.Execute("zxcv");

            Assert.IsEqual(Bar.Value, "zxcv");
            Assert.IsEqual(Bar.InstanceCount, 2);
        }

        [Test]
        public void TestToResolveMethod()
        {
            Bar.Value = null;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsSingle();

            Container.BindCommand<DoSomethingCommand, string>()
                .ToResolve<Bar>(x => x.Execute);

            Container.Resolve<Bar>();
            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsNull(Bar.Value);

            cmd.Execute("asdf");

            Assert.IsEqual(Bar.Value, "asdf");
            Assert.IsEqual(Bar.InstanceCount, 1);
        }

        [Test]
        public void TestToOptionalResolveMethod1()
        {
            Bar.Value = null;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsSingle();

            Container.BindCommand<DoSomethingCommand, string>()
                .ToOptionalResolve<Bar>(x => x.Execute);

            Container.Resolve<Bar>();
            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsNull(Bar.Value);

            cmd.Execute("asdf");

            Assert.IsEqual(Bar.Value, "asdf");
            Assert.IsEqual(Bar.InstanceCount, 1);
        }

        [Test]
        public void TestToOptionalResolveMethod2()
        {
            Bar.Value = null;
            Bar.InstanceCount = 0;

            Container.BindCommand<DoSomethingCommand, string>()
                .ToOptionalResolve<Bar>(x => x.Execute);

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsNull(Bar.Value);

            cmd.Execute("asdf");

            Assert.IsNull(Bar.Value);
            Assert.IsEqual(Bar.InstanceCount, 0);
        }

        [Test]
        public void TestToNothingHandler()
        {
            Container.BindCommand<DoSomethingCommand, string>().ToNothing();

            var cmd = Container.Resolve<DoSomethingCommand>();
            cmd.Execute("asdf");
        }

        [Test]
        public void TestToMethod()
        {
            string receivedValue = null;

            Container.BindCommand<DoSomethingCommand, string>()
                .ToMethod((value) => receivedValue = value);

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsNull(receivedValue);
            cmd.Execute("asdf");
            Assert.IsEqual(receivedValue, "asdf");
        }

        public class DoSomethingCommand : Command<string>
        {
        }

        public class Bar
        {
            public static int InstanceCount = 0;

            public Bar()
            {
                InstanceCount ++;
            }

            public static string Value
            {
                get;
                set;
            }

            public void Execute(string value)
            {
                Value = value;
            }
        }
    }
}


