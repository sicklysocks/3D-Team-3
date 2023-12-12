using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BGmusic : MonoBehaviour
{
    public static BGmusic instance;
 
    void Start()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}