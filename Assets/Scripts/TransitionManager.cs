using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Invoke("LevelTwoLoader", 8.0f);
        
    }
    void LevelTwoLoader()
    {
        SceneManager.LoadScene("LevelTwo");
    }
}
