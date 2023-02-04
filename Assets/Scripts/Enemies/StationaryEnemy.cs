using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : Enemy
{
    public float searchAngle = 45.0f;
    Quaternion startAngle;

    // Start is called before the first frame update
    void Start()
    {
        detection = detectionMax;
        startAngle = transform.rotation;
        statusLight = GetComponentInChildren<Light>();
        statusLight.spotAngle = sightAngle;
    }

    // Update is called once per frame
    void Update()
    { 
        Listen();
        See();

        if (distrationTimer <= 0)
            Search();
        else
        {
            distrationTimer -= Time.deltaTime;
            Distracted();
        }
    }

    void Search()
    {
        float rY = Mathf.SmoothStep(-searchAngle / 2.0f, searchAngle / 2.0f, Mathf.PingPong(Time.time * movementSpeed * 0.15f, 1));
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, startAngle.eulerAngles.y + rY, 0), movementSpeed * Time.deltaTime);
    }

    void Distracted()
    {
        Vector3 dir = lastHeardSoundPos - transform.position;
        dir.y = 0.0f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), movementSpeed * Time.deltaTime);
        statusLight.color = Color.Lerp(statusLight.color, Color.yellow, Time.deltaTime);
    }

}
