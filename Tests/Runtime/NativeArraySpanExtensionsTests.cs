using System;
using NUnit.Framework;
using Unity.Collections;

namespace VoltstroStudios.UnityNativeArraySpanExtensions.Tests
{
    public class NativeArraySpanExtensionsTests
    {
        [Test]
        public void CopyFromTest()
        {
            NativeArray<byte> testNativeArray = new(new byte[] { 1, 8, 7, 6 }, Allocator.Temp);
            try
            {
                Assert.IsTrue(testNativeArray.IsCreated);

                byte[] testNewData = { 7, 4, 3, 5 };
                Span<byte> testNewDataSpan = testNewData;
                testNativeArray.CopyFrom(testNewDataSpan);

                for (int i = 0; i < testNewData.Length; i++)
                {
                    Assert.AreEqual(testNewData[i], testNativeArray[i]);
                }
            }
            finally
            {
                testNativeArray.Dispose();
            }
        }

        [Test]
        public void CopyToTest()
        {
            byte[] testingData = { 1, 8, 7, 6 };
            NativeArray<byte> testNativeArray = new(testingData, Allocator.Temp);
            try
            {
                Assert.IsTrue(testNativeArray.IsCreated);

                Span<byte> testSpan = new byte[4];
                testNativeArray.CopyTo(testSpan);

                for (int i = 0; i < testingData.Length; i++)
                {
                    Assert.AreEqual(testingData[i], testSpan[i]);
                }
            }
            finally
            {
                testNativeArray.Dispose();
            }
        }
    }
}
