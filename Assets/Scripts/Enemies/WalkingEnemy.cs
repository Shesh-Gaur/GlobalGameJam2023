using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : Enemy
{
    public List<GameObject> patrolPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        detection = detectionMax;
        statusLight = GetComponentInChildren<Light>();
        statusLight.spotAngle = sightAngle;
    }

    // Update is called once per frame
    void Update()
    {
        Listen();
        See();
        SelectPatrolPoint();

        if (distrationTimer <= 0)
        {
            Steer();
            Avoidance();
        }
        else
        {
            distrationTimer -= Time.deltaTime;
            Distracted();
        }

    }

    void Steer()
    {
        Vector3 newVel = GetComponent<Rigidbody>().velocity;
        Vector3 desiredVel = target.transform.position - transform.position;

        Vector3 steering = desiredVel - GetComponent<Rigidbody>().velocity;
        steering = steering.normalized;

        newVel += steering * movementSpeed * Time.deltaTime;
        newVel.y = GetComponent<Rigidbody>().velocity.y;

        GetComponent<Rigidbody>().velocity = newVel;
        newVel.y = 0;
        transform.rotation = Quaternion.LookRotation(newVel);
    }

    void Avoidance()
    {

    }

    void SelectPatrolPoint()
    { 

    }

    void Distracted()
    {
        Vector3 dir = lastHeardSoundPos - transform.position;
        dir.y = 0.0f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), movementSpeed * Time.deltaTime);
        statusLight.color = Color.Lerp(statusLight.color, Color.yellow, Time.deltaTime);
    }
}
