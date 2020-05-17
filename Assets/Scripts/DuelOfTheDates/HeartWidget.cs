using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class HeartWidget : MonoBehaviour
    {
        public SpriteRenderer heart1;
        public SpriteRenderer heart2;
        public SpriteRenderer heart3;
        public SpriteRenderer heart4;
        public SpriteRenderer heart5;
        public Sprite fullHeart;

        public void SetHeartCount(int count)
        {
            if (count > 0)
                heart1.sprite = fullHeart;
            if (count > 1)
                heart2.sprite = fullHeart;
            if (count > 2)
                heart3.sprite = fullHeart;
            if (count > 3)
                heart4.sprite = fullHeart;
            if (count > 4)
                heart5.sprite = fullHeart;
        }
    }
}