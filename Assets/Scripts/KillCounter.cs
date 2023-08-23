using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text myKillsText;
    private int killNum;

    // Start is called before the first frame update
    void Start()
    {
        killNum = 0;
        myKillsText.text = "Kills: " + killNum;
        
    }

    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if(Enemy.tag == "Enemy")
        {
            killNum += 1;
            myKillsText.text = "Kills" + killNum;
        }
    }
}
