using FiveXT.SnakeSnipe;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.Core
{
    public class GameStartCountdown : Singleton<GameStartCountdown>
    {
        public TextMeshProUGUI countdownText;
        public float countdownTime;

        private List<IGameStartCountdownListener> listeners = new List<IGameStartCountdownListener>();
        private float currCountdownTime;
        private bool isCountingDown;

        private void Start()
        {
            StartCountdown();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isCountingDown)
                return;

            currCountdownTime -= Time.deltaTime;

            countdownText.text = ((int)(currCountdownTime + 1)).ToString();

            if (currCountdownTime < 0)
            {
                foreach (IGameStartCountdownListener listener in listeners)
                    listener.GameStart();

                countdownText.enabled = false;
                isCountingDown = false;
            }
        }

        public void RegisterListener(IGameStartCountdownListener listener)
        {
            listeners.Add(listener);
        }

        public void StartCountdown()
        {
            currCountdownTime = countdownTime;
            isCountingDown = true;
        }
    }
}