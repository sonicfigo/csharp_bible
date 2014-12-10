using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Bible1.Tests
{
    public class SampleTests
    {
        [Test]
        public void shoud_pass()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        [Ignore("igore failed temporary.")]
        public void should_failed()
        {
            Assert.AreEqual(1, 21);
        }
    }
}
