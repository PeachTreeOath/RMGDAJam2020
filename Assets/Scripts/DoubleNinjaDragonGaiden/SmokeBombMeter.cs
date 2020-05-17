using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiveXT.DoubleNinjaDragonGaiden
{
    public class SmokeBombMeter : MonoBehaviour
    {
        public Image bombImage;
        public TextMeshProUGUI readyText;

        public void SetProgress(float ratio)
        {
            if (ratio >= 1)
                readyText.enabled = true;
            else
                readyText.enabled = false;

            bombImage.fillAmount = ratio;
        }
    }
}