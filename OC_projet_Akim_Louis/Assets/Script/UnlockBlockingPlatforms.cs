using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UnlockBlockingPlatforms : MonoBehaviour
{
    public Blocker blocker;
    public TextMeshProUGUI EnemiesLeftToKill;

    public int lockers = 0;

    void Update()
    {
        lockers = blocker.lockers;
        EnemiesLeftToKill.text = lockers.ToString();
    }
}
