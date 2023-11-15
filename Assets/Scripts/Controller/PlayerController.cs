using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : TankController
{
    public static PlayerController instance;
    public Slider slider_hp;
    public Slider slider_Ex;

    //ex player
    private int ExMax = 5;
    private int ExPlayer = 0;

    // level
    public Text ExText;
    private int level;
    // item 
    private float TimeItem1;
    private float TimeItem2;
    private float TimeItem4;
    private float TimeItem5;
    private float TimeItem6;
    private GameObject gun2;
    private float hpMax;
    private bool item1 = false;
    private bool item2 = false;
    private bool item3 = false;
    private bool item4 = false;
    private bool item5 = false;
    private bool item6 = false;
    public GameObject transhot3;
    public GameObject transhot4;
    public GameObject USUngsau;
    public GameObject transhot5;
    private void Awake()
    {
        if (instance == null) instance = this;
        this.RegisterListener(EventID.EnemyDestroy, (sender, param) =>
        {
            congEx();
        });      
        slider_hp.maxValue = hp;
        slider_Ex.maxValue = ExMax;
        slider_Ex.value = ExPlayer;
        level = DataAccountPlayer.PlayerInformation.capdo;
        ExPlayer = DataAccountPlayer.PlayerInformation.kinhnghiem;
    }
    private void Start()
    {
        hpMax = hp;
    }
    private void Update()
    {
        ExText.text = "level:"+level;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        Move(direction);
        var position = Input.mousePosition;
        Vector3 gunDirectionmoba = new Vector3(
             position.x - Screen.width / 2,
             position.y - Screen.height / 2
            );
        RotateGun(gunDirectionmoba);
        if (Input.GetMouseButtonDown(0))
        {
            CreateBullet();
            if (item1 == true)
            {
                if (transhoot2)
                {
                    SmartPool.Instance.Spawn(bullet.gameObject, transhoot2.transform.position, transhoot2.rotation);
                }
                
            }
            if (item6 == true)
            {
                SmartPool.Instance.Spawn(bullet.gameObject, transhot3.transform.position, transhot3.transform.rotation);
                SmartPool.Instance.Spawn(bullet.gameObject, transhot4.transform.position, transhot4.transform.rotation);
            }
            if (item4 == true)
            {
                SmartPool.Instance.Spawn(bullet.gameObject, transhot5.transform.position, transhot5.transform.rotation);
            }
        }

        slider_hp.value = hp;
        //kinh nghiệm
        if (ExPlayer >= ExMax)
        {
            GameManager.instance.scorePlayer = 0;
            Conglevel();
            ExPlayer = 0;
        }
        slider_Ex.value = ExPlayer;
        // trừ dần thời gian ăn item 5 d
        CheckTimeItem();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //item
        if (collision.gameObject.tag == "item")
        {
            gun2.SetActive(true);
            item1 = true;
        }
        //item2
        if (collision.gameObject.tag == "item2")
        {
            speed *= 2;
            item2 = true;
            Debug.Log("speed:" + speed);
        }
        //item3
        if (collision.gameObject.tag == "item3")
        {
            hp = hpMax;
            item3 = true;
        }
        //item4
        if (collision.gameObject.tag == "item4")
        {
            USUngsau.SetActive(true);
            item4 = true;
        }
        //item5
        if (collision.gameObject.tag == "item5")
        {
            item5 = true;
            this.gameObject.transform.localScale += new Vector3(3, 3, 0);
        }
        //item6
        if (collision.gameObject.tag == "item6")
        {
            item6 = true;
        }
        //dame
        if (collision.gameObject.tag == "danEnemy")
        {
            var dame = collision.gameObject.GetComponent<BulletController>().damage;
            CalculateHP(-dame);
        }
    }

    public void congEx()
    {
        ExPlayer += 1;
    }
    public void Conglevel()
    {
        level += 1;
    }
    public override void CalculateHP(float value)
    {
        base.CalculateHP(value);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
            DataAccountPlayer.PlayerInformation.ChangeScore(GameManager.instance.scorePlayer);
            DataAccountPlayer.PlayerInformation.SaveLevel(level);
            DataAccountPlayer.PlayerInformation.SaveEX(ExPlayer);
        }
    }
    public void CheckTimeItem()
    {
        if (item1 == true)
        {
            TimeItem1 -= Time.deltaTime;
            if (TimeItem1 <= 0)
            {
                item1 = false;
                gun2.SetActive(false);
                TimeItem1 = 10;
            }
        }
        if (item2 == true)
        {
            TimeItem2 -= Time.deltaTime;
            if (TimeItem2 <= 0)
            {
                TimeItem2 = 10;
                item2 = false;
                speed /= 2;
            }
        }
        if (item3 == true)
        {
            item3 = false;
        }
        if (item4 == true)
        {
            TimeItem4 -= Time.deltaTime;
            if (TimeItem4 <= 0)
            {
                TimeItem4 = 10;
                USUngsau.SetActive(false);
                item4 = false;
            }
        }

        if (item5 == true)
        {
            TimeItem5 -= Time.deltaTime;
            if (TimeItem5 <= 0)
            {
                TimeItem5 = 10;
                this.gameObject.transform.localScale -= new Vector3(3, 3, 0);
                item5 = false;
            }
        }
        if (item6 == true)
        {
            TimeItem6 -= Time.deltaTime;
            if (TimeItem6 <= 0)
            {
                item6 = false;
                TimeItem6 = 10;

            }
        }
    }
}