using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPS : MonoBehaviour
{
    public GameObject cpsPrefab;
    public GameObject copCar;

    public Vector3 copVector;

    // Start is called before the first frame update
    void Start()
    {
        copVector = copCar.GetComponent<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("Spawn", 2.0f, 5.0f);
    }

    private void Spawn()
    {
        Instantiate(cpsPrefab, copVector, Quaternion.identity);
    }
}
