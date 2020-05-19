using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.JoustDoIt
{
    public class ResultsSequence : Singleton<ResultsSequence>
    {
        public GameObject seq;
        public SpriteRenderer p1Jouster;
        public SpriteRenderer p2Jouster;
        public Vector2 p1FinalPos;
        public Vector2 p2FinalPos;
        public GameObject deathPrefab;

        private Vector2 p1OrigPos;
        private Vector2 p2OrigPos;

        private float moveDuration = 2;
        private int winner;
        private bool isPlaying;
        private float timeElapsed;

        public void Start()
        {
            p1OrigPos = p1Jouster.transform.position;
            p2OrigPos = p2Jouster.transform.position;
        }

        private void Update()
        {
            if (isPlaying)
            {
                timeElapsed += Time.deltaTime;

                p1Jouster.transform.position = Vector2.Lerp(p1OrigPos, p1FinalPos, timeElapsed / moveDuration);
                p2Jouster.transform.position = Vector2.Lerp(p2OrigPos, p2FinalPos, timeElapsed / moveDuration);

                if (timeElapsed > moveDuration)
                {
                    isPlaying = false;

                    GameManager_JoustDoIt.instance.ScorePoint(winner);

                    if (winner == 0)
                    {
                        GameObject death = Instantiate(deathPrefab);
                        death.transform.position = p2Jouster.transform.position;
                        p2Jouster.enabled = false;
                    }
                    else
                    {
                        GameObject death = Instantiate(deathPrefab);
                        death.transform.position = p1Jouster.transform.position;
                        p1Jouster.enabled = false;
                    }
                }
            }
        }

        public void PlayWinSequence(int newWinner)
        {
            winner = newWinner;
            isPlaying = true;
            p1Jouster.enabled = true;
            p2Jouster.enabled = true;
            timeElapsed = 0;
        }

        public void Show()
        {
            seq.SetActive(true);
        }

        public void Hide()
        {
            seq.SetActive(false);
        }
    }
}