using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using static UnityEditor.Progress;

public class KidCollector : MonoBehaviour
{
    public pickUP pick;
    public GameObject player;

    bool press = false;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
        {
            if (pick.item != null)
            {
                Destroy(pick.item);
                pick.item = null;
                pick.kidsCollected++; // increment number of kids collected by 1
            }
        }
    }

}
