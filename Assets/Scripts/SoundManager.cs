using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public List<Sounds> allSounds = new List<Sounds>();
    // Start is called before the first frame update
    void Start()
    {
        soundManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
