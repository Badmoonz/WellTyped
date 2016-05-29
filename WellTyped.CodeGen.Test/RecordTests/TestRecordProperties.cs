using System;
using NUnit.Framework;

namespace WellTyped.CodeGen.RecordTests
{
    [TestFixture]
    public class TestRecordProperties
    {
        [Test]
        public void TestEquality()
        {
            var someRecord1 = SomeRecord.New(1, "b");
            var someRecord2 = SomeRecord.New(1, "b");
            var someRecord3 = SomeRecord.New(1, "" + "b");
            var someRecord4 = SomeRecord.New(2, "b");
            var someRecord5 = SomeRecord.New(1, "c");
            var someRecord6 = SomeRecord.New(2, "c");
            Assert.IsTrue(someRecord1 == someRecord2);
            Assert.IsTrue(someRecord1 == someRecord3);
            Assert.IsFalse(someRecord1 == someRecord4);
            Assert.IsFalse(someRecord1 == someRecord5);
            Assert.IsFalse(someRecord1 == someRecord6);
            Assert.IsFalse(someRecord1 == someRecord6);

            // a == b <=>  !(a != b)
            Assert.IsFalse(someRecord1 != someRecord2);

            Assert.IsTrue(someRecord1 != (SomeRecord)null);
            Assert.IsTrue((SomeRecord)null != someRecord1);
            Assert.IsTrue((SomeRecord)null == (SomeRecord)null);
        }


        [Test]
        public void TestUpdate()
        {
            var someRecord1 = SomeRecord.New(1, "b");
            var someRecord2 = SomeRecord.New(2, "c");

            var updatedRecord = someRecord2.With(a: 1, b: "b");
            Assert.IsTrue(someRecord1 == updatedRecord);
        }
    }
}
