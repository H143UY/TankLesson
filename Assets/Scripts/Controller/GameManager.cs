using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EnemyController tankEnemy;
    public int scorePlayer;
    public Text scoreTxt;
    private bool spawned = false;

   

    private void Awake()
    {
        if (instance == null) instance = this;
        this.RegisterListener(EventID.EnemyDestroy, (sender, param) => // sender: người gửi . param gửi kèm đến cái gì
            {
            addScore();
            });
        
    }
    void Update()
    {
        scoreTxt.text = "score : " + scorePlayer.ToString();



        //if (scorePlayer % 100 == 0 && scorePlayer > 0 && spawned == false)
        //{
        //    Spawn2Enemy();
        //    spawned = true;
        //}
    }
    public void addScore()
    {
        scorePlayer += 10;

        //if (spawned == true)
        //{
        //    spawned = false;
        //}
    }
    //public void Spawn2Enemy()
    //{

    //    for (int i = 0; i < 2; i++)
    //    {
    //        var x = Random.Range(0, 10);
    //        var y = Random.Range(0, 10);
    //        var creatPos = new Vector3(x, y, 0);
    //    }

    //}

 
}
