using UnityEngine;
using System.Collections;

public class WovenKidExample : MonoBehaviour {
	private Animator anim;
	int Idle;
	int Walk;
	int Run;
	int BadgerPawAttack;
	int BalloonFishDive;
	int BalloonFishFloat;
	int BalloonFishSwim;
	int Celebrates;
	int Jump;
	int FoxJump;
	int KoalaClimb;
	int KoalaClimbReachTop;
	int KoalaJumpToClimb;
	int Collect;
	int FallSitted;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		Idle = Animator.StringToHash("Idle");
		Walk = Animator.StringToHash("Walk");
		Run = Animator.StringToHash("Run");
		BadgerPawAttack = Animator.StringToHash("BadgerPawAttack");
		BalloonFishDive = Animator.StringToHash("BalloonFishDive");
		BalloonFishFloat = Animator.StringToHash("BalloonFishFloat");
		BalloonFishSwim = Animator.StringToHash("BalloonFishSwim");
		Celebrates = Animator.StringToHash("Celebrates");
		Jump = Animator.StringToHash("Jump");
		FoxJump = Animator.StringToHash("FoxJump");
		KoalaClimb = Animator.StringToHash("KoalaClimb");
		KoalaClimbReachTop = Animator.StringToHash("KoalaClimbReachTop");
		KoalaJumpToClimb = Animator.StringToHash("KoalaJumpToClimb");
		Collect = Animator.StringToHash("Collect");
		FallSitted = Animator.StringToHash("FallSitted");


	}

	// Update is called once per frame
	void Update () 
	{
		     
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {  
				anim.SetBool (Walk, true); 
				anim.SetBool (Idle, false);                                      
				anim.SetBool (Run, false);
				anim.SetBool (BadgerPawAttack, false);
				anim.SetBool (BalloonFishDive, false);  
				anim.SetBool (BalloonFishFloat, false);  
				anim.SetBool (BalloonFishSwim, false); 
				anim.SetBool (Celebrates, false);
				anim.SetBool (Jump, false);
				anim.SetBool (FoxJump, false);
				anim.SetBool (KoalaClimb, false);
				anim.SetBool (KoalaClimbReachTop, false);
				anim.SetBool (KoalaJumpToClimb, false);
				anim.SetBool (Collect, false);
				anim.SetBool (FallSitted, false);
		}

		else if (Input.GetKeyUp(KeyCode.W))
		{
            if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Walk"))  //W to walk
			{           
				anim.SetBool (Walk, false); 
				anim.SetBool (Idle, true);                                      
				anim.SetBool (Run, false);
				anim.SetBool (BadgerPawAttack, false);
				anim.SetBool (BalloonFishDive, false);  
				anim.SetBool (BalloonFishFloat, false);  
				anim.SetBool (BalloonFishSwim, false); 
				anim.SetBool (Celebrates, false);
				anim.SetBool (Jump, false);
				anim.SetBool (FoxJump, false);
				anim.SetBool (KoalaClimb, false);
				anim.SetBool (KoalaClimbReachTop, false);
				anim.SetBool (KoalaJumpToClimb, false);
				anim.SetBool (Collect, false);
				anim.SetBool (FallSitted, false); 
			}
		}
			
		 
	
		 
	}
}