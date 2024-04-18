using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    private static PowerUpsManager _instance;

    public static PowerUpsManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<PowerUpsManager>();
                if (_instance == null)
                    Debug.LogError("PowerUpsManager not found, can't create singleton object");
            }
            return _instance;

        }
    }

    public enum PowerUps
    {
        HEAD,
        ARMS,
        TORSO,
        LEGS
    }

    public Dictionary<PowerUps, int> collectedPowerUps = new Dictionary<PowerUps, int>();


    [Header("PowerUp Head")]
    public bool isHeadAttached = false;

    [Header("PowerUp InvisibleCoat")]
    public bool enemyCantSeeMe = false;

    [Header("PowerUp Lights")]
    public float redLightSpeed;
    public float greenLightSpeed;
    public float lightTimer = 10;
    public float internalLightTimer = 0;
    public bool isGreenActive = false;
    public bool isRedActive = false;

    private void Awake()
    {
        Debug.Log("Manager awake");
        collectedPowerUps.Add(PowerUps.HEAD, 0);
        collectedPowerUps.Add(PowerUps.TORSO, 0);
        collectedPowerUps.Add(PowerUps.ARMS, 0);
        collectedPowerUps.Add(PowerUps.LEGS, 0);
    }

    private void Update()
    {
        if (GameManager.instance.isGameStarted)
        {
            Head();
            Legs();
            Arms();
            Torso();
        }
    }

    public void IncrementPowerUp(PowerUps type)
    {
        collectedPowerUps[type] += 1;
        Debug.Log(collectedPowerUps[type]);
    }

    public void DecrementPowerUp(PowerUps type)
    {
        collectedPowerUps[type] -= 1;
    }
    public void ResetCollectedPowerUps()
    {
        foreach (PowerUps pw in System.Enum.GetValues(typeof(PowerUps)))
        {
            collectedPowerUps[pw] = 0;
        }
    }
    public void Legs()
    {
        if (collectedPowerUps[PowerUps.LEGS] > 0)
        {
            collectedPowerUps[PowerUps.LEGS] -= 1;
            int index = Random.Range(0, collectedPowerUps.Count);
            collectedPowerUps[collectedPowerUps.ElementAt(index).Key] += 1;
        }
    }
    public void Head()
    {
        // Start the shield if it wasn't active
        if (collectedPowerUps[PowerUps.HEAD] > 0 && !isHeadAttached)
        {
            isHeadAttached = true;
        }

        // Update the timer of the shield
        if (collectedPowerUps[PowerUps.HEAD] > 0)
        {
            //internalShieldTimer -= Time.deltaTime;
        }
        else if (collectedPowerUps[PowerUps.HEAD] > 0)
        {
            collectedPowerUps[PowerUps.HEAD] -= 1;
            isHeadAttached = false;
        }

    }
    public void Torso()
    {
        Player playerMovement = LevelManager.instance.playerInstance.GetComponent<Player>();

        if (PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.TORSO] > 0 && internalLightTimer > 0)
        {
            Debug.Log("Green");


            if (!isRedActive)
            {
                Debug.Log("Enter");

                //playerMovement.currentSpeed = greenLightSpeed;
                internalLightTimer -= Time.deltaTime;
                isGreenActive = true;
            }
            else
            {

                internalLightTimer = 0;
                //playerMovement.currentSpeed = playerMovement.moveSpeed;
                PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.TORSO] -= 1;
            }
        }
        else if (PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.TORSO] > 0 && internalLightTimer <= 0)
        {
            internalLightTimer = lightTimer;
            //playerMovement.currentSpeed = playerMovement.moveSpeed;
            PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.TORSO] -= 1;
            isGreenActive = false;
        }
    }

    public void Arms()
    {
        //PlayerMovement playerMovement = GameManager.instance.playerInstance.GetComponent<PlayerMovement>();

        if (PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.ARMS] > 0 && internalLightTimer > 0 && !PowerUpsManager.instance.isHeadAttached)
        {
            Debug.Log("Red");


            if (!isGreenActive)
            {
                Debug.Log("Enter");

                //playerMovement.currentSpeed = redLightSpeed;
                internalLightTimer -= Time.deltaTime;
                isRedActive = true;
            }
            else
            {
                internalLightTimer = 0;
                //playerMovement.currentSpeed = playerMovement.moveSpeed;
                PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.ARMS] -= 1;
            }
        }
        else if (PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.ARMS] > 0 && internalLightTimer <= 0 || PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.ARMS] > 0 && PowerUpsManager.instance.isHeadAttached)
        {
            internalLightTimer = lightTimer;
            //playerMovement.currentSpeed = playerMovement.moveSpeed;
            PowerUpsManager.instance.collectedPowerUps[PowerUpsManager.PowerUps.ARMS] -= 1;
            isRedActive = false;
        }
    }
    public int GetPowerUpCount(PowerUps powerUpType)
    {
        return collectedPowerUps[powerUpType];
    }
}