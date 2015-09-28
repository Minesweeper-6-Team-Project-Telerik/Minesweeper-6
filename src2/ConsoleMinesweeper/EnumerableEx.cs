// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableEx.cs" company="">
//   
// </copyright>
// <summary>
//   The enumerable ex.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The enumerable ex.
    /// </summary>
    public static class EnumerableEx
    {
        /// <summary>
        /// The split by.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <param name="chunkLength">
        /// The chunk length.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static IEnumerable<string> SplitBy(this string str, int chunkLength)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException();
            }

            if (chunkLength < 1)
            {
                throw new ArgumentException();
            }

            for (var i = 0; i < str.Length; i += chunkLength)
            {
                if (chunkLength + i > str.Length)
                {
                    chunkLength = str.Length - i;
                }

                yield return str.Substring(i, chunkLength);
            }
        }
    }
}