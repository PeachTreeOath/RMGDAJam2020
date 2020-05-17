using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class DateModel
    {
        public int hairType;
        public int hairColor;
        public int topType;
        public int topColor;
        public int botType;
        public int botColor;

        public string firstName;
        public string birthMonth;
        public string hobby;
        public string bloodType;
        public string homeTown;
        public string movie;

        public int firstNameIdx;
        public int birthMonthIdx;
        public int hobbyIdx;
        public int bloodTypeIdx;
        public int homeTownIdx;
        public int movieIdx;

        public bool IsAppearanceTheSame(DateModel other)
        {
            return hairType == other.hairType &&
                hairColor == other.hairColor &&
                topType == other.topType &&
                topColor == other.topColor &&
                botType == other.botType &&
                botColor == other.botColor;
        }
    }
}