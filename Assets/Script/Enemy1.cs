using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    //プレイヤーの情報
    public Player player;
    //敵の情報
    public EnemyData EnemyData;

    public Fungus.Flowchart flowchart = null;

    //各パラメタ
    public int hp;
    public int count;
    public int at;

    int oldcount;
    int maxCount;

    public GameObject DestroySound;
    public GameObject EnemyImage;
    public GameObject EnemyCountImage;

    public AudioSource CountMaxSound;
    public AudioSource BarrierSound;

    bool barrier;
    //カウントUI
    public Text counttext;
    //hpUI
    public Slider HPSlider;

    // Use this for initialization
    void Start()
    {
        //パラメタ代入
        hp = EnemyData.maxHp;
        at = EnemyData.at;
        maxCount = EnemyData.maxCount;

        count = maxCount;
        oldcount = count;

        DestroySound.SetActive(false);
        //敵hpをスライダーで表示
        HPSlider.maxValue = EnemyData.maxHp;
        HPSlider.value = hp;
        //カウントを表示
        counttext.text = count.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        //カウントUI更新
        if (oldcount != count)
        {
            counttext.text = count.ToString();
            oldcount = count;
        }
    }
    public void CountDown()
    {
        //カウントを進める
        count--;
    }

    public void OnDamage(int _damage)
    {
        //PlayerのatだけEnemyのhpを減らす
        hp -= _damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        HPSlider.value = hp;
    }
    public void Barrier()
    {
        //バリア
        barrier = true;
    }
    public void Delay()
    {
        //ディレイ
        count++;
    }
    public void Finish()
    {
        //破壊して終了
        DestroySound.SetActive(true);
        Destroy(EnemyImage);
        Destroy(EnemyCountImage);
        Destroy(counttext);
    }

    public void EnemyAction()
    {
        CheckDeath();

        if (count == 0)
        {
            //バリアが無いならダメージを与える
            if (barrier == false)
            {
               player.OnDamage(at);
               flowchart.SendFungusMessage("enemyattack1");
            }
            else if (barrier == true)
            {
                BarrierSound.Play();
                flowchart.SendFungusMessage("enemybarrier1");
            }
        }
        else if (count != 0)
        {
            flowchart.SendFungusMessage("enemyfinish1");
        }
        barrier = false;      
    }

    public void CheckDeath()
    {
        if (hp <= 0)
        {
            flowchart.SendFungusMessage("enemyfinish1");
            return;
        }
    }

    public void CountReset()
    {
        CountMaxSound.Play();
        count = maxCount;
    }

    public void EnemyCountMax()
    {
        flowchart.SendFungusMessage("countmax1");
    }

    public void NextEnemy()
    {
        flowchart.SendFungusMessage("enemy1");
    }
}