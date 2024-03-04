using System;
using System.Collections.Generic;

namespace EnumConverterLibrary
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
        /// <param name="ignoreCase">Ignore or regard case.</param>
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

        /// <summary>
        /// Convert <paramref name="enumValues"/> to enumerable of <typeparamref name="TAnotherEnum"/>.
        /// </summary>
        /// <typeparam name="TInputEnum">Type of <paramref name="enumValues"/>.</typeparam>
        /// <typeparam name="TAnotherEnum">Enum type that we want to get after convert.</typeparam>
        /// <param name="enumValues">The input enums that we want to convert to enumerable of <typeparamref name="TAnotherEnum"/>.</param>
        /// <param name="ignoreCase">Ignore or regard case.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="OverflowException"/>
        /// <returns>Enumerable of <typeparamref name="TAnotherEnum"/>.</returns>
        public static IEnumerable<TAnotherEnum> ToAnother<TInputEnum, TAnotherEnum>(this IEnumerable<TInputEnum> enumValues, bool ignoreCase)
            where TInputEnum : Enum
            where TAnotherEnum : Enum
        {
            foreach (Enum value in enumValues)
            {
                yield return value.ToAnother<TAnotherEnum>(ignoreCase);
            }
        }

        /// <summary>
        /// Convert <paramref name="enumValues"/> to enumerable of <typeparamref name="TAnotherEnum"/>.
        /// </summary>
        /// <remarks>ignoreCase = true.</remarks>
        /// <typeparam name="TInputEnum">Type of <paramref name="enumValues"/>.</typeparam>
        /// <typeparam name="TAnotherEnum">Enum type that we want to get after convert.</typeparam>
        /// <param name="enumValues">The input enums that we want to convert to enumerable of <typeparamref name="TAnotherEnum"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="OverflowException"/>
        /// <returns>Enumerable of <typeparamref name="TAnotherEnum"/>.</returns>
        public static IEnumerable<TAnotherEnum> ToAnother<TInputEnum, TAnotherEnum>(this IEnumerable<TInputEnum> enumValues)
            where TInputEnum : Enum
            where TAnotherEnum : Enum
        {
            return enumValues.ToAnother<TInputEnum, TAnotherEnum>(true);
        }

        /// <summary>
        /// Try convert <paramref name="enumValue"/> to <typeparamref name="TAnotherEnum"/>.
        /// </summary>
        /// <typeparam name="TAnotherEnum">Enum that we want try to get after convert.</typeparam>
        /// <param name="enumValue">Input enum we want try to convert to <typeparamref name="TAnotherEnum"/>.</param>
        /// <param name="ignoreCase">Ignore or regard case.</param>
        /// <param name="anotherEnum"><typeparamref name="TAnotherEnum"/> or default of <typeparamref name="TAnotherEnum"/>.</param>
        /// <exception cref="ArgumentException"/>
        /// <returns>true if the <paramref name="enumValue"/> parameter was converted successfully; otherwise, false.</returns>
        public static bool TryToAnother<TAnotherEnum>(this Enum enumValue, bool ignoreCase, out TAnotherEnum anotherEnum)
            where TAnotherEnum : struct
        {
            return Enum.TryParse(enumValue.ToString(), ignoreCase, out anotherEnum);
        }

        /// <summary>
        /// Try convert <paramref name="enumValue"/> to <typeparamref name="TAnotherEnum"/>.
        /// </summary>
        /// <remarks>ignoreCase = true.</remarks>
        /// <typeparam name="TAnotherEnum">Enum that we want try to get after convert.</typeparam>
        /// <param name="enumValue">Input enum we want try to convert to <typeparamref name="TAnotherEnum"/>.</param>
        /// <param name="anotherEnum"><typeparamref name="TAnotherEnum"/> or default of <typeparamref name="TAnotherEnum"/>.</param>
        /// <exception cref="ArgumentException"/>
        /// <returns>true if the <paramref name="enumValue"/> parameter was converted successfully; otherwise, false.</returns>
        public static bool TryToAnother<TAnotherEnum>(this Enum enumValue, out TAnotherEnum anotherEnum)
            where TAnotherEnum : struct
        {
            return enumValue.TryToAnother(true, out anotherEnum);
        }

        /// <summary>
        /// Convert <paramref name="enumValue"/> to <typeparamref name="TAnotherEnum"/> or default value of <typeparamref name="TAnotherEnum"/> if not possible.
        /// </summary>
        /// <remarks>ignoreCase = true.</remarks>
        /// <typeparam name="TAnotherEnum">Enum that we want try to get after convert or default value of <typeparamref name="TAnotherEnum"/> if not possible.</typeparam>
        /// <param name="enumValue">Input enum we want try to convert to <typeparamref name="TAnotherEnum"/> or default value of <typeparamref name="TAnotherEnum"/> if not possible.</param>
        /// <exception cref="ArgumentException"/>
        /// <returns><typeparamref name="TAnotherEnum"/> or default value of <typeparamref name="TAnotherEnum"/> if not possible to convert.</returns>
        public static TAnotherEnum ToAnotherOrDefault<TAnotherEnum>(this Enum enumValue)
            where TAnotherEnum : struct
        {
            return enumValue.ToAnotherOrDefault<TAnotherEnum>(true);
        }

        /// <summary>
        /// Convert <paramref name="enumValue"/> to <typeparamref name="TAnotherEnum"/> or default value of <typeparamref name="TAnotherEnum"/> if not possible.
        /// </summary>
        /// <typeparam name="TAnotherEnum">Enum that we want try to get after convert or default value of <typeparamref name="TAnotherEnum"/> if not possible.</typeparam>
        /// <param name="enumValue">Input enum we want try to convert to <typeparamref name="TAnotherEnum"/> or default value of <typeparamref name="TAnotherEnum"/> if not possible.</param>
        /// <param name="ignoreCase">Ignore or regard case.</param>
        /// <exception cref="ArgumentException"/>
        /// <returns><typeparamref name="TAnotherEnum"/> or default value of <typeparamref name="TAnotherEnum"/> if not possible to convert.</returns>
        public static TAnotherEnum ToAnotherOrDefault<TAnotherEnum>(this Enum enumValue, bool ignoreCase)
            where TAnotherEnum : struct
        {
            return enumValue.TryToAnother(ignoreCase, out TAnotherEnum anotherEnum)
                ? anotherEnum
                : default(TAnotherEnum);
        }

        /// <summary>
        /// Convert <paramref name="stringValue"/> to <typeparamref name="TEnum"/>.
        /// </summary>
        /// <typeparam name="TEnum">Enum that we want to get after convert</typeparam>
        /// <param name="stringValue">Input string we want to convert to <typeparamref name="TEnum"/>.</param>
        /// <param name="ignoreCase">Ignore or regard case.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="OverflowException"/>
        /// <returns><typeparamref name="TEnum"/>.</returns>
        public static TEnum ToEnum<TEnum>(this string stringValue, bool ignoreCase)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), stringValue, ignoreCase);
        }

        /// <summary>
        /// Convert <paramref name="stringValue"/> to <typeparamref name="TEnum"/>.
        /// </summary>
        /// <remarks>ignoreCase = true.</remarks>
        /// <typeparam name="TEnum">Enum that we want to get after convert</typeparam>
        /// <param name="stringValue">Input string we want to convert to <typeparamref name="TEnum"/>.</param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="OverflowException"/>
        /// <returns><typeparamref name="TEnum"/>.</returns>
        public static TEnum ToEnum<TEnum>(this string stringValue)
        {
            return stringValue.ToEnum<TEnum>(true);
        }
    }
}
