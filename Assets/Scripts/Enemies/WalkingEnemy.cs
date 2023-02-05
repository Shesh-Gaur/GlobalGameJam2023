using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class WalkingEnemy : Enemy
{
    public List<GameObject> patrolPoints = new List<GameObject>();
    int patrolPointsIndex = 0;
    Vector3 mvmtTarget;
    public float avoidanceRadius = 5.0f;
    public float avoidanceStrength = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        detection = detectionMax;
        statusLight = GetComponentInChildren<Light>();
        statusLight.spotAngle = sightAngle;
        mvmtTarget = patrolPoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Listen();
        See();
        Steer();
        Avoidance(transform.forward);    
        Vector3 diagVec = transform.right + transform.forward;
        Avoidance(diagVec.normalized);

        //diagVec = (transform.right / 2.0f) + transform.forward;
        //Avoidance(diagVec.normalized);

        diagVec = -transform.right + transform.forward;
        Avoidance(diagVec.normalized);

        diagVec = (transform.right) + transform.forward / 2.0f;
        Avoidance(diagVec.normalized);

        //diagVec = (-transform.right / 2.0f) + transform.forward;
        //Avoidance(diagVec.normalized);

        diagVec = (-transform.right) + transform.forward / 2.0f;
        Avoidance(diagVec.normalized);

        diagVec = transform.right;
        Avoidance(diagVec.normalized, 0.6f);

        diagVec = -transform.right;
        Avoidance(diagVec.normalized, 0.6f);

        if (distrationTimer <= 0)
        {
            if (detectingPlayer)
                mvmtTarget = target.transform.position;
            else
                mvmtTarget = patrolPoints[patrolPointsIndex].transform.position;

            SelectPatrolPoint();           
        }
        else
        {
            distrationTimer -= Time.deltaTime;
            Distracted();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(GetComponent<Rigidbody>().velocity), 3.0f * Time.deltaTime);
    }

    void Steer()
    {
        Vector3 newVel = GetComponent<Rigidbody>().velocity;
        Vector3 desiredVel = mvmtTarget - transform.position;

        Vector3 steering = desiredVel - GetComponent<Rigidbody>().velocity;
        steering = steering.normalized;

        newVel += steering * movementSpeed * Time.deltaTime;
        newVel.y = GetComponent<Rigidbody>().velocity.y;

        GetComponent<Rigidbody>().velocity = newVel;
        newVel.y = 0;
    }

    bool Avoidance(Vector3 dir, float strengthMultiplier = 1.0f)
    {
        RaycastHit hit;

        Debug.DrawLine(transform.position, transform.position + (dir * avoidanceRadius));

        if (Physics.Raycast(transform.position, dir, out hit, avoidanceRadius))
        {
            if (hit.collider != null && !hit.collider.CompareTag("Player"))
            {
                Vector3 reflectedDir = Vector3.Reflect(dir, hit.normal);
                reflectedDir.y = 0;
                GetComponent<Rigidbody>().velocity += reflectedDir * avoidanceStrength * strengthMultiplier * Time.deltaTime;
                return true;
            }
        }

        return false;
    }

    void SelectPatrolPoint()
    {
        float dist = (patrolPoints[patrolPointsIndex].transform.position - transform.position).magnitude;
        
        if (Mathf.Round(dist) == 1)
        {
            if (patrolPointsIndex >= patrolPoints.Count - 1)
                patrolPointsIndex = 0;
            else
                patrolPointsIndex++;
        }
    }

    void Distracted()
    {
        mvmtTarget = lastHeardSoundPos;
        statusLight.color = Color.Lerp(statusLight.color, Color.yellow, Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < patrolPoints.Count; i++)
        {
            if (patrolPoints[i] == null)
                continue;

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(patrolPoints[i].transform.position, 1.0f);


            if (i >= patrolPoints.Count - 1)
            {
                Gizmos.DrawLine(patrolPoints[i].transform.position, patrolPoints[0].transform.position);
            }
            else
            {
                Gizmos.DrawLine(patrolPoints[i].transform.position, patrolPoints[i + 1].transform.position);
            }
            
        }
    }
}
