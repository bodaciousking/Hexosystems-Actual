using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPhases : MonoBehaviour
{


    public void Delay(float timeToDelay)
    {
        StartCoroutine(DelayTime(timeToDelay));
    }


    public IEnumerator DelayTime(float delayForTime)
    {
        yield return new WaitForSeconds(delayForTime);
    }
}
