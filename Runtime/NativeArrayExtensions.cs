using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace VoltstroStudios.UnityNativeArraySpanExtensions
{
    public static class NativeArrayExtensions
    {
        public static unsafe void CopyFrom<T>(this NativeArray<T> array, ReadOnlySpan<T> source)
            where T : unmanaged
        {
            Utils.CheckCopyLengths(source.Length, array.Length);
            
            //Calling GetUnsafePtr will check if the array is valid for us
            //(if checks are enabled)
            void* dstPtr = array.GetUnsafePtr();

            fixed (void* srcPtr = source)
            {
                Utils.Copy<T>(srcPtr, 0, dstPtr, 0, array.Length);
            }
        }

        public static unsafe void CopyTo<T>(this NativeArray<T> array, Span<T> dst)
            where T : unmanaged
        {
            Utils.CheckCopyLengths(array.Length, dst.Length);

            //Calling GetUnsafePtr will check if the array is valid for us
            //(if checks are enabled)
            void* srcPtr = array.GetUnsafePtr();

            fixed (void* dstPtr = dst)
            {
                Utils.Copy<T>(srcPtr, 0, dstPtr, 0, array.Length);
            }
        }
    }
}
