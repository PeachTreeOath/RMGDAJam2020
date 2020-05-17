using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FiveXT.DuelOfTheDates
{
    public enum GamePhase
    {
        INVESTIGATING,
        TRANSITIONING_TO_ANSWERING,
        ANSWERING,
        SHOW_ANSWER,
        TRANSITIONING_TO_INVESTIGATING
    }

    public class GameManager_DuelOfTheDates : Singleton<GameManager_DuelOfTheDates>, IGameStartCountdownListener
    {
        public GameObject gameOverCanvas;
        public TextMeshProUGUI winnerText;
        public GameObject datePrefab;
        public List<Vector2> datePositions;
        public Vector2 interviewPosition;
        public Transform p1Dater;
        public Transform p2Dater;
        public ScoreWidget p1Hearts;
        public ScoreWidget p2Hearts;
        public TextMeshProUGUI investigationTimer;
        public TextMeshProUGUI interviewTimer;
        public GameObject interviewObject;
        public GameObject p1CorrectObj;
        public GameObject p2CorrectObj;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;
        [HideInInspector] public GamePhase phase;

        private int round;
        private List<DateView> dates = new List<DateView>();
        private List<int> infoUsed = new List<int>();
        private int p1Points;
        private int p2Points;

        private float phaseTimeElapsed;
        private float investigationPhaseDuration = 10;
        private float transitionToAnsweringPhaseDuration = 3;
        private float answeringPhaseDuration = 10;
        private float showAnswerPhaseDuration = 2;
        private float transitionToInvestigationPhaseDuration = 3;

        private DateView selectedDate;
        private Vector2 selectedOrigPos;
        private Vector2 p1DaterOrigPos;
        private Vector2 p2DaterOrigPos;

        private int p1SelectedAnswer;
        private int p2SelectedAnswer;

        private void Start()
        {
            GameStartCountdown.instance.RegisterListener(this);

            p1DaterOrigPos = p1Dater.transform.position;
            p2DaterOrigPos = p2Dater.transform.position;

            phase = GamePhase.INVESTIGATING;
            GotoNextRound();
        }

        private void Update()
        {
            if (!IsGamePlayable()) return;

            phaseTimeElapsed += Time.deltaTime;

            if (phase == GamePhase.INVESTIGATING)
            {
                // Update timer
                investigationTimer.text = ((int)(investigationPhaseDuration - phaseTimeElapsed) + 1).ToString();

                if (phaseTimeElapsed > investigationPhaseDuration)
                {
                    selectedDate = dates[Random.Range(0, dates.Count)];
                    selectedOrigPos = selectedDate.transform.position;
                    investigationTimer.text = "";

                    phaseTimeElapsed = 0;
                    phase = GamePhase.TRANSITIONING_TO_ANSWERING;
                }
            }
            else if (phase == GamePhase.TRANSITIONING_TO_ANSWERING)
            {
                // Move players back and move date to interview position

                selectedDate.transform.position = Vector2.Lerp(selectedOrigPos, interviewPosition, phaseTimeElapsed / transitionToAnsweringPhaseDuration);
                p1Dater.transform.position = Vector2.Lerp(p1Dater.transform.position, p1DaterOrigPos, phaseTimeElapsed / transitionToAnsweringPhaseDuration);
                p2Dater.transform.position = Vector2.Lerp(p2Dater.transform.position, p2DaterOrigPos, phaseTimeElapsed / transitionToAnsweringPhaseDuration);

                if (phaseTimeElapsed > transitionToAnsweringPhaseDuration)
                {
                    interviewObject.SetActive(true);
                    InterviewView.instance.InitInterview(selectedDate.model, infoUsed[Random.Range(0, infoUsed.Count)]);
                    selectedDate.ChangeToSpriteLayer("Interview");

                    phaseTimeElapsed = 0;
                    phase = GamePhase.ANSWERING;
                }
            }
            else if (phase == GamePhase.ANSWERING)
            {
                // Update timer
                interviewTimer.text = ((int)(answeringPhaseDuration - phaseTimeElapsed) + 1).ToString();

                if (phaseTimeElapsed > answeringPhaseDuration)
                {
                    interviewTimer.text = "";

                    phaseTimeElapsed = 0;
                    phase = GamePhase.SHOW_ANSWER;
                }
            }
            else if (phase == GamePhase.SHOW_ANSWER)
            {
                // Do nothing, just show answer

                if (phaseTimeElapsed > showAnswerPhaseDuration)
                {
                    interviewObject.SetActive(false);
                    selectedDate.ChangeToSpriteLayer("Default");
                    p1CorrectObj.SetActive(false);
                    p2CorrectObj.SetActive(false);
                    GotoNextRound();

                    phaseTimeElapsed = 0;
                    phase = GamePhase.TRANSITIONING_TO_INVESTIGATING;
                }
            }
            else if (phase == GamePhase.TRANSITIONING_TO_INVESTIGATING)
            {
                // Move date back
                selectedDate.transform.position = Vector2.Lerp(interviewPosition, selectedOrigPos, phaseTimeElapsed / transitionToInvestigationPhaseDuration);

                if (phaseTimeElapsed > transitionToInvestigationPhaseDuration)
                {
                    phaseTimeElapsed = 0;
                    phase = GamePhase.INVESTIGATING;

                    if (p1Points == 5)
                        GameOver(0);
                    else if (p2Points == 5)
                        GameOver(1);
                }
            }
        }

        public void GameStart()
        {
            isGameStarted = true;
        }

        public void GameOver(int playerNum)
        {
            isGameOver = true;
            gameOverCanvas.SetActive(true);
            winnerText.text = "Player " + (playerNum + 1) + " wins!";
        }

        public bool IsGamePlayable()
        {
            return isGameStarted && !isGameOver;
        }

        private void GotoNextRound()
        {
            round++;

            switch (round)
            {
                case 1:
                    DateView date1 = CreateDate();
                    date1.transform.position = datePositions[1];
                    DateView date2 = CreateDate();
                    date2.transform.position = datePositions[2];
                    UnlockNewInfo(0);
                    break;
                case 2:
                    UnlockNewInfo();
                    break;
                case 3:
                    DateView date3 = CreateDate();
                    date3.transform.position = datePositions[0];
                    UpdateInfo();
                    break;
                case 4:
                    UnlockNewInfo();
                    break;
                case 5:
                    DateView date4 = CreateDate();
                    date4.transform.position = datePositions[3];
                    UpdateInfo();
                    break;
                case 6:
                    UnlockNewInfo();
                    break;
                case 7:
                    DateView date5 = CreateDate();
                    date5.transform.position = datePositions[4];
                    UpdateInfo();
                    break;
                default:
                    break;
            }
        }

        public void ScorePoint(int playerNum)
        {
            if (playerNum == 0)
            {
                p1Points++;
                p1CorrectObj.SetActive(true);
            }
            else if (playerNum == 1)
            {
                p2Points++;
                p2CorrectObj.SetActive(true);
            }

            SetHearts();
            phaseTimeElapsed = answeringPhaseDuration;
        }

        private DateView CreateDate()
        {
            GameObject dateObj = Instantiate(datePrefab);

            DateModel dateModel;
            do
            {
                dateModel = DateFactory.instance.CreateRandomModel();
            }
            while (DoesDateHaveDupe(dateModel));

            DateView dateView = dateObj.GetComponent<DateView>();
            dateView.Init(dateModel);
            dates.Add(dateView);

            return dateView;
        }

        private bool DoesDateHaveDupe(DateModel dateModel)
        {
            foreach (DateView date in dates)
            {
                if (dateModel.IsAppearanceTheSame(date.model))
                    return true;
            }

            return false;
        }

        private void UnlockNewInfo()
        {
            int infoType = 0;

            while (infoUsed.Contains(infoType))
            {
                infoType = Random.Range(1, 6);
            }

            UnlockNewInfo(infoType);
        }

        private void UnlockNewInfo(int infoType)
        {
            infoUsed.Add(infoType);

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            foreach (DateView dates in dates)
            {
                dates.ChangeDialogue(infoUsed);
            }
        }

        private void SetHearts()
        {
            p1Hearts.SetIconCount(p1Points);
            p2Hearts.SetIconCount(p2Points);
        }
    }
}
