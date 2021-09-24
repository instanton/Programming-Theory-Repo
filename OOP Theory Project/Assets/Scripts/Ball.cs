using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Color color;
    public int redPoints;
    public int whitePoints;

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
    void Start()
    {
        StartCoroutine(TImeToLiveRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //life coroutine
    IEnumerator TImeToLiveRoutine()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }


    public virtual string GetName()
    {
        return "Ball";
    }
}
