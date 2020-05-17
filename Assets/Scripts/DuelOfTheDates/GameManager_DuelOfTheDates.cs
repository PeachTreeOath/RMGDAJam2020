using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public enum GamePhase
    {
        INVESTIGATING,
        TRANSITIONING_TO_ANSWERING,
        ANSWERING,
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
        public HeartWidget p1Hearts;
        public HeartWidget p2Hearts;
        public TextMeshProUGUI investigationTimer;
        public TextMeshProUGUI interviewTimer;
        public GameObject interviewObject;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;
        [HideInInspector] public GamePhase phase;

        private int round;
        private List<DateView> dates = new List<DateView>();
        private List<int> infoUsed = new List<int>();
        private int p1Points;
        private int p2Points;

        private float phaseTimeElapsed;
        private float investigationPhaseDuration = 1;
        private float transitionToAnsweringPhaseDuration = 3;
        private float answeringPhaseDuration = 10;
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
                //update timer

                if (phaseTimeElapsed > investigationPhaseDuration)
                {
                    selectedDate = dates[Random.Range(0, dates.Count)];
                    selectedOrigPos = selectedDate.transform.position;

                    phaseTimeElapsed = 0;
                    phase = GamePhase.TRANSITIONING_TO_ANSWERING;
                }
            }
            else if (phase == GamePhase.TRANSITIONING_TO_ANSWERING)
            {
                // Move players back and move date to interview position

                selectedDate.transform.position = Vector2.Lerp(selectedOrigPos, interviewPosition, phaseTimeElapsed / transitionToAnsweringPhaseDuration);
                p1Dater.transform.position = Vector2.Lerp(p1Dater.transform.position, p1DaterOrigPos, (phaseTimeElapsed * 2) / transitionToAnsweringPhaseDuration);
                p2Dater.transform.position = Vector2.Lerp(p2Dater.transform.position, p2DaterOrigPos, (phaseTimeElapsed * 2) / transitionToAnsweringPhaseDuration);

                if (phaseTimeElapsed > transitionToAnsweringPhaseDuration)
                {
                    interviewObject.SetActive(true);
                    InterviewView.instance.InitInterview(selectedDate.model, infoUsed[Random.Range(0, infoUsed.Count)]);
                    selectedDate.GetComponent<SpriteRenderer>().sortingLayerName = "Interview";

                    phaseTimeElapsed = 0;
                    phase = GamePhase.ANSWERING;
                }
            }
            else if (phase == GamePhase.ANSWERING)
            {
                //update timer

                if (phaseTimeElapsed > answeringPhaseDuration)
                {
                    selectedDate.GetComponent<SpriteRenderer>().sortingLayerName = "Default";

                    phaseTimeElapsed = 0;
                    phase = GamePhase.TRANSITIONING_TO_INVESTIGATING;
                }
            }
            else if (phase == GamePhase.TRANSITIONING_TO_INVESTIGATING)
            {

                if (phaseTimeElapsed > transitionToInvestigationPhaseDuration)
                {

                    phaseTimeElapsed = 0;
                    phase = GamePhase.INVESTIGATING;
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
                    DateView date3 = CreateDate();
                    date3.transform.position = datePositions[0];
                    break;
                case 3:
                    UnlockNewInfo();
                    break;
                case 4:
                    DateView date4 = CreateDate();
                    date4.transform.position = datePositions[3];
                    break;
                case 5:
                    UnlockNewInfo();
                    break;
                case 6:
                    DateView date5 = CreateDate();
                    date5.transform.position = datePositions[4];
                    break;
                default:
                    break;
            }
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

            foreach (DateView dates in dates)
            {
                dates.ChangeDialogue(infoUsed);
            }
        }

        private void SetHearts()
        {
            p1Hearts.SetHeartCount(p1Points);
            p2Hearts.SetHeartCount(p2Points);
        }
    }
}
