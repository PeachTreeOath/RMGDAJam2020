using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.JoustDoIt
{
    public class Knight : MonoBehaviour
    {
        public Vector2 startLoc;
        public Vector2 endLoc;
        public float startSize;
        public float endSize;

        private float timeElapsed;

        // Update is called once per frame
        void Update()
        {
            timeElapsed += Time.deltaTime;

            float ratio = timeElapsed / GameManager_JoustDoIt.instance.joustingPhaseDuration;
            float newX = EaseInQuad(startLoc.x, endLoc.x, ratio);
            float newY = EaseInQuad(startLoc.y, endLoc.y, ratio);
            transform.position = new Vector2(newX, newY);

            float newSize = EaseInQuad(startSize, endSize, ratio);
            transform.localScale = new Vector3(newSize, newSize, 1);
        }

        public void Reset()
        {
            timeElapsed = 0;
            transform.position = startLoc;
            transform.localScale = new Vector3(startSize, startSize, 1);
        }

        private float EaseInQuad(float start, float end, float value)
        {
            end -= start;
            return end * value * value + start;
        }
    }
}