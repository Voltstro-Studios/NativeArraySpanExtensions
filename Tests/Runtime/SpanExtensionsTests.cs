using System;
using NUnit.Framework;
using Unity.Collections;

namespace VoltstroStudios.UnityNativeArraySpanExtensions.Tests
{
    public class SpanExtensionsTests
    {
        [Test]
        public void CopyToReadOnlyTest()
        {
            NativeArray<byte> testNativeArray = new(new byte[] { 1, 8, 7, 6 }, Allocator.Temp);
            try
            {
                Assert.IsTrue(testNativeArray.IsCreated);

                byte[] testNewData = { 7, 4, 3, 5 };
                ReadOnlySpan<byte> testNewDataSpan = testNewData;
                testNewDataSpan.CopyTo(testNativeArray);

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
            NativeArray<byte> testNativeArray = new(new byte[] { 1, 8, 7, 6 }, Allocator.Temp);
            try
            {
                Assert.IsTrue(testNativeArray.IsCreated);

                byte[] testNewData = { 7, 4, 3, 5 };
                Span<byte> testNewDataSpan = testNewData;
                testNewDataSpan.CopyTo(testNativeArray);

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
        public void ToNativeArrayReadOnlyTest()
        {
            byte[] testNewData = { 7, 4, 3, 5 };
            ReadOnlySpan<byte> testDataSpan = testNewData;
            NativeArray<byte> nativeArray = testDataSpan.ToNativeArray(Allocator.Temp);
            try
            {
                for (int i = 0; i < testNewData.Length; i++)
                {
                    Assert.AreEqual(testNewData[i], nativeArray[i]);
                }
            }
            finally
            {
                nativeArray.Dispose();
            }
        }
        
        [Test]
        public void ToNativeArrayTest()
        {
            byte[] testNewData = { 7, 4, 3, 5 };
            Span<byte> testDataSpan = testNewData;
            NativeArray<byte> nativeArray = testDataSpan.ToNativeArray(Allocator.Temp);
            try
            {
                for (int i = 0; i < testNewData.Length; i++)
                {
                    Assert.AreEqual(testNewData[i], nativeArray[i]);
                }
            }
            finally
            {
                nativeArray.Dispose();
            }
        }
    }
}
