using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.MyEcommerce.Contracts.Constants
{
    public static class ValidationRules
    {
        public static class CommonRules
        {
            public const byte MaxLengthCharactersForText = Byte.MaxValue;
            public const byte MinLengthCharactersForText = Byte.MinValue;
            public const byte MaxLengthCharactersForShortText = Byte.MaxValue;

            public const double MinValueForUnitPrice = 0;
            public const byte DefaultValueForDiscount = 0;

            public const byte MinValueForDiscount = 0;
            public const byte MaxValueForDiscount = 100;

        }
        public static class ProductRules
        {
            public const short MaxLengthCharactersForProductName = 100;
            public const short MinLengthCharactersForProductName = 10;

            public const short MaxLengthCharactersForDescription = 300;
            public const short MinLengthCharactersForDescription = 50;
        }
        public static class ProductRatingRules
        {
            public const short MaxLengthCharactersForComment = 300;
            public const short MinLengthCharactersForComment = 10;

            public const byte MaxValueForRating = 5;
            public const byte MinValueForRating = 0;
        }
        public static class CategoryRules
        {
            public const short MaxLengthCharatersForName = 100;
            public const short MinLengthCharactersForName = 10;

            public const short MaxLengthCharatersForDescription = 200;
            public const short MinLengthCharactersForDescription = 10;
        }

        public static class OrderRules
        {
            public const byte ExactLengthForPhoneNumber = 10;
        }

        public static class OrderItemRules
        {
            public const byte DefaultValueForQuantity = 1;
        }
    }
}
