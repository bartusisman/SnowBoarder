using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torque_amount = 1f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostMultiplier = 1.05f;

    private float accumulatedRotation = 0f;
    private float lastRotation = 0f;
    private int totalSpinCount = 0; // Track the total number of spins

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

        if (surfaceEffector2D != null)
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
        }
        
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torque_amount * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torque_amount * Time.deltaTime);
        }

        TrackRotation();
    }

    void TrackRotation()
    {
        // Get the current rotation in degrees
        float currentRotation = rb2d.rotation;
        float rotationDelta = currentRotation - lastRotation;

        // Adjust the rotationDelta to account for crossing the -180 to 180 degree line
        if (rotationDelta < -180)
        {
            rotationDelta += 360;
        }
        else if (rotationDelta > 180)
        {
            rotationDelta -= 360;
        }

        accumulatedRotation += rotationDelta;
        lastRotation = currentRotation;

        // Check if a full 360-degree rotation is completed
        if (Mathf.Abs(accumulatedRotation) >= 330f)
        {
            ApplyBoost();
            accumulatedRotation = 0f; // Reset the accumulated rotation
            totalSpinCount++; // Increment the spin count
        }
    }

    void ApplyBoost()
    {
        if (surfaceEffector2D != null)
        {
            surfaceEffector2D.speed *= boostMultiplier;
            Debug.Log("Boost Applied! New speed: " + surfaceEffector2D.speed);
        }
    }

    // Method to get the current speed of the player
    public float GetCurrentSpeed()
    {
        if (surfaceEffector2D != null)
        {
            return surfaceEffector2D.speed;
        }
        return 0f;
    }

    public int GetTotalSpinCount()
    {
        return totalSpinCount;
    }
}
