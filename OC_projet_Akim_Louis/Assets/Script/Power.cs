using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public GameObject SpellsMenu;

    public GameObject BasicSpellsTitle;
    public GameObject BasicSpellsText;

    public GameObject ComplexSpellsTitle;
    public GameObject ComplexSpellsText;

    public GameObject OpenBasicSpellsMenu;
    public GameObject CloseBasicSpellsMenu;

    public GameObject OpenComplexSpellsMenu;
    public GameObject CloseComplexSpellsMenu;

    private string[] basicLeftArm = { "0", "1", "2", "3", "4" };
    private string[] basicRightArm = { "9", "5", "6", "7", "8" };
    private string[] basicElements = { "neutral", "fire", "wind", "water", "lightning" };
    private string[] complexLeftArm = { "1", "2" };
    private string[] complexRightArm = { "9", "0" };
    private string[] complexElements = { "shadow", "light" };

    private string[] parts = { "neutral", "neutral" };
    public Color[] colorParts = { Color.gray, Color.gray };

    private Color[] BasicColorList = 
        { Color.gray, Color.red, Color.green, Color.blue, Color.yellow };
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

        SpellsMenu.SetActive(false);

        BasicSpellsTitle.SetActive(false);
        BasicSpellsText.SetActive(false);

        ComplexSpellsTitle.SetActive(false);
        ComplexSpellsText.SetActive(false);

        OpenBasicSpellsMenu.SetActive(true);
        CloseBasicSpellsMenu.SetActive(false);

        OpenComplexSpellsMenu.SetActive(false);
        CloseComplexSpellsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // If basic spells menu is closed when you click on "Tab",
        // it initializes the bools for the basic and complex spells menus
        if (Input.GetKeyDown(KeyCode.Tab) && isTabed == false)
        {
            isTabed = true;
            isShifted = false;
        }

        // If basic spells menu is opened and complex spells menu is closed,
        // the complex spells menu can be opened
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isTabed == true && isShifted == false)
        {
            isShifted = true;
        }

        // If basic and complex spells menus are opened when you click on "LeftShift",
        // the complex spells menu can be closed and then can return back on the basic one
        else if (Input.GetKeyDown(KeyCode.LeftShift) && isTabed == true && isShifted == true)
        {
            isShifted = false;
        }

        // If any of the menus are opened when you click on "Tab",
        // every menus can be closed
        else if (Input.GetKeyDown(KeyCode.Tab) && isTabed == true)
        { 
            isTabed = false;
            isShifted = false;
        }

        // It opens the complex spells menu
        if (isShifted == true)
        {
            FindElement(ComplexColorList, complexLeftArm, complexRightArm);

            BasicSpellsTitle.SetActive(false);
            BasicSpellsText.SetActive(false);

            ComplexSpellsTitle.SetActive(true);
            ComplexSpellsText.SetActive(true);

            OpenBasicSpellsMenu.SetActive(false);
            CloseBasicSpellsMenu.SetActive(true);

            OpenComplexSpellsMenu.SetActive(false);
            CloseComplexSpellsMenu.SetActive(true);

            Debug.Log("shadow : 1 | 9; light : 2 | 0");
        }

        // It opens the basic spells menu
        else if (isTabed == true)
        {
            FindElement(BasicColorList, basicLeftArm, basicRightArm);

            SpellsMenu.SetActive(true);

            BasicSpellsTitle.SetActive(true);
            BasicSpellsText.SetActive(true);

            ComplexSpellsTitle.SetActive(false);
            ComplexSpellsText.SetActive(false);

            OpenBasicSpellsMenu.SetActive(false);
            CloseBasicSpellsMenu.SetActive(true);

            OpenComplexSpellsMenu.SetActive(true);
            CloseComplexSpellsMenu.SetActive(false);

            Debug.Log("neutral : 0 | 9; fire : 1 | 5; wind : 2 | 6; water : 3 | 7; lightning : 4 | 8");
            Debug.Log("Press 'left shift' for complex powers: ");
        }

        // It closes every spells menus
        else
        {
            SpellsMenu.SetActive(false);

            BasicSpellsTitle.SetActive(false);
            BasicSpellsText.SetActive(false);

            ComplexSpellsTitle.SetActive(false);
            ComplexSpellsText.SetActive(false);

            OpenBasicSpellsMenu.SetActive(true);
            CloseBasicSpellsMenu.SetActive(false);

            OpenComplexSpellsMenu.SetActive(false);
            CloseComplexSpellsMenu.SetActive(false);
            Debug.Log("Press 'tab' for basic powers: ");
        }
    }
}
