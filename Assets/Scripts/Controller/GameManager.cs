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
    public GameObject Enemy;
    public int Count;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    void Update()
    {
        scoreTxt.text = "score : " + scorePlayer.ToString();
        if (Count <2)
        {
            add();
        }

    }
    public void Create(Vector3 createPos)
    {
        Instantiate(Enemy, createPos, transform.rotation);
    }
    public void addScore()
    {
        scorePlayer += 10;
    }
    public void add()
    {
        if (scorePlayer % 100 == 0 && scorePlayer > 0  )
        {

            for (int i = 0; i < 2; i++)
            {
                Instantiate(Enemy, transform.position, transform.rotation);
                Count++;
            }
        
        }

    }

    
}
