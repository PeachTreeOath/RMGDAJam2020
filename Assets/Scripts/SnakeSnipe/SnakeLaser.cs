using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FiveXT.SnakeSnipe
{
    public class SnakeLaser : MonoBehaviour
    {
        // Inspector set
        public float shotSpeed;
        public Rigidbody2D rb;

        // Update is called once per frame
        void FixedUpdate()
        {
            float currSpeed = shotSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + (Vector2)(rb.transform.up * currSpeed));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Tail"))
            {
                collision.gameObject.GetComponentInParent<SnakeController>().TakeHit();
            }

            Destroy(gameObject);
        }
    }
}
