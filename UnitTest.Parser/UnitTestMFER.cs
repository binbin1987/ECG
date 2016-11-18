using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECG.Parser;
using ECG.Definition;

namespace UnitTest.Parser
{
    [TestClass]
    public class UnitTestMFER
    {
        [TestMethod]
        public void TestResolveSignals()
        {
            MFER mfer = new MFER();
            Signals signals;
            Assert.IsTrue(mfer.ResolveSignals(Properties.Resources.Example_MWF, 0, out signals));
        }
    }
}
