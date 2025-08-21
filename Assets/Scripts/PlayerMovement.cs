using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles 2D player movement and rotation based on input.
/// Supports two players with separate input axes.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Player Settings")]
    public bool isPlayerOne = true;
    public float xSpeed = 3f;
    public float ySpeed = 3f;

    [Header("Boost Settings")]
    public float boostMultiplier = 2f;       // How much faster during boost
    public float boostDuration = 2f;         // How long the boost lasts
    public float boostCooldown = 5f;         // Time before boost can be used again
    public KeyCode boostKeyP1 = KeyCode.LeftShift;
    public KeyCode boostKeyP2 = KeyCode.RightShift;

    private float boostTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isBoosting = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Handle boost timing
        if (isBoosting)
        {
            boostTimer -= Time.fixedDeltaTime;
            if (boostTimer <= 0f)
            {
                isBoosting = false;
                cooldownTimer = boostCooldown;
            }
        }
        else if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.fixedDeltaTime;
        }

        // Get player input
        float xInput = 0f;
        float yInput = 0f;
        bool boostPressed = false;

        if (isPlayerOne)
        {
            xInput = Input.GetAxis("Horizontal_P1");
            yInput = Input.GetAxis("Vertical_P1");
            boostPressed = Input.GetKeyDown(boostKeyP1);
        }
        else
        {
            xInput = Input.GetAxis("Horizontal_P2");
            yInput = Input.GetAxis("Vertical_P2");
            boostPressed = Input.GetKeyDown(boostKeyP2);
        }

        // Activate boost if available
        if (boostPressed && cooldownTimer <= 0f && !isBoosting && !isPlayerOne)
        {
            isBoosting = true;
            boostTimer = boostDuration;
        }

        // Apply movement
        float currentXSpeed = isBoosting ? xSpeed * boostMultiplier : xSpeed;
        float currentYSpeed = isBoosting ? ySpeed * boostMultiplier : ySpeed;
        _rb.velocity = new Vector2(xInput * currentXSpeed, yInput * currentYSpeed);

        // Rotate the player to face movement direction
        Vector2 movement = new Vector2(xInput, yInput);
        if (movement != Vector2.zero)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            angle -= 90f;
            float snappedAngle = Mathf.Round(angle / 45f) * 45f;
            transform.rotation = Quaternion.Euler(0, 0, snappedAngle);
        }
    }

    public Vector2 GetVelocity()
    {
        return _rb.velocity;
    }
}

