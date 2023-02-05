using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public GameObject target;
    protected Light statusLight;
    protected Vector3 lastHeardSoundPos = Vector3.zero;

    public float listeningRadius = 5.0f;
    public float detectionMax = 1.0f;
    protected float detection;
    public float detectionDissapationRate = 0.8f;
    protected bool detectingPlayer = false;
    public float sightAngle = 45.0f;
    public float sightRadius = 10.0f;
    public float distractionTimerMax = 3.0f;
    protected float distrationTimer = 0.0f;
    public float movementSpeed = 1.0f;
    float detectionSpeed = 1.0f;

    protected void Listen()
    {
        foreach (Sounds s in SoundManager.soundManager.allSounds)
        {
            float dist = (transform.position - s.transform.position).magnitude;

            if (s.volume > (dist - listeningRadius))
            {
                Debug.Log("Sound Heard!");
                lastHeardSoundPos = s.transform.position;
                distrationTimer = distractionTimerMax;

            }
        }
    }

    protected void See()
    {
        if (distrationTimer <= 0.0f)
            statusLight.color = Color.Lerp(Color.white, Color.red, (detection / detectionMax));

        if (detectingPlayer)
        {
            detection += detectionSpeed * Time.deltaTime;

            if (detection > detectionMax)
                Detected();
        }
        else
        {
            if (detection > 0.0f)
                detection -= detectionDissapationRate * Time.deltaTime;
        }

        detectingPlayer = false;

        Vector3 dir = target.transform.position - transform.position;
        float dist = dir.magnitude;
        float dotProd = Vector3.Dot(transform.forward, dir.normalized);

        //Check if player is within radius
        if (dist > sightRadius)
            return;

        //Check Player is Within Sight Angle
        float maxAngle = 1.0f + (0.0027f * (sightAngle / 2.0f)) ;
        float minAngle = 1.0f - (0.0027f * (sightAngle / 2.0f));

        if (dotProd > maxAngle || dotProd < minAngle)
            return;


        RaycastHit hit;
        if (!Physics.Raycast(transform.position, dir.normalized, out hit, dir.magnitude))
        {
            Debug.DrawRay(transform.position, dir, Color.red);
            return;
        }

        if (hit.collider.CompareTag("Player"))
        {
            // If raycast hits fill detection meter
            Debug.DrawRay(transform.position, dir, Color.green);
            //Debug.Log("Player Spotted!");

            if (hit.collider.GetComponent<PlayerController>() != null && hit.collider.GetComponent<PlayerController>().isCrouching)
            {
                detectionSpeed = 0.7f;
            }
            else
            {
                detectionSpeed = 1.0f;
            }

            detectingPlayer = true;
        }
        else
        {
            Debug.DrawRay(transform.position, dir, Color.red);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, listeningRadius);
    }

    void Detected()
    {
        Debug.Log("Game Over");

        //Detected Screen

        //Restart Level      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
