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
    public class TestCommandsZero : ZenjectUnitTestFixture
    {
        [Test]
        public void TestToSingle1()
        {
            Bar.WasTriggered = false;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsSingle();

            Container.BindCommand<DoSomethingCommand>()
                .To<Bar>(x => x.Execute).AsSingle();

            Container.Resolve<Bar>();
            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsEqual(Bar.InstanceCount, 1);
            Assert.That(!Bar.WasTriggered);

            cmd.Execute();

            Assert.That(Bar.WasTriggered);
            Assert.IsEqual(Bar.InstanceCount, 1);
        }

        [Test]
        public void TestToTransient1()
        {
            Bar.WasTriggered = false;
            Bar.InstanceCount = 0;

            Container.BindCommand<DoSomethingCommand>()
                .To<Bar>(x => x.Execute).AsTransient();

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsEqual(Bar.InstanceCount, 0);
            Assert.That(!Bar.WasTriggered);

            cmd.Execute();

            Assert.That(Bar.WasTriggered);
            Assert.IsEqual(Bar.InstanceCount, 1);

            Bar.WasTriggered = false;

            cmd.Execute();

            Assert.IsEqual(Bar.InstanceCount, 2);
            Assert.That(Bar.WasTriggered);
        }

        [Test]
        public void TestToCached1()
        {
            Bar.WasTriggered = false;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsCached();

            Container.BindCommand<DoSomethingCommand>()
                .To<Bar>(x => x.Execute).AsCached();

            Container.Resolve<Bar>();
            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.IsEqual(Bar.InstanceCount, 1);
            Assert.That(!Bar.WasTriggered);

            cmd.Execute();

            Assert.That(Bar.WasTriggered);
            Assert.IsEqual(Bar.InstanceCount, 2);

            cmd.Execute();
            Assert.IsEqual(Bar.InstanceCount, 2);
        }

        [Test]
        public void TestToResolveTransientMethod()
        {
            Bar.WasTriggered = false;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsTransient();

            Container.BindCommand<DoSomethingCommand>()
                .ToResolve<Bar>(x => x.Execute).AsTransient();

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.That(!Bar.WasTriggered);

            cmd.Execute();

            Assert.That(Bar.WasTriggered);
            Assert.IsEqual(Bar.InstanceCount, 1);

            cmd.Execute();

            Assert.IsEqual(Bar.InstanceCount, 2);
        }

        [Test]
        public void TestToResolveCachedMethod()
        {
            Bar.WasTriggered = false;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsTransient();

            Container.BindCommand<DoSomethingCommand>()
                .ToResolve<Bar>(x => x.Execute).AsCached();

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.That(!Bar.WasTriggered);

            cmd.Execute();

            Assert.That(Bar.WasTriggered);
            Assert.IsEqual(Bar.InstanceCount, 1);

            cmd.Execute();

            Assert.IsEqual(Bar.InstanceCount, 1);
        }

        [Test]
        public void TestToOptionalResolveMethod1()
        {
            Bar.WasTriggered = false;
            Bar.InstanceCount = 0;

            Container.Bind<Bar>().AsSingle();

            Container.BindCommand<DoSomethingCommand>()
                .ToOptionalResolve<Bar>(x => x.Execute);

            Container.Resolve<Bar>();
            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.That(!Bar.WasTriggered);

            cmd.Execute();

            Assert.That(Bar.WasTriggered);
            Assert.IsEqual(Bar.InstanceCount, 1);
        }

        [Test]
        public void TestToOptionalResolveMethod2()
        {
            Bar.WasTriggered = false;
            Bar.InstanceCount = 0;

            Container.BindCommand<DoSomethingCommand>()
                .ToOptionalResolve<Bar>(x => x.Execute);

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.That(!Bar.WasTriggered);

            cmd.Execute();

            Assert.That(!Bar.WasTriggered);
            Assert.IsEqual(Bar.InstanceCount, 0);
        }

        [Test]
        public void TestToNothingHandler()
        {
            Container.BindCommand<DoSomethingCommand>().ToNothing();

            var cmd = Container.Resolve<DoSomethingCommand>();
            cmd.Execute();
        }

        [Test]
        public void TestToMethod()
        {
            bool wasCalled = false;

            Container.BindCommand<DoSomethingCommand>()
                .ToMethod(() => wasCalled = true);

            var cmd = Container.Resolve<DoSomethingCommand>();

            Assert.That(!wasCalled);
            cmd.Execute();
            Assert.That(wasCalled);
        }

        public class DoSomethingCommand : Command
        {
        }

        public class Bar
        {
            public static int InstanceCount = 0;

            public Bar()
            {
                InstanceCount ++;
            }

            public static bool WasTriggered
            {
                get;
                set;
            }

            public void Execute()
            {
                WasTriggered = true;
            }
        }
    }
}

