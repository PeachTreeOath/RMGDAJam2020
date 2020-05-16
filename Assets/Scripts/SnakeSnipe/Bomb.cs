using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.SnakeSnipe
{
    public class Bomb : MonoBehaviour
    {
        public TextMeshProUGUI countdownText;
        public GameObject bombImage;
        public GameObject explosionImage;
        public GameObject countdownCanvas;
        public Collider2D explosionCollider;

        private float timeToExplode;
        private bool isExploded;

        private void Start()
        {
            timeToExplode = 3;
        }

        // Update is called once per frame
        void Update()
        {
            timeToExplode -= Time.deltaTime;

            countdownText.text = ((int)(timeToExplode + 1)).ToString();

            if (timeToExplode < 0 && !isExploded)
            {
                isExploded = true;

                bombImage.SetActive(false);
                explosionImage.SetActive(true);
                countdownCanvas.SetActive(false);
                explosionCollider.enabled = true;

                Destroy(gameObject, 0.2f);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Tail"))
            {
                collision.GetComponentInParent<SnakeController>().TakeHit();
            }
        }
    }
}