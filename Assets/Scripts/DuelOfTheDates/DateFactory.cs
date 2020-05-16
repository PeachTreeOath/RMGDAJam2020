﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class DateFactory : MonoBehaviour
    {

        private List<string> firstNames = new List<string>()
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

        private List<string> birthMonths = new List<string>()
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

        private List<string> hobbies = new List<string>()
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

        private List<string> bloodTypes = new List<string>()
        {
            "O",
            "A",
            "B",
            "AB"
        };

        private List<string> homeTowns = new List<string>()
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

        private List<string> movies = new List<string>()
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

        public DateModel CreateRandomModel()
        {
            DateModel model = new DateModel();
            //TODO: Fill out appearance and make sure you dont accidentally create an identical looking character

            model.firstName = firstNames[Random.Range(0, firstNames.Count)];
            model.birthMonth = birthMonths[Random.Range(0, birthMonths.Count)];
            model.hobby = hobbies[Random.Range(0, hobbies.Count)];
            model.bloodType = bloodTypes[Random.Range(0, bloodTypes.Count)];
            model.homeTown = homeTowns[Random.Range(0, homeTowns.Count)];
            model.movie = movies[Random.Range(0, movies.Count)];

            return model;
        }
    }
}