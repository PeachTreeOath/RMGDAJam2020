using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiveXT.DuelOfTheDates
{
    public class AnswerView : MonoBehaviour
    {
        public TextMeshProUGUI p1Text;
        public TextMeshProUGUI p2Text;
        public TextMeshProUGUI answerText;
        public Image p1Correct;
        public Image p1Wrong;
        public Image p2Correct;
        public Image p2Wrong;

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

        public void ClearMarks()
        {
            p1Correct.enabled = false;
            p1Wrong.enabled = false;
            p2Correct.enabled = false;
            p2Wrong.enabled = false;
        }

        public void P1Correct()
        {
            p1Correct.enabled = true;
        }

        public void P1Wrong()
        {
            p1Wrong.enabled = true;
        }

        public void P2Correct()
        {
            p2Correct.enabled = true;
        }

        public void P2Wrong()
        {
            p2Wrong.enabled = true;
        }
    }
}