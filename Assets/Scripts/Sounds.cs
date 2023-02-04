using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public float volume;
    public static float resonanceMax = 0.5f;
    public float resonance = resonanceMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resonance > 0.0f)
        {
            resonance -= Time.deltaTime;
        }
        else
        {
            volume = 0;
            Destroy(this);
        }
    }
}
