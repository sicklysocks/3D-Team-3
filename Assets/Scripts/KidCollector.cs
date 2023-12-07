using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class KidCollector : MonoBehaviour
{
    public pickUP pick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "player" && pick.hasItem == true)
        {
            pick.kidsCollected++; // increment number of kids collected by 1
            Destroy(pick.item);
        }

    }
}
