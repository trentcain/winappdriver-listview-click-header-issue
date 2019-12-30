using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListviewClickHeaderIssue.Tests
{
    [TestClass]
    public class IssueReproductionTests
    {
        private static TestContext context;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            context = testContext;
        }

        [DataTestMethod]
        [DataRow(5, 4, 1)]
        [DataRow(50, 16, 1)]
        public void IssueReproductionTest(int itemCount, int firstItemToSelect, int secondItemToSelect)
        {
            using (var sampleAppSession = new SampleAppSession(context, itemCount))
            {
                var firstItemText = $"Item {firstItemToSelect}";
                var secondItemText = $"Item {secondItemToSelect}";
                var list = sampleAppSession.Session.FindElementByAccessibilityId("lvwItems");

                var firstItem = sampleAppSession.Session.FindElementByName(firstItemText);
                firstItem.Click();
                Assert.AreEqual(firstItemText, list.Text);

                var secondItem = sampleAppSession.Session.FindElementByName(secondItemText);
                secondItem.Click();
                Assert.AreEqual(secondItemText, list.Text);
            }
        }
    }
}
