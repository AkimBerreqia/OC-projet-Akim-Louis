using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBlockingPlatforms : MonoBehaviour
{
    public Blocker blocker;
    public int lockers = 0;

    void Update()
    {
        lockers = blocker.lockers;
    }
}
