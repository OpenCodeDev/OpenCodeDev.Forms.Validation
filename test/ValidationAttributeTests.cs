using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCodeDev.Forms.Validation.Extensions;
using OpenCodeDev.Forms.Validation.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace TestProject1
{
    public class TestForm {
        [CreditCardSecurity]
        public string CC { get; set; }
    }

    [TestClass]
    public class ValidationAttributeTests
    {
        [TestMethod("Credit Card Security")]
        [TestCategory("Validation Attribute")]
        public void TestCreditCardSecurity()
        {
            string[] validEntries = new string[] {"125", "1555" };
            string[] invalidEntries = new string[] {"12555", "15", "1", "23-231-4", "21w2", "qweq", "32#3" };
            foreach (var item in validEntries)
            {
                Assert.IsTrue(new TestForm() { CC = item }.ValidateContext());
            }

            foreach (var item in invalidEntries)
            {
                Assert.IsFalse(new TestForm() { CC = item }.ValidateContext());
            }            
        }
    }
}
