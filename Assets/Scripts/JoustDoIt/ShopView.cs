using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.JoustDoIt
{
    public class InterviewView : Singleton<InterviewView>
    {
        public TextMeshProUGUI p1cash;
        public TextMeshProUGUI p2cash;
        public List<ShopItem> shopItems;

        [HideInInspector] public int p1SelectedAnswer;
        [HideInInspector] public int p2SelectedAnswer;

        private int currentCorrectAnswer;
        private bool p1Locked;
        private bool p2Locked;

        public void ClearSelections()
        {
            foreach (ShopItem view in shopItems)
            {
                view.P1Deselected();
                view.P2Deselected();
            }
        }

        public void SetSelections()
        {
            shopItems[p1SelectedAnswer].P1Selected();
            shopItems[p2SelectedAnswer].P2Selected();
        }

        public void InitInterview()
        {
            shopItems.ForEach(o => o.ClearMarks());
            p1Locked = false;
            p2Locked = false;

            ClearSelections();
            p1SelectedAnswer = 2;
            p2SelectedAnswer = 2;
            SetSelections();
        }

        public void MoveSelectionLeft(int playerNum)
        {
            if (playerNum == 0 && !p1Locked)
            {
                p1SelectedAnswer--;
                if (p1SelectedAnswer == -1)
                    p1SelectedAnswer = 5;
            }
            else if (playerNum == 1 && !p2Locked)
            {
                p2SelectedAnswer--;
                if (p2SelectedAnswer == -1)
                    p2SelectedAnswer = 5;
            }

            ClearSelections();
            SetSelections();
        }

        public void MoveSelectionRight(int playerNum)
        {
            if (playerNum == 0 && !p1Locked)
            {
                p1SelectedAnswer++;
                if (p1SelectedAnswer == 6)
                    p1SelectedAnswer = 0;
            }
            else if (playerNum == 1 && !p2Locked)
            {
                p2SelectedAnswer++;
                if (p2SelectedAnswer == 6)
                    p2SelectedAnswer = 0;
            }

            ClearSelections();
            SetSelections();
        }

        public void BuyItem(int playerNum)
        {
           
        }
    }
}