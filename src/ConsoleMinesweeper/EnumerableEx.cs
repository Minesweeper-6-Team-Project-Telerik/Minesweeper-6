// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableEx.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
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
        /// The string.
        /// </param>
        /// <param name="chunkLength">
        /// The chunk length.
        /// </param>
        /// <returns>
        /// The substring <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// The ArgumentException.
        /// </exception>
        public static IEnumerable<string> SplitBy(this string str, int chunkLength)
        {
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
