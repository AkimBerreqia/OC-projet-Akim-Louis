using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Projectile projectile;
    public RectTransform manaTransform;

    public float currentMana;
    public float maxMana = 100;
    public float height = 70;
    public float width = 360;
    public float newWidth;
    public bool canRecover = false;

    public void SetMana(float increaseBy)
    {
        if (increaseBy > maxMana - currentMana)
        {
            currentMana = maxMana;
        }

        else if (currentMana < -increaseBy && increaseBy < 0)
        {
            currentMana = 0;
        }

        else
        {
            currentMana += increaseBy;
        }

        newWidth = currentMana / maxMana * width;
        manaTransform.sizeDelta = new Vector2(newWidth, height);
    }

    public void RecoverMana(float manaCooldown, float increaseBy, bool isCoolDowned)
    { 

        if (currentMana != maxMana && isCoolDowned == false)
        {

            if (Time.time - projectile.timeShot >= manaCooldown)
            {
                SetMana(increaseBy);
                projectile.timeShot = Time.time;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRecover == true)
        {
            RecoverMana(projectile.projectileCoolDown, 10f, projectile.coolDown);
        }
    }
}
