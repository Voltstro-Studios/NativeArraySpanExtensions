using System;
using Unity.Collections;

namespace VoltstroStudios.UnityNativeArraySpanExtensions
{
    public static class SpanExtensions
    {
        public static void CopyTo<T>(this Span<T> source, NativeArray<T> dst)
            where T : unmanaged
        {
            CopyTo((ReadOnlySpan<T>) source, dst);
        }
        
        public static void CopyTo<T>(this ReadOnlySpan<T> source, NativeArray<T> dst)
            where T : unmanaged
        {
            dst.CopyFrom(source);
        }
    }
}
