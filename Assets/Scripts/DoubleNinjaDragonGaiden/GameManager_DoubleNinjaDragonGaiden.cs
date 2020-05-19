using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FiveXT.DoubleNinjaDragonGaiden
{
    public class GameManager_DoubleNinjaDragonGaiden : Singleton<GameManager_DoubleNinjaDragonGaiden>, IGameStartCountdownListener
    {
        public GameObject gameOverCanvas;
        public TextMeshProUGUI winnerText;
        public ScoreWidget p1ScoreIcon;
        public ScoreWidget p2ScoreIcon;
        public NinjaController ninja1;
        public NinjaController ninja2;
        public CloneController clone1;
        public CloneController clone2;
        public GameObject p1KOObj;
        public GameObject p2KOObj;
        public GameObject drawKOObj;
        public float resetDuration;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;

        private int p1Points;
        private int p2Points;
        private bool isResetting;
        private float resetTimeElapsed;

        private Vector2 origP1Pos;
        private Vector2 origP2Pos;

        private bool p1Dead;
        private bool p2Dead;

        private void Start()
        {
            GameStartCountdown.instance.RegisterListener(this);
            origP1Pos = ninja1.transform.position;
            origP2Pos = ninja2.transform.position;
        }

        private void Update()
        {
            if (isResetting)
            {
                resetTimeElapsed += Time.deltaTime;

                if (resetTimeElapsed > resetDuration)
                {
                    ResetGame();
                }
            }
        }

        public void GameStart()
        {
            clone1.ResetSmokeMeter();
            clone2.ResetSmokeMeter();
            clone1.ThrowSmokeBomb();
            clone2.ThrowSmokeBomb();

            isGameStarted = true;
        }

        public void ResetGame()
        {
            ninja1.Revive();
            ninja2.Revive();
            clone1.Revive();
            clone2.Revive();
            p1Dead = false;
            p2Dead = false;

            ninja1.transform.position = origP1Pos;
            ninja2.transform.position = origP2Pos;
            clone1.transform.position = origP1Pos;
            clone2.transform.position = origP2Pos;

            p1KOObj.gameObject.SetActive(false);
            p2KOObj.gameObject.SetActive(false);
            drawKOObj.gameObject.SetActive(false);

            isResetting = false;

            GameStartCountdown.instance.StartCountdown();
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

        public void ScorePoint(int playerNum)
        {
            if (playerNum == 0)
            {
                p1Points++;
            }
            else if (playerNum == 1)
            {
                p2Points++;
            }

            SetScoreIcons();
        }

        public void OnNinjaDeath(int playerNum)
        {
            if (playerNum == 0)
            {
                p1Dead = true;
            }
            else
            {
                p2Dead = true;
            }
        }

        public void LateUpdate()
        {
            if (!p1Dead && !p2Dead) return;

            if (!isResetting)
            {
                if (p1Dead && p2Dead)
                {
                    drawKOObj.gameObject.SetActive(true);
                }
                else if (p1Dead)
                {
                    ScorePoint(1);
                    p2KOObj.gameObject.SetActive(true);
                }
                else if (p2Dead)
                {
                    ScorePoint(0);
                    p1KOObj.gameObject.SetActive(true);
                }

                if (p1Points == 5)
                {
                    GameOver(0);
                    p1KOObj.gameObject.SetActive(false);
                    p2KOObj.gameObject.SetActive(false);
                }
                else if (p2Points == 5)
                {
                    GameOver(1);
                    p1KOObj.gameObject.SetActive(false);
                    p2KOObj.gameObject.SetActive(false);
                }
                else
                {
                    isResetting = true;
                    isGameStarted = false;
                    resetTimeElapsed = 0;

                }

                p1Dead = false;
                p2Dead = false;
            }
        }

        public void OnCloneDeath(int playerNum)
        {
            // Do nothing, might need this later
        }

        private void SetScoreIcons()
        {
            p1ScoreIcon.SetIconCount(p1Points);
            p2ScoreIcon.SetIconCount(p2Points);
        }
    }
}
