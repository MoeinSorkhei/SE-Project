using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SAD;
using SAD.Business_Layer;
using Moq;
using Moq.Proxy;


namespace LawGetMatchedConditionTest
{
    [TestClass]
    public class ConditionsMatchedTest
    {
        [TestMethod]
        public void check_unvalid_Prerequisites()
        {
            Statement s = new Statement();
            Mock<Law> l = new Mock<Law>();
            l.Setup(t => t.IsValidDate(s)).Returns(true);
            l.Setup(t => t.IsValidPrerequisites(s)).Returns(false);
            Law l2 = l.Object;
            bool expected = false;
            Assert.AreEqual(l2.ConditionsMatched(s), expected, "unvalid Prerequisites isn't correctly coded!");
        }
    }
}