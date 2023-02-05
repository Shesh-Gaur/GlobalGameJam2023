using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class winGame : MonoBehaviour
{
    public GameObject winScreen;
    public float timer = 5.0f;
    bool win = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {         
            win = true;
        }
    }

    private void Update()
    {
        if (!win)
            return;

        winScreen.SetActive(true);
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
            SceneManager.LoadScene(0);

    }
}
