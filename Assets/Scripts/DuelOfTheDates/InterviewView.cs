using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class InterviewView : Singleton<InterviewView>
    {
        public TextMeshProUGUI question;
        public List<AnswerView> answers;

        [HideInInspector] public int p1SelectedAnswer;
        [HideInInspector] public int p2SelectedAnswer;

        private int currentCorrectAnswer;

        public void ClearAnswers()
        {
            foreach (AnswerView view in answers)
            {
                view.P1Deselected();
                view.P2Deselected();
            }
        }

        public void SetAnswers()
        {
            answers[p1SelectedAnswer].P1Selected();
            answers[p2SelectedAnswer].P2Selected();
        }

        public void InitInterview(DateModel model, int infoType)
        {
            ClearAnswers();
            p1SelectedAnswer = 3;
            p2SelectedAnswer = 3;
            SetAnswers();

            // Init the 8 answers
            List<int> choiceSlotsUsed = new List<int>();
            List<int> answersUsed = new List<int>();

            // Place the correct answer
            string correctAnswer = "";
            switch (infoType)
            {
                case 0:
                    correctAnswer = model.firstName;
                    answersUsed.Add(model.firstNameIdx);
                    question.text = "What is my name?";
                    break;
                case 1:
                    correctAnswer = model.birthMonth;
                    answersUsed.Add(model.birthMonthIdx);
                    question.text = "When is my bday?";
                    break;
                case 2:
                    correctAnswer = model.hobby;
                    answersUsed.Add(model.hobbyIdx);
                    question.text = "What is my hobby?";
                    break;
                case 3:
                    correctAnswer = model.bloodType;
                    answersUsed.Add(model.bloodTypeIdx);
                    question.text = "What is my blood type?";
                    break;
                case 4:
                    correctAnswer = model.homeTown;
                    answersUsed.Add(model.homeTownIdx);
                    question.text = "What is my hometown?";
                    break;
                case 5:
                    correctAnswer = model.movie;
                    answersUsed.Add(model.movieIdx);
                    question.text = "What is my fave movie?";
                    break;
            }

            int idx = PlaceAnswer(choiceSlotsUsed, correctAnswer);
            choiceSlotsUsed.Add(idx);
            currentCorrectAnswer = idx;

            // Place 7 false answers
            int numAnswers = 0;
            List<string> answers = null;
            switch (infoType)
            {
                case 0:
                    numAnswers = DateFactory.instance.firstNames.Count;
                    answers = DateFactory.instance.firstNames;
                    break;
                case 1:
                    numAnswers = DateFactory.instance.birthMonths.Count;
                    answers = DateFactory.instance.birthMonths;
                    break;
                case 2:
                    numAnswers = DateFactory.instance.hobbies.Count;
                    answers = DateFactory.instance.hobbies;
                    break;
                case 3:
                    numAnswers = DateFactory.instance.bloodTypes.Count;
                    answers = DateFactory.instance.bloodTypes;
                    break;
                case 4:
                    numAnswers = DateFactory.instance.homeTowns.Count;
                    answers = DateFactory.instance.homeTowns;
                    break;
                case 5:
                    numAnswers = DateFactory.instance.movies.Count;
                    answers = DateFactory.instance.movies;
                    break;
            }

            for (int i = 0; i < 7; i++)
            {
                int answerIdx = GetUnusedAnswer(answersUsed, numAnswers);
                answersUsed.Add(answerIdx);

                int choiceIdx = PlaceAnswer(choiceSlotsUsed, answers[answerIdx]);
                choiceSlotsUsed.Add(choiceIdx);
            }
        }

        public void MoveAnswerUp(int playerNum)
        {
            if (playerNum == 0)
            {
                p1SelectedAnswer--;
                if (p1SelectedAnswer == -1)
                    p1SelectedAnswer = 7;
            }
            else
            {
                p2SelectedAnswer--;
                if (p2SelectedAnswer == -1)
                    p2SelectedAnswer = 7;
            }

            ClearAnswers();
            SetAnswers();
        }

        public void MoveAnswerDown(int playerNum)
        {
            if (playerNum == 0)
            {
                p1SelectedAnswer++;
                if (p1SelectedAnswer == 8)
                    p1SelectedAnswer = 0;
            }
            else
            {
                p2SelectedAnswer++;
                if (p2SelectedAnswer == 8)
                    p2SelectedAnswer = 0;
            }

            ClearAnswers();
            SetAnswers();
        }

        private int GetUnusedAnswer(List<int> answersUsed, int numAnswers)
        {
            int i;
            do
            {
                i = Random.Range(0, numAnswers);
            }
            while (answersUsed.Contains(i));

            return i;
        }

        private int PlaceAnswer(List<int> choicesUsed, string answerText)
        {
            int i;
            do
            {
                i = Random.Range(0, 8);
            }
            while (choicesUsed.Contains(i));

            answers[i].SetAnswer(answerText);

            return i;
        }
    }
}