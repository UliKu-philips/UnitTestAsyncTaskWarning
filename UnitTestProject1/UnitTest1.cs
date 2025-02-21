namespace UnitTestProject1
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethodAsync()
        {
            using (var waitEvent = new ManualResetEventSlim())
            {
                using (Observable.Timer(dueTime: TimeSpan.FromSeconds(0), period: TimeSpan.FromSeconds(1)).Subscribe(
                    async t =>
                    {
                        await Task.Delay(1);
                        Assert.IsTrue(t > 0);
                        waitEvent.Set();
                    }))
                {
                    waitEvent.Wait(TimeSpan.FromSeconds(2));
                    await Task.Delay(1);
                }
            }
        }
    }
}
