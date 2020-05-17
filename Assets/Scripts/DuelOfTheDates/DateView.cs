using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class DateView : MonoBehaviour
    {
        public GameObject infoCanvas;
        public TextMeshProUGUI infoText;
        public SpriteRenderer hairSprite;
        public SpriteRenderer topSprite;
        public SpriteRenderer botSprite;

        public List<Sprite> hairSprites;
        public List<Sprite> topSprites;
        public List<Sprite> botSprites;

        [HideInInspector] public DateModel model;

        private int numPlayersTalking;

        public void Init(DateModel newModel)
        {
            model = newModel;

            hairSprite.sprite = hairSprites[newModel.hairType];
            hairSprite.color = DateFactory.instance.colorMap[newModel.hairColor];
            topSprite.sprite = topSprites[newModel.topType];
            topSprite.color = DateFactory.instance.colorMap[newModel.topColor];
            botSprite.sprite = botSprites[newModel.botType];
            botSprite.color = DateFactory.instance.colorMap[newModel.botColor];
        }

        public void ChangeDialogue(List<int> infoUsed)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int info in infoUsed)
            {
                switch (info)
                {
                    case 0:
                        sb.Append("My name is ").Append(model.firstName);
                        break;
                    case 1:
                        sb.Append("My bday is in ").Append(model.birthMonth);
                        break;
                    case 2:
                        sb.Append("My hobby is ").Append(model.hobby);
                        break;
                    case 3:
                        sb.Append("My blood type is ").Append(model.bloodType);
                        break;
                    case 4:
                        sb.Append("My hometown is ").Append(model.homeTown);
                        break;
                    case 5:
                        sb.Append("My fave movie is ").Append(model.movie);
                        break;
                }
                sb.Append("\n");
            }

            infoText.text = sb.ToString();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player"))
            {
                numPlayersTalking++;

                ShowInfo();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player"))
            {
                numPlayersTalking--;

                if (numPlayersTalking == 0)
                    HideInfo();
            }
        }

        private void ShowInfo()
        {
            infoCanvas.SetActive(true);
        }

        private void HideInfo()
        {
            infoCanvas.SetActive(false);
        }
    }
}