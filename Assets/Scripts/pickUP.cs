using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class pickUP : MonoBehaviour
{
    private Scene scene; // scene manager stuff
    public GameObject objPosition;
    bool canPickup;
    public GameObject item;
    public GameObject itemChild;
    public bool hasItem;
    //bool emptyPit;
    public AudioSource pickupSound;
    public AudioClip pickupClip;
    public int kidsCollected = 0;
    public bool grabbed;
    public TMP_Text kidsCollectedText;

    public MoveChild mc;

    // Start is called before the first frame update
    void Start()
    {
        canPickup = false;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickup == true) // if youve entered the objects collider
        {
            if (Input.GetKeyDown("e")) 
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = objPosition.transform.position;
                item.transform.parent = objPosition.transform;
                hasItem = true;
                grabbed = true;
                mc.agent.enabled = false;
            }
        }
        if (Input.GetKeyDown("q") && hasItem == true)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            
            
        }
        kidsCollectedText.text = "Kids Collected: " + kidsCollected;
        if(kidsCollected == 1)
        {
            Invoke("Winner", 1.0f);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            canPickup = true;
            item = other.gameObject;
            itemChild = other.gameObject.transform.GetChild(0).gameObject;
        }
        if(other.gameObject.tag == "child")
        {
            canPickup = true;
            item = other.gameObject;
            pickupSound.clip = pickupClip;
            pickupSound.Play(); //play pickup sound
            
            //kidsCollected++; // increment number of kids collected by 1

        }
       
    }

    public void Winner()
    {
            SceneManager.LoadScene("Credits"); //Change to Win Scene what created
    }

    
    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }
}
