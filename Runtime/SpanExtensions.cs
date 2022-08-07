using System;
using Unity.Collections;

namespace VoltstroStudios.UnityNativeArraySpanExtensions
{
    /// <summary>
    ///     Provides <see cref="NativeArray{T}"/> copying utils to <see cref="Span{T}"/>
    /// </summary>
    public static class SpanExtensions
    {
        /// <summary>
        ///     Copy data from a <see cref="Span{T}"/> to a <see cref="NativeArray{T}"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dst"></param>
        /// <typeparam name="T"></typeparam>
        public static void CopyTo<T>(this Span<T> source, NativeArray<T> dst)
            where T : unmanaged
        {
            CopyTo((ReadOnlySpan<T>) source, dst);
        }
        
        /// <summary>
        ///     Copy data from a <see cref="ReadOnlySpan{T}"/> to a <see cref="NativeArray{T}"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dst"></param>
        /// <typeparam name="T"></typeparam>
        public static void CopyTo<T>(this ReadOnlySpan<T> source, NativeArray<T> dst)
            where T : unmanaged
        {
            dst.CopyFrom(source);
        }
    }
}
