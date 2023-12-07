using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPS : MonoBehaviour
{
    public GameObject cpsPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Spawn", 5.0f);
    }

    private void Spawn()
    {
        GameObject instance = Instantiate(cpsPrefab, transform.position, Quaternion.identity);
        Invoke("DestroyCPS", 2.0f);
    }

    private void DestroyCPS()
    {
        Destroy(cpsPrefab);
    }
}
