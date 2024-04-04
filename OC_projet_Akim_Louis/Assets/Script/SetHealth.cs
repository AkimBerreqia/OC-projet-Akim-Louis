using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHealth : MonoBehaviour
{
    public object[] TakeDamage(float damage, float invincibleFramesCoolDown, float currentHealth, float maxHealth, float newWidth, float width, float height, RectTransform healthTransform, float initialDamage)
    {
        if (Time.time - invincibleFramesCoolDown >= initialDamage)
        {
            if (currentHealth < System.Math.Abs(damage))
            {
                currentHealth = 0;
            }

            else
            {
                currentHealth -= damage;
            }
            
            initialDamage = Time.time;
            newWidth = currentHealth / maxHealth * width;
        }

        object[] returnObject = { currentHealth, initialDamage, newWidth };

        return returnObject;
    }

    public object[] GainHealth(float increaseBy, float invincibleFramesCoolDown, float currentHealth, float maxHealth, float newWidth, float width, float height, RectTransform healthTransform, float initialHealthSetting)
    {
        if (Time.time - invincibleFramesCoolDown >= initialHealthSetting)
        {
            if (increaseBy > maxHealth - currentHealth)
            {
                currentHealth = maxHealth;
            }

            else if (currentHealth < System.Math.Abs(increaseBy) && increaseBy < 0)
            {
                currentHealth = 0;
            }

            else
            {
                currentHealth += increaseBy;
            }
            
            initialHealthSetting = Time.time;
            newWidth = currentHealth / maxHealth * width;
        }

        object[] returnObject = { currentHealth, initialHealthSetting, newWidth};

        return returnObject;
    }
}
