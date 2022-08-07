using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace VoltstroStudios.UnityNativeArraySpanExtensions
{
    public static class NativeArrayExtensions
    {
        public static unsafe void CopyFrom<T>(this NativeArray<T> array, ReadOnlySpan<T> source)
            where T : unmanaged
        {
            CheckCopyLengths(source.Length, array.Length);
            
            //Calling GetUnsafePtr will check if the array is valid for us
            //(if checks are enabled)
            void* dstPtr = array.GetUnsafePtr();

            fixed (void* srcPtr = source)
            {
                Copy<T>(srcPtr, 0, dstPtr, 0, array.Length);
            }
        }

        public static unsafe void CopyTo<T>(this NativeArray<T> array, Span<T> dst)
            where T : unmanaged
        {
            CheckCopyLengths(array.Length, dst.Length);

            //Calling GetUnsafePtr will check if the array is valid for us
            //(if checks are enabled)
            void* srcPtr = array.GetUnsafePtr();

            fixed (void* dstPtr = dst)
            {
                Copy<T>(srcPtr, 0, dstPtr, 0, array.Length);
            }
        }

        private static unsafe void Copy<T>(void* src, int srcIndex,
            void* dst, int dstIndex,
            int length)
            where T : unmanaged
        {
            UnsafeUtility.MemCpy((void*) ((IntPtr) dst + dstIndex * UnsafeUtility.SizeOf<T>()), 
                (void*) ((IntPtr) src + srcIndex * UnsafeUtility.SizeOf<T>()), 
                (long) (length * UnsafeUtility.SizeOf<T>()));
        }

        [Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
        private static void CheckCopyLengths(int srcLength, int dstLength)
        {
            if (srcLength != dstLength)
                throw new ArgumentException("source and destination length must be the same");
        }
    }
}
