using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Notes.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AllNotesIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("All Notes"));
            app.Screenshot("Main Page after Startup.");

            Assert.IsTrue(results.Any());
        }
    }
}
