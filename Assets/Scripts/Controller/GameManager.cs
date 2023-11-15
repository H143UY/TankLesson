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
    public Text highscore;
    private bool spawned = false;

   

    private void Awake()
    {
        if (instance == null) 
            instance = this;
        this.RegisterListener(EventID.EnemyDestroy, (sender, param) => // sender: người gửi . param gửi kèm đến cái gì
            {
                addScore();
            });

        highscore.text = DataAccountPlayer.PlayerInformation.score.ToString();

    }
    void Update()
    {
        scoreTxt.text = "score : " + scorePlayer.ToString();
    }
    public void addScore()
    {
        scorePlayer += 10;
    }
}
