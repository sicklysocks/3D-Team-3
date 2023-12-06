using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickUP : MonoBehaviour
{
    private Scene scene; // scene manager stuff
    public GameObject objPosition;
    bool canPickup;
    public GameObject item;
    public GameObject itemChild;
    bool hasItem;
    bool emptyPit;
    public AudioSource pickupSound;
    public AudioClip pickupClip;
    private int kidsCollected = 0; 
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
            }
        }
        if (Input.GetKeyDown("q") && hasItem == true)
        {
            item.GetComponent <Rigidbody>().isKinematic = false;
            item.transform.parent = null;
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
            pickupSound.Play(); //play pickup sound
            
            kidsCollected++; // increment number of kids collected by 1

        }
       
    }

    public void Winner()
    {
        if (kidsCollected == 5)
        {
            SceneManager.LoadScene("Menu"); //Change to Win Scene what created
        }

    }

    
    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }
}
