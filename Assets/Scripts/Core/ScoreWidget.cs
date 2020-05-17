using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.Core
{
    public class ScoreWidget : MonoBehaviour
    {
        public SpriteRenderer icon1;
        public SpriteRenderer icon2;
        public SpriteRenderer icon3;
        public SpriteRenderer icon4;
        public SpriteRenderer icon5;
        public Sprite fullIcon;

        public void SetIconCount(int count)
        {
            if (count > 0)
                icon1.sprite = fullIcon;
            if (count > 1)
                icon2.sprite = fullIcon;
            if (count > 2)
                icon3.sprite = fullIcon;
            if (count > 3)
                icon4.sprite = fullIcon;
            if (count > 4)
                icon5.sprite = fullIcon;
        }
    }
}