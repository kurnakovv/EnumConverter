using System;

namespace EnumConverter
{
    /// <summary>
    /// Enum converter.
    /// </summary>
    public static class EnumConverter
    {
        /// <summary>
        /// Convert <paramref name="enumValue"/> to <typeparamref name="TAnotherEnum"/>.
        /// </summary>
        /// <typeparam name="TAnotherEnum">Enum that we want to get after convert.</typeparam>
        /// <param name="enumValue">Input enum we want to convert to <typeparamref name="TAnotherEnum"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="OverflowException"/>
        /// <returns><typeparamref name="TAnotherEnum"/>.</returns>
        public static TAnotherEnum ToAnother<TAnotherEnum>(this Enum enumValue, bool ignoreCase)
            where TAnotherEnum : Enum
        {
            return (TAnotherEnum)Enum.Parse(typeof(TAnotherEnum), enumValue.ToString(), ignoreCase);
        }

        /// <summary>
        /// Convert <paramref name="enumValue"/> to <typeparamref name="TAnotherEnum"/>.
        /// </summary>
        /// <remarks>ignoreCase = true.</remarks>
        /// <typeparam name="TAnotherEnum">Enum that we want to get after convert.</typeparam>
        /// <param name="enumValue">Input enum we want to convert to <typeparamref name="TAnotherEnum"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="OverflowException"/>
        /// <returns><typeparamref name="TAnotherEnum"/>.</returns>
        public static TAnotherEnum ToAnother<TAnotherEnum>(this Enum enumValue)
            where TAnotherEnum : Enum
        {
            return enumValue.ToAnother<TAnotherEnum>(true);
        }
    }
}
