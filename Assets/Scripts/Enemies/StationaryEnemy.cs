using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy : Enemy
{
    public float listeningRadius = 5.0f;
    public static float detectionMax = 1.0f;
    float detection = detectionMax;

    public static float distractionTimerMax = 3.0f;
    float distrationTimer = distractionTimerMax;

    public float movementSpeed = 1.0f;
    public float searchAngle = 45.0f;
    Quaternion startAngle;

    public float detectionDissapationRate = 0.8f;

    bool detectingPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        startAngle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Listen();

        if (detectingPlayer)
        {
            detection += Time.deltaTime;
            if (detection > detectionMax)
                Detected();
        }
        else
        {
            detection -= detectionDissapationRate * Time.deltaTime;
        }
    }

    void Listen()
    {
        foreach (Sounds s in SoundManager.soundManager.allSounds)
        {
            float dist = (transform.position - s.transform.position).magnitude;

            if (s.volume > (dist - listeningRadius))
                distrationTimer = distractionTimerMax;
        }
    }

    void Detected()
    {
        //Detected Screen
        //Restart Level
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))      
            detectingPlayer = true;      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))      
            detectingPlayer = false;    
    }

}
