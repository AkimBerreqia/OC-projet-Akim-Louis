using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public GameOverAndPauseMenu gameOverAndPauseMenu;
    public PlayerHealth playerHealth;

    public GameObject SpellsMenu;

    public GameObject BasicSpellsTitle;
    public GameObject BasicSpellsText;

    public GameObject ComplexSpellsTitle;
    public GameObject ComplexSpellsText;

    public GameObject OpenBasicSpellsMenu;
    public GameObject CloseBasicSpellsMenu;

    public GameObject OpenComplexSpellsMenu;
    public GameObject CloseComplexSpellsMenu;

    public RawImage Arm;

    // private string[] states = {keyboardAssignment, color, manaCost, damage, speed, ennemyDamage, ennemySpeed};
    private object[,] basicStatesArray = {
        { "1", Color.gray, 0f, 20f, 1f, 1f, 1f }, // neutral
        { "2", Color.red, -20f, 20f, 1f, 1f, 1f }, // fire
        { "3", Color.blue, -20f, 20f, 1f, .5f, .5f }, // water
        { "4", Color.yellow, -20f, 40f, 1.5f, 1f, 1f }, // lightning
        { "5", Color.green, -20f, 0f, 0f, 0f, 1f } // wind
    };


    private object[,] complexStatesArray = {
        { "1", Color.black, -30f, 50f, .5f, 1f, 1f }, // shadow
        { "2", Color.white, -30f, 20f, 4f, 1f, 1f } // light
    };

    public Color CurrentColor = Color.gray;
    public float currentManaCost = 0;
    public float currentDamage = 20f;
    public float speedMultiplicator = 1f;
    public float ennemyDamageMultiplicator = 1f;
    public float ennemySpeedMultiplicator = 1f;
    public float fireDamage;

    public bool spellIsBuffed = false;
    private bool isAlted = false;
    private bool isTabed = false;

    public void ChangeElement(RawImage Arm, Color color)
    {
        Arm.color = color;
    }

    // Update current stuff
    void FindElement(object[,] statesArray)
    {
        for (int i = 0; i < statesArray.GetLength(0); i++)
        {
            if (Input.GetKeyDown(statesArray[i, 0].ToString()))
            {
                CurrentColor = (Color)statesArray[i, 1];
                currentManaCost = (float)statesArray[i, 2];
                currentDamage = (float)statesArray[i, 3];

                if (i == 1)
                {
                    fireDamage = currentDamage;
                }

                speedMultiplicator = (float)statesArray[i, 4];
                ennemyDamageMultiplicator = (float)statesArray[i, 5];
                ennemySpeedMultiplicator = (float)statesArray[i, 6];

                ChangeElement(Arm, CurrentColor);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Arm.color = Color.gray;

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
        if (gameOverAndPauseMenu.isPaused == false && playerHealth.isAlive == true)
        {
            // If basic spells menu is closed when you click on "Tab",
            // it initializes the bools for the basic and complex spells menus
            if (Input.GetKeyDown(KeyCode.Tab) && isTabed == false)
            {
                isTabed = true;
                isAlted = false;
            }

            // If basic spells menu is opened and complex spells menu is closed,
            // the complex spells menu can be opened
            else if (Input.GetKeyDown(KeyCode.LeftAlt) && isTabed == true && isAlted == false)
            {
                isAlted = true;
            }

            // If basic and complex spells menus are opened when you click on "LeftAlt",
            // the complex spells menu can be closed and then can return back on the basic one
            else if (Input.GetKeyDown(KeyCode.LeftAlt) && isTabed == true && isAlted == true)
            {
                isAlted = false;
            }

            // If any of the menus are opened when you click on "Tab",
            // every menus can be closed
            else if (Input.GetKeyDown(KeyCode.Tab) && isTabed == true)
            { 
                isTabed = false;
                isAlted = false;
            }

            // It opens the complex spells menu
            if (isAlted == true)
            {
                FindElement(complexStatesArray);

                BasicSpellsTitle.SetActive(false);
                BasicSpellsText.SetActive(false);

                ComplexSpellsTitle.SetActive(true);
                ComplexSpellsText.SetActive(true);

                OpenBasicSpellsMenu.SetActive(false);
                CloseBasicSpellsMenu.SetActive(true);

                OpenComplexSpellsMenu.SetActive(false);
                CloseComplexSpellsMenu.SetActive(true);

                Debug.Log("shadow : 1; light : 2");
            }

            // It opens the basic spells menu
            else if (isTabed == true)
            {
                FindElement(basicStatesArray);

                SpellsMenu.SetActive(true);

                BasicSpellsTitle.SetActive(true);
                BasicSpellsText.SetActive(true);

                ComplexSpellsTitle.SetActive(false);
                ComplexSpellsText.SetActive(false);

                OpenBasicSpellsMenu.SetActive(false);
                CloseBasicSpellsMenu.SetActive(true);

                OpenComplexSpellsMenu.SetActive(true);
                CloseComplexSpellsMenu.SetActive(false);

                Debug.Log("neutral : 1; fire : 2; wind : 3; water : 4; lightning : 5");
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
}
