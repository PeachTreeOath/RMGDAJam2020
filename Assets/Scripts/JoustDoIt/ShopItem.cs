using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiveXT.JoustDoIt
{
    public class ShopItem : MonoBehaviour
    {
        public int itemId;
        public int price;
        public TextMeshProUGUI p1Text;
        public TextMeshProUGUI p2Text;
        public Image p1Bought;
        public Image p2Bought;

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

        public void P1Bought()
        {
            p1Bought.enabled = true;
        }

        public void P2Bought()
        {
            p2Bought.enabled = true;
        }

        public void ClearMarks()
        {
            p1Bought.enabled = false;
            p2Bought.enabled = false;
        }
    }
}