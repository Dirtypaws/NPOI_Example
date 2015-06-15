using System.Linq;
using NPOI.DataAccess;
using NUnit.Framework;

namespace Tests.DataAccess
{
    [TestFixture]
    public class Family_Tests
    {
        [Test]
        public void GetSingle_Test()
        {
            var result = Repository.Get(1).FirstOrDefault();

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetMany_Test()
        {
            var result = Repository.Get(10);

            Assert.Greater(result.Count(), 1);
        }
    }
}