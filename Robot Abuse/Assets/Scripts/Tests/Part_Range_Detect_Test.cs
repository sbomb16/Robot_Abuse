using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Part_Range_Detect_Test
    {
        [Test]
        public void TestingRange()
        {
            Part_Controller controller = new Part_Controller();

            Assert.AreEqual(false, controller.ResetRangeDetect(0.1f));
            Assert.AreEqual(true, controller.ResetRangeDetect(0.0005f));
        }
    }
}

