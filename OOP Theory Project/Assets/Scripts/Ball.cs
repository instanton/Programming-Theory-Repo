using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    protected GameManager gameManager;

    public Color color;
    public int redPoints;
    public int whitePoints;

    // ENCAPSULATION
    private float m_timeToLive = 5;
    public float timeToLive
    {
        get { return m_timeToLive; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative life time!");
            }
            else
            {
                m_timeToLive = value;
            }
        }
    }
    
    
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Debug.Log("In Ball base class Start(). m_timeToLive = " + m_timeToLive);
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        StartCoroutine(TimeToLiveRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //life coroutine
    IEnumerator TimeToLiveRoutine()
    {
        yield return new WaitForSeconds(m_timeToLive);
        Destroy(gameObject);
    }


    public virtual string GetName()
    {
        return "Ball";
    }

    public abstract void UpdateScore();


}
