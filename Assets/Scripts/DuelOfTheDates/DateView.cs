using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public class DateView : MonoBehaviour
    {
        [HideInInspector] public DateModel model;

        private int numPlayersTalking;

        public void Init(DateModel newModel)
        {
            model = newModel;

            //TODO: Change appearance
            
        }

        public void ChangeDialogue()
        {
            //TODO: Dynamically create dialogue based on the round which randomly
            // picks stats to use
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
            Debug.Log("OIWJER");
        }

        private void HideInfo()
        {
            Debug.Log("OIWJER");
        }
    }
}