﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Vector2Int gridPosition;
    public Material mouseOverMaterial; //Drag MouseOverMaterial into Square prefab's Square script to assign.

    //When the mouse hovers over the GameObject, it turns to this color
    static Color mouseOverColor;

    //This stores the GameObject’s original color
    Color originalColor;

    //Get the GameObject’s spriteRenderer to access the GameObject’s material and color
    SpriteRenderer spriteRenderer; //A spriteRenderer to get and swap colors

    private bool isCorner = false;
    private bool canMoveTo = false;

    public static void setCorner(Square s, bool v)//methods to set the variables
    {
        s.isCorner = v;
    }

    public static void setCanMoveTo(Square s, bool v)
    {
        s.canMoveTo = v;
    }

    public static bool getCorner(Square s)//accessor methods
    {
        return s.isCorner;
    }

    public static bool getCanMoveTo(Square s)
    {
        return s.canMoveTo;
    }

    //OnMouseOver() tells Unity what should happen when a mouse is over the object
    void OnMouseOver()
    {
        //Debug.Log(name); //unity implicitly defines "name" for you to get the "name" of the object.
        GameManager.UpdateUI(this); //the keyword "this" refers to the current object, aka "this" object.
        spriteRenderer.material.color = mouseOverColor; //change color while mouse is over the object
    }

    void OnMouseExit()
    {
        GameManager.UpdateUI();
        spriteRenderer.material.color = originalColor;
    }

    void Awake()
    {
        //Get the spriteRenderer component from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Get the original color of the GameObject
        originalColor = spriteRenderer.material.color;
        mouseOverColor = mouseOverMaterial.color;

        //mouseOverColor = Resources.Load<Material>("Materials/MouseOverColor").color;
        // avoid using Resources if you want to build the project see:
        // https://unity3d.com/learn/tutorials/topics/best-practices/resources-folder
    }

    void OnMouseDown()
    {
        GameManager.OnDown(this);
    }
}