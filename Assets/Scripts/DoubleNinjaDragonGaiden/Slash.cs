using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.DoubleNinjaDragonGaiden
{
    public class Slash : MonoBehaviour
    {
        public int playerNum;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player") && collision.GetComponentInParent<NinjaController>().playerNum != playerNum)
            {
                collision.GetComponentInParent<NinjaController>().Die();
            }
            else if (collision.tag.Equals("Clone") && collision.GetComponentInParent<CloneController>().playerNum != playerNum)
            {
                collision.GetComponentInParent<CloneController>().Die();
            }
        }
    }
}