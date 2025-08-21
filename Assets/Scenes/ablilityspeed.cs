using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ablilityspeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



public class SpeedAbility : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostSpeed = 15f;
    public float boostDuration = 2f;
    public float cooldownDuration = 10f;

    private float boostTimer = 10f;
    private float cooldownTimer = 0f;
    private bool isBoosting = false;
    private bool isOnCooldown = false;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float currentSpeed = isBoosting ? boostSpeed : normalSpeed;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * currentSpeed * Time.deltaTime);


    }
}

