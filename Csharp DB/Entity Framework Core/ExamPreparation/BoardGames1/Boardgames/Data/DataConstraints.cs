using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data
{
    public static class DataConstraints
    {
        //Creator
        public const byte CreatorFirstNameMinLength = 2;
        public const byte CreatorFirstNameMaxLength = 7;

        public const byte CreatorLastNameMinLength = 2;
        public const byte CreatorLastNameMaxLength = 7;

        //Seller
        public const byte SellerNameMinLength = 5;
        public const byte SellerNameMaxLength = 20;

        public const byte SellerAddressMinLength = 2;
        public const byte SellerAddressMaxLength = 30;

        //BoardGame
        public const byte BoardGameNameMinLength = 10;
        public const byte BoardGameNameMaxLength = 20;

        public const double BoardGameMinRatingValue = 1;
        public const double BoardGameMaxRatingValue = 10;

        public const int BoardGameYearPublishedMinValue = 2018;
        public const int BoardGameYearPublishedMaxValue = 2023;

    }
}
