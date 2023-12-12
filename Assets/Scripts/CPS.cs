using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CPS : MonoBehaviour
{
    public PlayerMovement play;
   
    public GameObject cpsPrefab;
    public GameObject instance;

    public TMP_Text cpsTimer;

    public AudioSource countSource;
    public AudioClip countdown5;

    public float timeRemaining = 5;
    public bool timerIsRunning = false;

    Vector3 rotationVector = new Vector3(0, -50, 0);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 10.0f, 10.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Timer", 0.0f, 10.0f);
    }

    private void Spawn()
    {
        instance = Instantiate(cpsPrefab, transform.position, Quaternion.Euler(rotationVector));
        Invoke("DestroyCPS", 2.0f);
    }

    private void Timer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Debug.Log("CPS is here");
            timeRemaining = 10;
            timerIsRunning = true;
        }

        if (timeRemaining <= 5)
        {
            countSource.clip = countdown5;
            countSource.Play();
        }

        cpsTimer.text = "CPS coming in: " + timeRemaining.ToString();
    }

    private void DestroyCPS()
    {
        Destroy(instance);
    }

   
}
