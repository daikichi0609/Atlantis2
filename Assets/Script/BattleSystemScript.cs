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
  public Enemy enemy;
  public Fungus.Flowchart flowchart = null;
  bool IsPlayerturn = true;
  public int damage;
  public int heal;
  public AudioSource AttackSound;
  public AudioSource BarrierSound;
  public AudioSource DelaySound;
  public AudioSource UniverseSound;
  public AudioSource ClockSound;
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
      if (enemy.hp <= 0)
      {
        flowchart.SendFungusMessage("win");
      }
      else
      {
        flowchart.SendFungusMessage("enemy");
        EnemyTurnBack();
      }
    }
    AtText.text = player.at.ToString();
    DfText.text = player.df.ToString();
    HpText.text = player.hp.ToString();

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
      enemy.OnDamage(player.at);
      AttackSound.Play();
      flowchart.SendFungusMessage("attack");
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

  public void Skill1()
  {
    player.magni = 3.5f;
    damage = (int)(player.at * player.magni);
    enemy.OnDamage(damage);
    flowchart.SendFungusMessage("skill1");
  }

  public void Skill2()
  {
    player.magni = 1.2f;
    damage = (int)(player.at * player.magni);
    enemy.OnSuccessiveDamage(damage);
    flowchart.SendFungusMessage("akill2");
  }

  public void Skill3()
  {
    player.barrier[1] = true;
    player.effecttime[1] = 6;
    flowchart.SendFungusMessage("skill3");
  }

  public void Skill4()
  {
    heal = (int)(player.Maxhp * 0.4f);
    player.HealDamage(heal);
    flowchart.SendFungusMessage("skill4");
  }

  public void Skill5()
  {

  }

  public void Skill6()
  {

  }

  public void Skill7()
  {

  }

  public void Skill8()
  {

  }

  public void Skill9()
  {

  }

  public void Skill10()
  {

  }

  public void Skill11()
  {

  }

  public void Skill12()
  {

  }

  public void Skill13()
  {

  }

  public void Skill14()
  {

  }

  public void Skill15()
  {

  }

  public void Skill16()
  {

  }

  public void Skill17()
  {

  }

  public void Skill18()
  {

  }

  public void Skill19()
  {

  }

  public void Skill20()
  {

  }

  public void Skill21()
  {

  }

  public void Skill22()
  {

  }

  public void Skill23()
  {

  }

  public void Skill24()
  {

  }

  public void Skill25()
  {

  }

  public void Skill26()
  {

  }

  public void Skill27()
  {

  }

  public void Skill28()
  {

  }

  public void Skill29()
  {

  }

  public void Skill30()
  {

  }
}
