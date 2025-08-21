using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilitytimefreeze : MonoBehaviour
{
    //public Timer Gametimer;
    // Start is called before the first frame update
    void Start()
    {
        //Gametimer = GameObject.Find("timer").GetComponent<Timer>();
    }
    public class TimeFreezeAbility : MonoBehaviour
    {
        [Header("Time Freeze Settings")]
        public float freezeDuration = 2f;     // How long time stays frozen
        public float cooldownDuration = 5f;   // Time before ability can be used again
        public KeyCode freezeKey = KeyCode.F; // Key to activate time freeze

        [Header("Player Key Bind")]
        public KeyCode keyBind = KeyCode.E;

        private bool isFreezing = false;
        private float freezeTimer = 0f;
        private float cooldownTimer = 0f;

        void Update()
        {
            // Activate time freeze
            if (Input.GetKeyDown(freezeKey) && cooldownTimer <= 0f && !isFreezing)
            {
                Time.timeScale = 0f; // Freeze time
                isFreezing = true;
                freezeTimer = freezeDuration;
            }

            // Handle freeze duration
            if (isFreezing)
            {
                freezeTimer -= Time.unscaledDeltaTime;
                if (freezeTimer <= 0f)
                {
                    Time.timeScale = 1f; // Resume time
                    isFreezing = false;
                    cooldownTimer = cooldownDuration;
                }
            }

            // Handle cooldown
            if (cooldownTimer > 0f && !isFreezing)
            {
                cooldownTimer -= Time.unscaledDeltaTime;
            }
        }
    }
}

    