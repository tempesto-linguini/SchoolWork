﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int [] xpReqs = new int [20];

    // GameManager will appear to be a public static class.
    private static GameManager instance;

    public GameObject player;

    public static float maxHealth;
    public static float health;
    public static int playerLevel, experience, damage;


    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        damage = 40;
        experience = 0;
        playerLevel = 1;
        health = 50;
        maxHealth = 50;
        instance = this; //the key to creating a singleton
    }

    void Update()
    {
        PlayerPrefs.SetFloat("curHealth", health);
        PlayerPrefs.SetFloat("maxHealth", maxHealth);
        levelUp();
        isDead();
        //regen();
    }

    public static void addExperience(int e)
    {
        experience += e;
    }

    void levelUp()
    {
        if (experience >= xpReqs[playerLevel-1])
        {
            playerLevel++;
            maxHealth += 50;
            health = maxHealth;
            damage += 40;
        }
    }

    public static void removeHealth(int h)
    {
        health-=h;
        Debug.Log(health);
    }

    void isDead()
    {
        if (health <= 0)
        {
            if (SceneManager.GetActiveScene().name == "End" || SceneManager.GetActiveScene().name == "Victory")
            {
                Start();
                Destroy(gameObject);
            }
            else
            {
                PlayerPrefs.SetInt("Level", playerLevel);
                SceneManager.LoadScene("End");
            } 
        }
    }

    void regen()
    {
        if (health == maxHealth);
        else
        {
           health += 0.001f; 
        }
    }

    public static float getCurHealth()
    {
        return health;
    }

    public static float getMaxHealth()
    {
        return maxHealth;
    }
}