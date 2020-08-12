using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//１対１の場合のバトルシステム
public class BattleSystemScript : MonoBehaviour {
    //データ取得
    public PlayerData PlayerData;
    public EnemyData EnemyData;
    public BattleParam BattleParam;
    public Player player;
    public Enemy enemy;

    public Fungus.Flowchart flowchart = null;
    //ターン
    bool IsPlayerturn = true;
    //コマンド
    public int Command;
    //音
    public AudioSource AttackSound;
    public AudioSource BarrierSound;
    public AudioSource DelaySound;
    public AudioSource UniverseSound;
    public AudioSource ClockSound;
    public AudioSource WinSound;
    public AudioSource LoseSound;
    public AudioSource BattleBGM;
    //ボタン
    public Button AttackButton;
    public Button StartCommandButton;
    public Button StarButton;
    public Button[] CommandButton;
    //UI
    public GameObject[] UI;
    public GameObject Canvas;
    //星座
    public GameObject Aries;
    public GameObject Leo;
    public GameObject Sagittarius;
 
    //勝利時のパネル
    public GameObject WinResult;
    //敗北時のパネル
    public GameObject LoseResult;

    // Use this for initialization
    void Start () {




        if (BattleParam.Aries)
        {
            Aries.SetActive(true);
        }
        if (BattleParam.Leo)
        {
            Leo.SetActive(true);
        }
        if (BattleParam.Sagittarius)
        {
            Sagittarius.SetActive(true);
        }
        
    }

    
	// Update is called once per frame
	void Update () {
        if (!IsPlayerturn)
        {           
            //カウントを進めてターンを返す
            if(enemy.hp <= 0)
            {
                flowchart.SendFungusMessage("win");
            }
            else
            {
                enemy.CountDown();
                ClockSound.Play();               
                IsPlayerturn = true;
            }
        }
	}

    public void PushCommandButton(){

    }

    public void PushAttackButton()
    {
        //Enemy１体のhpをPlayerのatだけ減らす
        if (IsPlayerturn == true)
        {
            enemy.OnDamage(player.at - EnemyData.df);
        　　 AttackSound.Play();
            flowchart.SendFungusMessage("attack");   
        }
    }

    public void PlayerAttack()
    {
        enemy.OnDamage(player.at);
        AttackSound.Play();
        flowchart.SendFungusMessage("attack");
    }
    public void PushBarrierButton()
    {
        //バリアでEnemyの攻撃を無効化
        //Playerのhpを２を消費する
        if (IsPlayerturn == true)
        {
            PlayerBarrier();
        }
    }

    public void PlayerBarrier()
    {
        enemy.Barrier();
        player.Barrier();
        BarrierSound.Play();
        flowchart.SendFungusMessage("barrier");
    }
    public void PushDelayButton()
    {
        //Enemyのカウントを１増やす
        //Playerのhpを１消費する
        if (IsPlayerturn == true)
        {
            PlayerDelay();
        }  
    }

    public void PlayerDelay()
    {
        enemy.Delay();
        player.Delay();
        DelaySound.Play();
        flowchart.SendFungusMessage("delay");
    }
    public void PushUniverseButton()
    {
        //敵のhpをPlayerのatだけ減らす
        //バリアでEnemyの攻撃を無効化
        //Enemyのカウントを１増やす
        //Playerのhpを３消費する
        if (IsPlayerturn == true)
        {
            PlayerUniverse();
        }
    }

    public void PlayerUniverse()
    {
        enemy.OnDamage(player.at);
        enemy.Delay();
        enemy.Barrier();
        player.Universe();
        UniverseSound.Play();
        flowchart.SendFungusMessage("universe");
    }
    public void WinRe()
    {
        //リザルト表示
        WinSound.Play();
        BattleBGM.Stop();
        WinResult.SetActive(true);
    }

    public void LoseRe()
    {
        //リザルト表示
        LoseSound.Play();
        BattleBGM.Stop();
        LoseResult.SetActive(true);
    }

    public void LoseCa()
    {
        Canvas.SetActive(false);
    }
    
    public void MoveMain()
    {
        //PlayerのHPの最大値を＋１する
        //ダークハートを破壊してピンクのハートを生成する
        PlayerData.breakmode = true;
        BattleParam.destroy[BattleParam.Stage] = true;
        //シーン移動
        SceneManager.LoadScene("Main");
    }

    public void Retry()
    {
        //リトライ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Title()
    {
        SceneManager.LoadScene("Main");
    }

    public void TurnBack()
    {
        IsPlayerturn = false;
    }

    public void TurnStart()
    {
        for (int i = 0; i <= 4; i++)
        {
            UI[i].SetActive(false);
        }
    }

    public void TurnFinish()
    {
        if(player.hp <= 0)
        {
            flowchart.SendFungusMessage("lose");
        }
        else
        {
            for (int i = 0; i <= 5; i++)
        {
            UI[i].SetActive(false);
        }
        } 
    }
}
