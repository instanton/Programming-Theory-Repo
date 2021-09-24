using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// INHERITANCE

public class RedBall : Ball
{
    protected override void Start()
    {
        //Debug.Log("In RedBall Start()");

        timeToLive = 7;

        base.Start();
    }

    // POLYMORPHISM
    public override void UpdateScore()
    {
        if (gameManager == null)
        {
            Debug.Log("gameManager is NULL");
        }
        else
        {
            gameManager.UpdateScore(5);
        }
    }
}
