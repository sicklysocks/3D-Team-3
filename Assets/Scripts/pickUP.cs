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
    public TMP_Text kidsCollectedText;

    MoveChild mc;
    public List<GameObject> kids;

    public 

    Scene curScene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        item = null;
        canPickup = false;
        hasItem = false;

        curScene = SceneManager.GetActiveScene();
        sceneName = curScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (item == kids[1])
        {
            mc = kids[1].GetComponent("MoveChild");
        }
        

        if (canPickup == true) // if youve entered the objects collider
        {
            if (Input.GetKeyDown("e")) 
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.position = objPosition.transform.position;
                item.transform.parent = objPosition.transform;
                hasItem = true;
                mc.agent.enabled = false;
            }
        }
        if (Input.GetKeyDown("q") && hasItem == true)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            mc.agent.enabled = true;
            item = null;


        }
        kidsCollectedText.text = "Kids Collected: " + kidsCollected;

        if(kidsCollected == 5 && sceneName == "LevelOne")
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
            //itemChild = other.gameObject.transform.GetChild(0).gameObject;
        }
        if(other.gameObject.tag == "child")
        {
            canPickup = true;
            item = other.gameObject;
            pickupSound.clip = pickupClip;
            pickupSound.Play(); //play pickup sound

        }
       
    }

    public void Winner()
    {
       if (sceneName == "LevelOne")
       {
           SceneManager.LoadScene("Transition"); //Change to Win Scene what created
       }

       if (sceneName == "DF Level2")
       {
            SceneManager.LoadScene("Win");
       }
            
    }
    
    private void OnTriggerExit(Collider other)
    {
        canPickup = false;
    }
}
