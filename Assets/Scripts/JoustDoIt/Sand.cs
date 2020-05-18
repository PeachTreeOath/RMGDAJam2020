using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.JoustDoIt
{
    public class Sand : MonoBehaviour
    {
        public SpriteRenderer spr;
        public float moveSpeed;

        private Vector2 origPos;

        // Start is called before the first frame update
        void Start()
        {
            origPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager_JoustDoIt.instance.phase != GamePhase.JOUSTING)
                return;

            transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
        }

        public void Activate()
        {
            transform.position = origPos;
            spr.enabled = true;
        }

        public void Deactivate()
        {
            spr.enabled = false;
        }
    }
}