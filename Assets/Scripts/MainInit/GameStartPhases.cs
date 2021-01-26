using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPhases : MonoBehaviour
{
    public initPhase currentPhase;
    MsgDisplay msgD;
    CameraControll cC;
    float phaseTimer, phaseDelay = 2;
    public int currentPlayerTurn;

    public enum initPhase
    {
        Welcome,
        PlaceCities,
        
    }

    private void Start()
    {
        currentPlayerTurn = 1;
        msgD = MsgDisplay.instance;
        cC = CameraControll.instance;
        currentPhase = initPhase.Welcome;
        msgD.DisplayMessage("Welcome");
    }

    public void Update()
    {
        if(currentPhase == initPhase.Welcome)
        {
            phaseTimer += Time.deltaTime;
            if(phaseTimer >= phaseDelay)
            {
                PlaceCities();
            }
        }
    }

    public void PlaceCities()
    {
        msgD.DisplayMessage("Place Your Cities");
        currentPhase = initPhase.PlaceCities;
        //cC.GoToPos(cC.camSpots[0]);
    }

    public void Delay(float timeToDelay)
    {
        StartCoroutine(DelayTime(timeToDelay));
    }


    public IEnumerator DelayTime(float delayForTime)
    {
        yield return new WaitForSeconds(delayForTime);
    }
}
