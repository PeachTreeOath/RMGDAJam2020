using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.JoustDoIt
{
    public class ShopView : Singleton<ShopView>
    {
        public TextMeshProUGUI p1cash;
        public TextMeshProUGUI p2cash;
        public List<ShopItem> shopItems;

        [HideInInspector] public int p1SelectedAnswer;
        [HideInInspector] public int p2SelectedAnswer;

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

        public void InitShop()
        {
            shopItems.ForEach(o => o.ClearMarks());
            p1Locked = false;
            p2Locked = false;

            ClearSelections();
            p1SelectedAnswer = 2;
            p2SelectedAnswer = 2;
            SetSelections();
            GameManager_JoustDoIt.instance.UpdateCash();
        }

        public void MoveSelectionLeft(int playerNum)
        {
            if (playerNum == 0 && !p1Locked)
            {
                p1SelectedAnswer--;
                if (p1SelectedAnswer == -1)
                    p1SelectedAnswer = 6;
            }
            else if (playerNum == 1 && !p2Locked)
            {
                p2SelectedAnswer--;
                if (p2SelectedAnswer == -1)
                    p2SelectedAnswer = 6;
            }

            ClearSelections();
            SetSelections();
        }

        public void MoveSelectionRight(int playerNum)
        {
            if (playerNum == 0 && !p1Locked)
            {
                p1SelectedAnswer++;
                if (p1SelectedAnswer == 7)
                    p1SelectedAnswer = 0;
            }
            else if (playerNum == 1 && !p2Locked)
            {
                p2SelectedAnswer++;
                if (p2SelectedAnswer == 7)
                    p2SelectedAnswer = 0;
            }

            ClearSelections();
            SetSelections();
        }

        public void BuyItem(int playerNum)
        {
            if (playerNum == 0)
            {
                ShopItem currItem = shopItems[p1SelectedAnswer];

                if (currItem.itemId == 6) // Exit
                {
                    p1Locked = true;
                    shopItems[p1SelectedAnswer].P1Bought();
                }
                else
                {
                    if (!GameManager_JoustDoIt.instance.p1BoughtItems.Contains(currItem.itemId) && GameManager_JoustDoIt.instance.p1Cash >= currItem.price)
                    {
                        GameManager_JoustDoIt.instance.p1Cash -= currItem.price;
                        GameManager_JoustDoIt.instance.p1BoughtItems.Add(currItem.itemId);
                        shopItems[p1SelectedAnswer].P1Bought();
                        ClearSelections();
                        SetSelections();
                    }
                }
            }
            else
            {
                ShopItem currItem = shopItems[p2SelectedAnswer];

                if (currItem.itemId == 6) // Exit
                {
                    p2Locked = true;
                    shopItems[p2SelectedAnswer].P2Bought();
                }
                else
                {
                    if (!GameManager_JoustDoIt.instance.p2BoughtItems.Contains(currItem.itemId) && GameManager_JoustDoIt.instance.p2Cash >= currItem.price)
                    {
                        GameManager_JoustDoIt.instance.p2Cash -= currItem.price;
                        GameManager_JoustDoIt.instance.p2BoughtItems.Add(currItem.itemId);
                        shopItems[p2SelectedAnswer].P2Bought();
                        ClearSelections();
                        SetSelections();
                    }
                }
            }

            GameManager_JoustDoIt.instance.UpdateCash();

            if (p1Locked && p2Locked)
                GameManager_JoustDoIt.instance.GotoJoustingPhase();
        }
    }
}