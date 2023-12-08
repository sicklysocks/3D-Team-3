using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenAudio : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public AudioClip play;
    public AudioClip play2;
    public AudioClip run10;
    public AudioClip run8;
    public AudioClip run6;
    public AudioClip run4;
    public AudioClip run2;

    public pickUP pick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pick.kidsCollected == 0)
        {
            audioSource1.clip = run10;
            audioSource1.Play();
            audioSource2.clip = play; 
            audioSource2.Play();
        }
        if (pick.kidsCollected > 1 && pick.kidsCollected <= 2)
        {
            audioSource1.clip = run8;
            audioSource1.Play();
        }
        if (pick.kidsCollected > 2 && pick.kidsCollected <= 4)
        {
            audioSource1.clip = run6;
            audioSource1.Play();
        }
        if (pick.kidsCollected > 4 && pick.kidsCollected <= 6)
        {
            audioSource1.clip = run4;
            audioSource1.Play();
        }
        if (pick.kidsCollected > 6 && pick.kidsCollected <= 8)
        {
            audioSource1.clip = run2;
            audioSource1.Play();
        }
        if (pick.kidsCollected == 9)
        {
            audioSource2.clip = play2;
            audioSource2.Play();
        }
    }
}
