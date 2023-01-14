using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("Ship moves")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("How fast player moves horizontal")] [SerializeField] float xRange = 10f;
    [Tooltip("How fast player moves Vertical")] [SerializeField] float yRange = 10f;

    [Header("Laser gun array")]
    [SerializeField] GameObject[] lasers;

    [Header("Screen possition based tuning")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float controlPitchFactor =-10f;

    [Header("Player input based tuning")]
    [SerializeField] float positionYawFactor = -2f;
    [SerializeField] float controllRollFactor = 5f;

    float yThrow, xThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcesFiring();
    }

    void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controllRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

     void ProcessTranslation()
    {
         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");

        float yOffSet = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        float xOffSet = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        transform.localPosition = new Vector3
            (clampedXPos,
            clampedYPos,
            transform.localPosition.z);
    }

    void ProcesFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);

        }else
        {
            SetLasersActive(false);
        }
            

        
    }

  
    private void SetLasersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
   
   
}
