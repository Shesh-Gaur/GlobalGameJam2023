using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Enemy
{
    public List<GameObject> patrolPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Listen();
        See();
        SelectPatrolPoint();
        Steer();
        Avoidance();
    }

    void Steer()
    {

    }

    void Avoidance()
    {

    }

    void SelectPatrolPoint()
    { 

    }

}
