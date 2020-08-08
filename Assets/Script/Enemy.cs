using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
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

    public enum EnemyType{
        GOBLIN,
        SLIME
    }
    public EnemyType type;


    // Use this for initialization
    void Start () {
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
	void Update () {
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
        if(hp <= 0)
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
        EnemyImage.SetActive(false);
        EnemyCountImage.SetActive(false);
        counttext.text = null;
    }

    public void EnemyAction()
    {
        if(hp <= 0)
        {
            switch(type){
                case EnemyType.GOBLIN:
                    flowchart.SendFungusMessage("enemyfinish");
                    break;
                case EnemyType.SLIME:
                    flowchart.SendFungusMessage("enemyfinish1");
                    break;
            }

            return;
        }

        if (count == 0)
        {
            //バリアが無いならダメージを与える
            if (barrier == false)
            {
               player.OnDamage(at);
               switch(type){
                case EnemyType.GOBLIN:
                    flowchart.SendFungusMessage("enemyattack");
                    break;
                case EnemyType.SLIME:
                    flowchart.SendFungusMessage("enemyattack1");
                    break;
                }
            //    if(type == EnemyType.GOBLIN) flowchart.SendFungusMessage("enemyattack");
            //    else if(type == EnemyType.SLIME) flowchart.SendFungusMessage("enemyattack1");
                
            }
            else if (barrier == true)
            {
                BarrierSound.Play();
                switch(type){
                case EnemyType.GOBLIN:
                    flowchart.SendFungusMessage("enemybarrier");
                    break;
                case EnemyType.SLIME:
                    flowchart.SendFungusMessage("enemybarrier1");
                    break;
                }
                //if(type == EnemyType.GOBLIN) flowchart.SendFungusMessage("enemybarrier");
            }
        }
        else if(count != 0)
        {
            switch(type){
                case EnemyType.GOBLIN:
                    flowchart.SendFungusMessage("enemyfinish");
                    break;
                case EnemyType.SLIME:
                    flowchart.SendFungusMessage("enemyfinish1");
                    break;
                }
            // flowchart.SendFungusMessage("enemyfinish");
        }
        barrier = false;
    }

    public void CountReset()
    {
        CountMaxSound.Play();
        count = maxCount;
    }

    public void EnemyCountMax()
    {
        switch(type){
                case EnemyType.GOBLIN:
                    flowchart.SendFungusMessage("countmax");
                    break;
                case EnemyType.SLIME:
                    flowchart.SendFungusMessage("countmax1");
                    break;
                }
        
    }
}
