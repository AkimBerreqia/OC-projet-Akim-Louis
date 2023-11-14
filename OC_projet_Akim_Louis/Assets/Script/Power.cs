using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    private string[] basicLeftArm = { "0", "1", "2", "3", "4" };
    private string[] basicRightArm = { "9", "5", "6", "7", "8" };
    private string[] basicElements = { "neutral", "fire", "wind", "water", "lightning" };
    private string[] complexLeftArm = { "1", "2" };
    private string[] complexRightArm = { "9", "0" };
    private string[] complexElements = { "shadow", "light" };

    private string[] parts = { "neutral", "neutral" };
    public Color[] colorParts = { Color.gray, Color.gray };

    private Color[] BasicColorList = { Color.gray, Color.red, Color.green, Color.blue, Color.yellow };
    private Color[] ComplexColorList = { Color.black, Color.white };
    public Color CurrentColor = Color.gray;
    public SpriteRenderer LeftArm;
    public SpriteRenderer RightArm;

    private bool isShifted = false;
    private bool isTabed = false;

    public void ChangeElement(Material Arm, Color color)
    {
        Arm.SetColor("_Color", color);
        CurrentColor = color;
    }

    void FindElement(Color[] ColorList, string[] leftArm, string[] rightArm)
    {
        for (int i = 0; i < leftArm.Length; i++)
        {
            if (Input.GetKeyDown(leftArm[i]))
            {
                ChangeElement(LeftArm.material, ColorList[i]);
                parts[0] = basicElements[Convert.ToInt32(i)];
                colorParts[0] = ColorList[i];
            }
            else if (Input.GetKeyDown(rightArm[i]))
            {
                ChangeElement(RightArm.material, ColorList[i]);
                parts[1] = basicElements[Convert.ToInt32(i)];
                colorParts[1] = ColorList[i];
            }
        }
        Debug.Log("bras gauche: " + parts[0] + " - bras droit: " + parts[1]);
    }

    // Start is called before the first frame update
    void Start()
    {
        LeftArm.material.SetColor("_Color", Color.gray);
        RightArm.material.SetColor("_Color", Color.gray);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isTabed == false)
        {
            isTabed = true;
            isShifted = false;
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && isTabed == true && isShifted == false)
        {
            isShifted = true;
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && isTabed == true && isShifted == true)
        {
            isShifted = false;
        }

        else if (Input.GetKeyDown(KeyCode.Tab) && isTabed == true)
        {
            isTabed = false;
            isShifted = false;
        }

        if (isShifted == true)
        {
            FindElement(ComplexColorList, complexLeftArm, complexRightArm);
            Debug.Log("shadow : 1 | 9; light : 2 | 0");
        }

        else if (isTabed == true)
        {
            FindElement(BasicColorList, basicLeftArm, basicRightArm);
            Debug.Log("neutral : 0 | 9; fire : 1 | 5; wind : 2 | 6; water : 3 | 7; lightning : 4 | 8");
            Debug.Log("Press 'left shift' for complex powers: ");
        }

        else
        {
            Debug.Log("Press 'tab' for basic powers: ");
        }
    }
}
