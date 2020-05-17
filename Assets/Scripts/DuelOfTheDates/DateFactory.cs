using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class DateFactory : Singleton<DateFactory>
    {
        [HideInInspector]
        public List<string> firstNames = new List<string>()
        {
            "Abby",
            "Bernie",
            "Crystal",
            "Dee Dee",
            "Ellie",
            "Faye",
            "Gertrude",
            "Harriet",
            "Ibuki",
            "Jazz",
            "Krystal",
            "Lemonade",
            "Monica",
            "Nala",
            "Oprah",
            "Paine",
            "Quinn",
            "Rosie",
            "Stacy",
            "Taylor",
            "Uwu",
            "Violet",
            "Wanda",
            "Xena",
            "Yuriko",
            "Zeta",
        };

        [HideInInspector]
        public List<string> birthMonths = new List<string>()
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        [HideInInspector]
        public List<string> hobbies = new List<string>()
        {
            "Hiking",
            "Skiing",
            "Singing",
            "Coding",
            "Gaming",
            "Blacksmithing",
            "Lockpicking",
            "Crocheting",
            "Basketball",
            "Eating",
            "Cosplaying",
            "Planting trees",
            "Powerlifting",
            "DJing",
            "Mahjong"
        };

        [HideInInspector]
        public List<string> bloodTypes = new List<string>()
        {
            "O negative",
            "O positive",
            "A negative",
            "A positive",
            "B negative",
            "B positive",
            "AB negative",
            "AB positive",
            "Corrosive acid"
        };

        [HideInInspector]
        public List<string> homeTowns = new List<string>()
        {
            "New York",
            "Los Angeles",
            "Chicago",
            "Houston",
            "Phoenix",
            "Philadelphia",
            "Detroit",
            "Milwaukee",
            "Dallas",
            "Honolulu",
            "Tampa",
            "Las Vegas",
            "Boston",
            "Columbus",
            "San Francisco",
            "Charlotte",
            "Seattle",
            "Denver",
            "Boulder",
            "Colorado Springs"
        };

        [HideInInspector]
        public List<string> movies = new List<string>()
        {
            "Ace Ventura",
            "Ace Ventura 2",
            "The Mask",
            "Dumb and Dumber",
            "Batman Forever",
            "The Cable Guy",
            "Liar Liar",
            "The Truman Show",
            "Bruce Almighty",
            "Eternal Sunshine",
            "Kick-Ass 2",
            "Sonic the Hedgehog"
        };

        [HideInInspector] public Color redColor;
        [HideInInspector] public Color orangeColor;
        [HideInInspector] public Color yellowColor;
        [HideInInspector] public Color greenColor;
        [HideInInspector] public Color blueColor;
        [HideInInspector] public Color purpleColor;
        [HideInInspector] public Color blackColor;

        [HideInInspector] public Dictionary<int, Color> colorMap = new Dictionary<int, Color>();

        private void Start()
        {
            redColor = new Color();
            ColorUtility.TryParseHtmlString("#A12A1F", out redColor);
            orangeColor = new Color();
            ColorUtility.TryParseHtmlString("#A26D20", out orangeColor);
            yellowColor = new Color();
            ColorUtility.TryParseHtmlString("#FFFD4E", out yellowColor);
            greenColor = new Color();
            ColorUtility.TryParseHtmlString("#4ECF75", out greenColor);
            blueColor = new Color();
            ColorUtility.TryParseHtmlString("#269ABA", out blueColor);
            purpleColor = new Color();
            ColorUtility.TryParseHtmlString("#823E8C", out purpleColor);
            blackColor = new Color();
            ColorUtility.TryParseHtmlString("#76606F", out blackColor);

            colorMap[0] = redColor;
            colorMap[1] = orangeColor;
            colorMap[2] = yellowColor;
            colorMap[3] = greenColor;
            colorMap[4] = blueColor;
            colorMap[5] = purpleColor;
            colorMap[6] = blackColor;
        }

        public DateModel CreateRandomModel()
        {
            DateModel model = new DateModel();
            model.hairType = Random.Range(0, 3);
            model.hairColor = Random.Range(0, colorMap.Count);
            model.topType = Random.Range(0, 1);
            model.topColor = Random.Range(0, colorMap.Count);
            model.botType = Random.Range(0, 2);
            model.botColor = Random.Range(0, colorMap.Count);

            model.firstNameIdx = Random.Range(0, firstNames.Count);
            model.firstName = firstNames[model.firstNameIdx];

            model.birthMonthIdx = Random.Range(0, birthMonths.Count);
            model.birthMonth = birthMonths[model.birthMonthIdx];

            model.hobbyIdx = Random.Range(0, hobbies.Count);
            model.hobby = hobbies[model.hobbyIdx];

            model.bloodTypeIdx = Random.Range(0, bloodTypes.Count);
            model.bloodType = bloodTypes[model.bloodTypeIdx];

            model.homeTownIdx = Random.Range(0, homeTowns.Count);
            model.homeTown = homeTowns[model.homeTownIdx];

            model.movieIdx = Random.Range(0, movies.Count);
            model.movie = movies[model.movieIdx];

            return model;
        }
    }
}