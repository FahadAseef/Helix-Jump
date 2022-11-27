using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ballcontroller : MonoBehaviour
{
    public Rigidbody rb;
    public int balljumpforce;
    bool ignorenextcollision;
    public static int score;


    private void OnCollisionEnter(Collision collision)
    {
        Invoke("allowcollision", 0.2f);
        if(ignorenextcollision)
            return;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*balljumpforce,(ForceMode.Impulse));
        ignorenextcollision = true;
        if(collision.gameObject.tag== "lastcheese")
        {
            GameManager.gm.levelchanged();
        }
        else if(collision.gameObject.tag== "danger")
        {
            GameManager.gm.gameover();
        }
       else if (score == 9)
        {
            GameManager.gm.gameover();
        }
    }

   

    void allowcollision()
    {
        ignorenextcollision=false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("winer winner chicken dinner");
        score++;
        GameManager.gm.scoretext.text = "" + score;
        other.enabled = false;
        if (PlayerPrefs.GetInt("bestscores") < score)
        {
            PlayerPrefs.SetInt("bestscores", score);
           // GameManager.gm.bestscoretext.text = "best score : " + score;
        }
       
    }

}
