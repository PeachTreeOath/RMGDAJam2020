using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.DoubleNinjaDragonGaiden
{
    public class Smoke : MonoBehaviour
    {
        public SpriteRenderer spr;
        public float opaqueDuration;
        public float transparentDuration;

        private Color transparentColor = new Color(1, 1, 1, 0);

        private float timeElapsed;

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;

            spr.color = Color.Lerp(Color.white, transparentColor, (timeElapsed - opaqueDuration) / transparentDuration);

            if (timeElapsed > opaqueDuration + transparentDuration)
                Destroy(gameObject);
        }
    }
}