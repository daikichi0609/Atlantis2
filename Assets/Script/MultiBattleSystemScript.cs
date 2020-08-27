using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiBattleSystemScript : MonoBehaviour
{
  //データ取得
  public PlayerData PlayerData;
  public BattleParam BattleParam;
  public Player player;
  public Enemy[] enemy;
  public Fungus.Flowchart flowchart = null;
  bool IsPlayerturn = true;
  public AudioSource AttackSound;
  public AudioSource BarrierSound;
  public AudioSource KnuckleAttackSound;
  public AudioSource PenetrateAttackSound;
  public AudioSource HealSound;
  public AudioSource MegaHealSound;
  public AudioSource GigaHealSound;
  public AudioSource SlashSound;
  public AudioSource DoubleSlashSound;
  public AudioSource RageSound;
  public AudioSource ProtectSound;
  public AudioSource SlimeSound;
  public AudioSource VenomSound;
  public AudioSource PoisonSound;
  public AudioSource WhipSound;
  public AudioSource DebuffSound;
  public AudioSource TakerootSound;
  public AudioSource BiteSound;
  public AudioSource WinSound;
  public AudioSource LoseSound;
  public AudioSource BattleBGM;
  public Button AttackButton;
  public Button ReadyCommandButton;
  public Button StarButton;
  public GameObject[] ReadyUI;
  public GameObject[] CommandButtons;
  public GameObject StarCommandButton;
  public GameObject[] UIs;
  public bool choicing;
  public GameObject Canvas;
  public Text AtText;
  public Text DfText;
  public Text HpText;
  public GameObject Aries;
  public GameObject Leo;
  public GameObject Sagittarius;

  //勝利時のパネル
  public GameObject WinResult;
  //敗北時のパネル
  public GameObject LoseResult;
  public Color[] Textcolor;
  public int Enemys;
  public int target;

  // Use this for initialization
  void Start()
  {
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
    else
    {
      StarButton.interactable = false;
    }
  }
  // Update is called once per frame
  void Update()
  {
    if (!IsPlayerturn)
    {
      //カウントを進めてターンを返す
      if (enemy[0].hp <= 0 && enemy[1].hp <= 0)
      {
        flowchart.SendFungusMessage("win");
      }
      else
      {
        if (enemy[0].hp > 0)
        {
          flowchart.SendFungusMessage("enemy");
        }
        EnemyTurnBack();
      }
    }
    AtText.text = player.at.ToString();
    if (player.at == player.saveat)
    {
      AtText.color = Textcolor[1];
    }
    else if (player.at > player.saveat)
    {
      AtText.color = Textcolor[2];
    }
    else if (player.at < player.saveat)
    {
      AtText.color = Textcolor[3];
    }
    DfText.text = player.df.ToString();
    if (player.df == player.savedf)
    {
      DfText.color = Textcolor[4];
    }
    else if (player.df > player.savedf)
    {
      DfText.color = Textcolor[5];
    }
    else if (player.df < player.savedf)
    {
      DfText.color = Textcolor[6];
    }
    HpText.text = player.hp.ToString();
    HpText.color = Textcolor[7];

    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (choicing)
      {
        for (int i = 0; i <= 2; i++)
        {
          ReadyUI[i].SetActive(true);
        }
        for (int i = 0; i <= 3; i++)
        {
          CommandButtons[i].SetActive(false);
        }
        StarCommandButton.SetActive(false);
        choicing = false;
      }
    }
  }
  public void PushAttackButton()
  {
    if (IsPlayerturn == true)
    {
      enemy[target].OnDamage(player.at);
      AttackSound.Play();
      flowchart.SendFungusMessage("attack");
      choicing = false;
    }
  }
  public void PushReadyCommandButton()
  {
    for (int i = 0; i <= 2; i++)
    {
      ReadyUI[i].SetActive(false);
    }
    for (int i = 0; i <= 3; i++)
    {
      CommandButtons[i].SetActive(true);
    }
    choicing = true;
  }
  public void PushStarButton()
  {
    for (int i = 0; i <= 2; i++)
    {
      ReadyUI[i].SetActive(false);
    }
    StarCommandButton.SetActive(true);
    choicing = true;
  }

  public void uiOn()
  {
    for (int i = 0; i <= 2; i++)
    {
      ReadyUI[i].SetActive(true);
    }
    UIs[0].SetActive(true);
  }

  public void uiOff()
  {
    for (int i = 0; i <= 2; i++)
    {
      ReadyUI[i].SetActive(false);
    }
    for (int i = 0; i <= 3; i++)
    {
      CommandButtons[i].SetActive(false);
    }
    StarCommandButton.SetActive(false);
    UIs[0].SetActive(false);
    choicing = false;
  }

  public void TurnFinish()
  {
    player.PlayerTurnFinish();
    TurnBack();
  }

  public void TurnBack()
  {
    IsPlayerturn = false;
  }
  public void EnemyTurnBack()
  {
    IsPlayerturn = true;
  }

  public void WinRe()
  {
    //リザルト表示
    WinSound.Play();
    BattleBGM.Stop();
    WinResult.SetActive(true);
    PlayerData.Lv++;
    PlayerData.SP = PlayerData.SP + 2;
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
}
// Use this for initialization
/*void Start()
{
    //最初に表示しない
    WinResult.SetActive(false);
    LoseResult.SetActive(false);

    //最初のターゲットは左の敵
    Target1.SetActive(false);
    target = 0;

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

    Lucky = Random.Range(1, 11);
    BattleParam.Enemys = 1;
}
// Update is called once per frame
void Update()
{
    EnemyTurn();

    //どちらかが倒れたときにターゲットを自動変更
    if(enemy.hp <= 0)
    {
        target = 1;
        Target.SetActive(false);
        Target1.SetActive(true);
        ChangeButton.interactable = false;
    }
    if(enemy1.hp <= 0)
    {
        target = 0;
        Target.SetActive(true);
        Target1.SetActive(false);
        ChangeButton.interactable = false;
    }
}

private void EnemyTurn() {
    if (IsPlayerturn)
    {
        return;
    }
    //カウントを進めてターンを返す
    if (enemy.hp <= 0)
    {
        if (Last && !isFirst[0])
        {
            flowchart.SendFungusMessage("win3");
            IsPlayerturn = true;
            return;
        }
        else if(!Last && !isFirst[0])
        {
            Last = true;
            flowchart.SendFungusMessage("win");
            IsPlayerturn = true;
            isFirst[0]　= true;
            return;
        }
    }
    else if (enemy1.hp <= 0)
    {
        if (Last && isFirst[1])
        {
            flowchart.SendFungusMessage("win4");
            IsPlayerturn = true;
            return;
        }
        else if(!Last && !isFirst[1])
        {
            Last = true;
            flowchart.SendFungusMessage("win2");
            IsPlayerturn = true;
            isFirst[1] = true;
            return;
        }
    }

    DeathTurn();

}

public void DeathTurn()
{
    if(enemy.hp > 0)
    {
        enemy.CountDown();
    }
    if (enemy1.hp > 0)
    {
        enemy1.CountDown();
    }
    ClockSound.Play();
    Lucky = Random.Range(1, 11);
    IsPlayerturn = true;
    flowchart.SendFungusMessage("enemy");
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

    //foreach (GameObject ui in UI) {
    //    ui.SetActive(false);
    //}
}

public void TurnFinish()
{
    if (player.hp <= 0)
    {
        flowchart.SendFungusMessage("lose");
        return;
    }

    if (BattleParam.Enemys == 1)
    {
        BattleParam.Enemys--;
        flowchart.SendFungusMessage("enemy1");
    }
    else if (BattleParam.Enemys == 0)
    {
        BattleParam.Enemys = 1;

        for (int i = 0; i <= 4; i++)
        {
            UI[i].SetActive(true);
        }
    }
}

public void PushAttackButton()
{
    //Enemy１体のhpをPlayerのatだけ減らす
    if (IsPlayerturn == true)
    {
        if(target == 0)
        {
            if (Lucky == 1)
            {
                if (BattleParam.Leo)
                {
                    flowchart.SendFungusMessage("leoattack");
                }
                else if (BattleParam.Sagittarius)
                {
                    flowchart.SendFungusMessage("sagittariusattack");
                }
                else if (BattleParam.Aries)
                {
                    PlayerAttack(0);
                }
                else
                {
                    PlayerAttack(0);
                }
            }
            else
            {
                PlayerAttack(0);
            }
        }
        else if(target == 1)
        {
            if (Lucky == 1)
            {
                if (BattleParam.Leo)
                {
                    flowchart.SendFungusMessage("leoattack1");
                }
                else if (BattleParam.Sagittarius)
                {
                    flowchart.SendFungusMessage("sagittariusattack1");
                }
                else if (BattleParam.Aries)
                {
                    PlayerAttack(1);
                }
                else
                {
                    PlayerAttack(1);
                }
            }
            else
            {
                PlayerAttack(1);
            }
        }
    }
}

//攻撃
public void PlayerAttack(int enemyID) {
    if (enemyID == 0)
    {
        enemy.OnDamage(player.at);
        AttackSound.Play();
        flowchart.SendFungusMessage("attack");
    }
    else if (enemyID == 1)
    {
        enemy1.OnDamage(player.at);
        AttackSound.Play();
        flowchart.SendFungusMessage("attack1");
    }
}

//攻撃力４倍
public void LeoAttack()
{
    player.at *= 4;
    if(target == 0)
    {
        enemy.OnDamage(player.at);
    }
    else if(target == 1)
    {
        enemy1.OnDamage(player.at);
    }
    player.at /= 4;
    AttackSound.Play();
}

//攻撃力2倍&HP1回復
public void SagittariusAttack()
{
    player.at *= 2;
    if(target == 0)
    {
        enemy.OnDamage(player.at);
    }
    else if(target == 1)
    {
        enemy1.OnDamage(player.at);
    }
    player.hp += 1;
    player.at /= 2;
    AttackSound.Play();
}

public void PushBarrierButton()
{
    //バリアでEnemyの攻撃を無効化
    //Playerのhpを２を消費する
    if (IsPlayerturn == true)
    {
        //バリアでEnemyの攻撃を無効化
        //Playerのhpを２を消費する
        if (IsPlayerturn == true)
        {
            if (Lucky == 1)
            {
                if (BattleParam.Aries)
                {
                    flowchart.SendFungusMessage("ariesbarrier");
                }
                else
                {
                    PlayerBarrier();
                }
            }
            else
            {
                PlayerBarrier();
            }
        }
    }
}

public void PlayerBarrier()
{
    enemy.Barrier();
    enemy1.Barrier();
    player.Barrier();
    BarrierSound.Play();
    flowchart.SendFungusMessage("barrier");
}

public void AriesBarrier()
{
    enemy.Barrier();
    enemy1.Barrier();
    BarrierSound.Play();
}

public void PushDelayButton()
{
    //Enemyのカウントを１増やす
    //Playerのhpを１消費する
    if (IsPlayerturn == true)
    {
        if(target == 0)
        {
            if (Lucky == 1)
            {
                if (BattleParam.Aries)
                {
                    flowchart.SendFungusMessage("ariesdelay");
                }
                else
                {
                    PlayerDelay(0);
                }
            }
            else
            {
                PlayerDelay(0);
            }
        }
        else if(target == 1)
        {
            if (Lucky == 1)
            {
                if (BattleParam.Aries)
                {
                    flowchart.SendFungusMessage("ariesdelay1");
                }
                else
                {
                    PlayerDelay(1);
                }
            }
            else
            {
                PlayerDelay(1);
            }
        }
    }
}

public void PlayerDelay(int enemyID)
{
    if(enemyID == 0)
    {
        enemy.Delay();
        player.Delay();
        DelaySound.Play();
        flowchart.SendFungusMessage("delay");
    }
    else if(enemyID == 1)
    {
        enemy1.Delay();
        player.Delay();
        DelaySound.Play();
        flowchart.SendFungusMessage("delay1");
    }
}

public void AriesDelay()
{
    if(target == 0)
    {
        enemy.Delay();
    }
    else if(target == 1)
    {
        enemy1.Delay();
    }
    DelaySound.Play();
}

public void PushUniverseButton()
{
    //敵のhpをPlayerのatだけ減らす
    //バリアでEnemyの攻撃を無効化
    //Enemyのカウントを１増やす
    //Playerのhpを３消費する
    if (IsPlayerturn == true)
    {
        if(target == 0)
        {
            if (Lucky == 1)
            {
                if (BattleParam.Leo)
                {
                    flowchart.SendFungusMessage("leouniverse");
                }
                else if (BattleParam.Aries)
                {
                    flowchart.SendFungusMessage("ariesuniverse");
                }
                else if (BattleParam.Sagittarius)
                {
                    flowchart.SendFungusMessage("sagittariusuniverse");
                }
                else
                {
                    PlayerUniverse(0);
                }
            }
            else
            {
                PlayerUniverse(0);
            }
        }
        else if(target == 1)
        {
            if (Lucky == 1)
            {
                if (BattleParam.Leo)
                {
                    flowchart.SendFungusMessage("leouniverse1");
                }
                else if (BattleParam.Aries)
                {
                    flowchart.SendFungusMessage("ariesuniverse1");
                }
                else if (BattleParam.Sagittarius)
                {
                    flowchart.SendFungusMessage("sagittariusuniverse1");
                }
                else
                {
                    PlayerUniverse(1);
                }
            }
            else
            {
                PlayerUniverse(1);
            }
        }
    }
}

public void PlayerUniverse(int enemyID)
{
    if(enemyID == 0)
    {
        enemy.OnDamage(player.at);
        enemy.Delay();
        enemy.Barrier();
        enemy1.Barrier();
        player.Universe();
        UniverseSound.Play();
        flowchart.SendFungusMessage("universe");
    }
    else if(enemyID == 1)
    {
        enemy1.OnDamage(player.at);
        enemy1.Delay();
        enemy.Barrier();
        enemy1.Barrier();
        player.Universe();
        UniverseSound.Play();
        flowchart.SendFungusMessage("universe1");
    }

}

public void LeoUniverse()
{
    player.at *= 4;
    if(target == 0)
    {
        enemy.OnDamage(player.at);
        enemy.Delay();
    }else if(target == 1)
    {
        enemy1.OnDamage(player.at);
        enemy1.Delay();
    }
    player.at /= 4;
    enemy.Barrier();
    enemy1.Barrier();
    player.Universe();
    UniverseSound.Play();
}

public void AriesUniverse()
{
    if(target == 0)
    {
        enemy.OnDamage(player.at);
        enemy.Delay();
    }
    else if(target == 1)
    {
        enemy1.OnDamage(player.at);
        enemy1.Delay();
    }
    enemy.Barrier();
    enemy1.Barrier();
    UniverseSound.Play();
}

public void SagittariusUniverse()
{
    player.at *= 2;
    if(target == 0)
    {
        enemy.OnDamage(player.at);
        enemy.Delay();
    }else if(target == 1)
    {
        enemy1.OnDamage(player.at);
        enemy1.Delay();
    }
    player.hp += 1;
    player.at /= 2;
    enemy.Barrier();
    enemy1.Barrier();
    player.Universe();
    UniverseSound.Play();
}

public void PushTargetChangeButton()
{
    //ターゲットを変更
    if (IsPlayerturn == true)
    {
        if (target == 0)
        {
            Target1.SetActive(true);
            Target.SetActive(false);
            target = 1;
            ChangeSound.Play();
        }
        else
        {
            Target.SetActive(true);
            Target1.SetActive(false);
            target = 0;
            ChangeSound.Play();
        }
    }
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
}*/