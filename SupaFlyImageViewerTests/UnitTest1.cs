using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupaFlyImageViewer;

namespace SupaFlyImageViewerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var blah = new ImageViewerModel();
            blah.PropertyChanged += (s, e) => Assert.AreEqual("Width", e.PropertyName);
            blah.DisplayedWidth = 50;
        }
    }
}
