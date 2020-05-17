using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class AnswerView : MonoBehaviour
    {
        public TextMeshProUGUI p1Text;
        public TextMeshProUGUI p2Text;
        public TextMeshProUGUI answerText;

        public void SetAnswer(string answer)
        {
            answerText.text = answer;
        }

        public void P1Selected()
        {
            p1Text.enabled = true;
        }

        public void P1Deselected()
        {
            p1Text.enabled = false;
        }

        public void P2Selected()
        {
            p2Text.enabled = true;
        }

        public void P2Deselected()
        {
            p2Text.enabled = false;
        }
    }
}