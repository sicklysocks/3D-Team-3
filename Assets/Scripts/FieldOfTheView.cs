using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldOfTheView : MonoBehaviour
{
    public float radius;
    [Range(0,36)]
    public float angle;

    public GameObject Player; //Attach to Player with the tag Player

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //Find Player
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while(true)
        {
            yield return wait; // wait 0.2 seconds
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck() //check for the player
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);//look for player on layermask only. If player is not on layermask it wont work
        if (rangeChecks.Length != 0)
        { 
          Transform target = rangeChecks[0].transform;
          Vector3 directionToTarget = (target.position - transform.position).normalized; // the direction of where CPS is looking to where Player is

          if(Vector3.Angle(transform.forward, directionToTarget) < angle/2) //Check angle?
          {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); //enemey is close enough to Player to trigger FOV

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)) 
                {
                    canSeePlayer = true;
                    Debug.Log("I CAN SEE YOU!!....GAME OVER");
                    SceneManager.LoadScene("Lose"); //load lose scene
                }
                else
                {
                    canSeePlayer = false;
                }
          }
          else //player is not in FOV
          {
                canSeePlayer = true;
                Debug.Log("I CAN SEE YOU!!....GAME OVER");
                SceneManager.LoadScene("Lose"); //load lose scene

            }
        }
        else if (canSeePlayer) //player is no longer in the view of CPS
        {
            canSeePlayer = false; 
        }
    }
}


// YOUTUBE VIDEO: https://www.youtube.com/watch?v=j1-OyLo77ss
// 21:14/23:44