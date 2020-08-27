using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//１対１の場合のバトルシステム
public class BattleSystemScript : MonoBehaviour
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
  public AudioSource BreakSound;
  public AudioSource ExtentSound;
  public AudioSource RegeneSound;
  public AudioSource BurnSound;
  public AudioSource OrangeSound;
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
  public int SaveEnemys;
  public int target;
  public GameObject[] Target;

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
    SaveEnemys = Enemys;
    Target[0].SetActive(true);
    Target[1].SetActive(false);
    Target[2].SetActive(false);
  }
  // Update is called once per frame
  void Update()
  {
    if (!IsPlayerturn)
    {
      switch (SaveEnemys)
      {
        case 0:
          if (enemy[0].hp <= 0 && !enemy[0].destroy)
          {
            enemy[0].DeathCheck();
          }
          else if (enemy[0].hp <= 0 && enemy[0].destroy)
          {
            flowchart.SendFungusMessage("win");
          }
          else
          {
            flowchart.SendFungusMessage("enemy");
            EnemyTurnBack();
          }
          break;

        case 1:
          if (enemy[0].hp <= 0 && !enemy[0].destroy)
          {
            enemy[0].DeathCheck();
          }
          else if (enemy[1].hp <= 0 && !enemy[1].destroy)
          {
            enemy[1].DeathCheck();
          }
          else if (enemy[0].hp <= 0 && enemy[1].hp <= 0)
          {
            flowchart.SendFungusMessage("win");
          }
          else
          {
            flowchart.SendFungusMessage("enemy");
            EnemyTurnBack();
          }
          break;

        case 2:
          if (enemy[0].hp <= 0)
          {
            enemy[0].DeathCheck();
          }
          else if (enemy[1].hp <= 0)
          {
            enemy[1].DeathCheck();
          }
          else if (enemy[2].hp <= 0)
          {
            enemy[2].DeathCheck();
          }
          else if (enemy[0].hp <= 0 && enemy[1].hp <= 0 && enemy[2].hp <= 0)
          {
            flowchart.SendFungusMessage("win");
          }
          else
          {
            flowchart.SendFungusMessage("enemy");
            EnemyTurnBack();
          }
          break;
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
    if (IsPlayerturn)
    {
      switch (Enemys)
      {
        case 1:
          if (enemy[0].destroy)
          {
            target = 1;
            Target[0].SetActive(false);
            Target[1].SetActive(true);
            return;
          }
          else if (enemy[1].destroy)
          {
            target = 0;
            Target[0].SetActive(true);
            Target[1].SetActive(false);
            return;
          }
          else if (enemy[0].destroy && enemy[1].destroy)
          {
            Target[0].SetActive(true);
            Target[1].SetActive(false);
          }
          if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
          {
            if (target == 0)
            {
              target = 1;
              Target[0].SetActive(false);
              Target[1].SetActive(true);
              Target[2].SetActive(false);
            }
          }
          else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
          {
            if (target == 1)
            {
              target = 0;
              Target[0].SetActive(true);
              Target[1].SetActive(false);
              Target[2].SetActive(false);
            }
          }
          break;
        case 2:
          if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
          {
            if (target == 0)
            {
              target = 1;
              Target[0].SetActive(false);
              Target[1].SetActive(true);
              Target[2].SetActive(false);
              return;
            }
            else if (target == 1)
            {
              target = 2;
              Target[0].SetActive(false);
              Target[1].SetActive(false);
              Target[2].SetActive(true);
              return;
            }
          }
          else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
          {
            if (target == 1)
            {
              target = 0;
              Target[0].SetActive(true);
              Target[1].SetActive(false);
              Target[2].SetActive(false);
              return;
            }
            else if (target == 2)
            {
              target = 1;
              Target[0].SetActive(false);
              Target[1].SetActive(true);
              Target[2].SetActive(false);
              return;
            }
          }
          break;
      }
    }
  }
  public void EnemyTurnFinishReady()
  {
    switch (SaveEnemys)
    {
      case 0:
        enemy[0].EnemyTurnFinish();
        break;
      case 1:
        if (Enemys == 0)
        {
          enemy[1].EnemyTurnFinish();
          return;
        }
        else if (Enemys == 1)
        {
          enemy[0].EnemyTurnFinish();
          return;
        }
        break;
      case 2:
        if (Enemys == 0)
        {
          enemy[1].EnemyTurnFinish();
          return;
        }
        else if (Enemys == 1)
        {
          enemy[1].EnemyTurnFinish();
          return;
        }
        else if (Enemys == 2)
        {
          enemy[0].EnemyTurnFinish();
          return;
        }
        break;
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
    for (int i = 0; i <= 3; i++)
    {
      player.condition[i] = false;
    }
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
