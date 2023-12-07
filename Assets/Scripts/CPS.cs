using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPS : MonoBehaviour
{
    public GameObject cpsPrefab;
    public GameObject instance;

    Vector3 rotationVector = new Vector3(0, 45, 0);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        instance = Instantiate(cpsPrefab, transform.position, Quaternion.Euler(rotationVector));
        Invoke("DestroyCPS", 2.0f);
    }

    private void DestroyCPS()
    {
        Destroy(instance);
    }
}
