using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UI_Status_Test
    {
        [Test]
        public void TestingStatus()
        {
            UI_Manager ui = new UI_Manager();

            Assert.AreEqual(null, ui.GetStatus());
        }
    }
}

