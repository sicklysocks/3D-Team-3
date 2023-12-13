using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    public static string textString;
    public TMP_Text gameOverText;

    public pickUP pick;
    public PlayerMovement play;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play.health == 0)
        {
            textString = "You were eaten by a dog... at least it didn't get the kids.";
        }
        if(textString == null)
        {
            textString = "You were caught by CPS, thank God!";
        }
        if(play.death == "sandbox")
        {
            textString = "You drowned in a sandbox and died. Those poor children.";
        }
    }

    private void FixedUpdate()
    {
        gameOverText.text = textString;
    }
}
