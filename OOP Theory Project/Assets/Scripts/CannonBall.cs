using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE

public class CannonBall : Ball
{

    protected override void Start()
    {
        //Debug.Log("In CannonBall Start()");

        timeToLive = 5;

        base.Start();
    }

    public override void UpdateScore()
    {

    }
}
