using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//using static UnityEditor.Progress;

public class Dog : MonoBehaviour
{
    public int health= 100;
    public TMP_Text healthText;

    public AudioSource dogSource;
    public AudioClip bark;
    public GameObject dog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int speed;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized; // The normalized direction in LOCAL space
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);

        if (health <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "player")
        {
            health -= 10;
            dogSource.clip = bark;
            dogSource.Play();

            Invoke("StopDog", 5.0f);
            Invoke("StartDog", 6.0f);
        }


        if (other.gameObject.tag == "bone")
        {
            Destroy(dog);
            Destroy(other.gameObject);
        }

    }

    public void StopDog()
    {
        dog.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void StartDog()
    {
        dog.GetComponent<Rigidbody>().isKinematic = false;
    }

}
