using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE

public class YellowBall : Ball
{
    protected override void Start()
    {
        //Debug.Log("In YellowBall Start()");

        timeToLive = 10;

        base.Start();
    }

    public override void UpdateScore()
    {
        if (gameManager == null)
        {
            Debug.Log("gameManager is NULL");
        }
        else
        {
            gameManager.UpdateScore(-10);
            gameManager.UpdateLivesRemaining(1);
        }
    }
}
