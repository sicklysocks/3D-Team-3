using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUP : MonoBehaviour
{

    public GameObject objPosition;
    bool canPickup;
    public GameObject item;
    bool hasItem;
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
        }
        if(other.gameObject.tag == "child")
        {
            canPickup = true;
            item = other.gameObject;
        }
       
    }

    
    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }
}
