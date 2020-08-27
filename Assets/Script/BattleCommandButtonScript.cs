using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCommandButtonScript : MonoBehaviour
{
  public PlayerData PlayerData;
  public BattleSystemScript BattleSystem;
  public Player player;
  public Enemy[] enemy;
  public Fungus.Flowchart flowchart = null;
  public int damage;
  public int heal;
  public Button Button;
  public int Num;
  public Text ExplainText;
  public Text CTText;

  // Use this for initialization
  void Start()
  {
    Button.GetComponentInChildren<Text>().text = PlayerData.skillname[PlayerData.CommandNum[Num]];
    Button.GetComponent<Image>().color = PlayerData.buttonColors[PlayerData.CommandNum[Num]];
    switch (PlayerData.CommandNum[Num])
    {
      case 1:
        Button.onClick.AddListener(Skill1);
        break;
      case 2:
        Button.onClick.AddListener(Skill2);
        break;
      case 3:
        Button.onClick.AddListener(Skill3);
        break;
      case 4:
        Button.onClick.AddListener(Skill4);
        break;
      case 5:
        Button.onClick.AddListener(Skill5);
        break;
      case 6:
        Button.onClick.AddListener(Skill6);
        break;
      case 7:
        Button.onClick.AddListener(Skill7);
        break;
      case 8:
        Button.onClick.AddListener(Skill8);
        break;
      case 9:
        Button.onClick.AddListener(Skill9);
        break;
      case 10:
        Button.onClick.AddListener(Skill10);
        break;
      case 11:
        Button.onClick.AddListener(Skill11);
        break;
      case 12:
        Button.onClick.AddListener(Skill12);
        break;
      case 13:
        Button.onClick.AddListener(Skill13);
        break;
      case 14:
        Button.onClick.AddListener(Skill14);
        break;
      case 15:
        Button.onClick.AddListener(Skill15);
        break;
      case 16:
        Button.onClick.AddListener(Skill16);
        break;
      case 17:
        Button.onClick.AddListener(Skill17);
        break;
      case 18:
        Button.onClick.AddListener(Skill18);
        break;
      case 19:
        Button.onClick.AddListener(Skill19);
        break;
      case 20:
        Button.onClick.AddListener(Skill20);
        break;
      case 21:
        Button.onClick.AddListener(Skill21);
        break;
      case 22:
        Button.onClick.AddListener(Skill22);
        break;
      case 23:
        Button.onClick.AddListener(Skill23);
        break;
      case 24:
        Button.onClick.AddListener(Skill24);
        break;
      case 25:
        Button.onClick.AddListener(Skill25);
        break;
      case 26:
        Button.onClick.AddListener(Skill26);
        break;
      case 27:
        Button.onClick.AddListener(Skill27);
        break;
      case 28:
        Button.onClick.AddListener(Skill28);
        break;
      case 29:
        Button.onClick.AddListener(Skill29);
        break;
      case 30:
        Button.onClick.AddListener(Skill30);
        break;
    }
  }

  // Update is called once per frame
  void Update()
  {
    if (player.ct[Num] != 0)
    {
      Button.GetComponent<Image>().color = PlayerData.buttonColors[0];
    }
    else
    {
      Button.GetComponent<Image>().color = PlayerData.buttonColors[PlayerData.CommandNum[Num]];
    }
  }

  public void CoolTime()
  {
    ExplainText.text = "発動可能まで残り" + player.ct[Num].ToString() + "ターン";
    CTText.text = "";
  }

  public void Skill1()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.magni = 3.5f;
      damage = (int)(player.at * player.magni);
      enemy[BattleSystem.target].OnDamage(damage);
      BattleSystem.KnuckleAttackSound.Play();
      flowchart.SendFungusMessage("skill1");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill2()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.magni = 1.2f;
      damage = (int)(player.at * player.magni);
      enemy[BattleSystem.target].OnSuccessiveDamage(damage);
      flowchart.SendFungusMessage("skill2");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill3()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.Prebarrier = true;
      player.barriertime[1] = 6;
      BattleSystem.BarrierSound.Play();
      flowchart.SendFungusMessage("skill3");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill4()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      heal = (int)(player.Maxhp * 0.4f);
      player.HealDamage(heal);
      BattleSystem.HealSound.Play();
      flowchart.SendFungusMessage("skill4");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill5()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.magni = 3.5f;
      damage = (int)(player.saveat * player.magni);
      enemy[BattleSystem.target].OnPenetrateDamage(damage);
      BattleSystem.PenetrateAttackSound.Play();
      flowchart.SendFungusMessage("skill5");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill6()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.magni = 1.2f;
      damage = (int)(player.saveat * player.magni);
      enemy[BattleSystem.target].OnPenetrateSuccessiveDamage(damage);
      flowchart.SendFungusMessage("skill6");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill7()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.magni = 1.0f;
      if (enemy[BattleSystem.target].barriertime[1] != 0 || enemy[BattleSystem.target].barriertime[2] != 0 || enemy[BattleSystem.target].barriertime[3] != 0)
      {
        player.magni = 4.0f;
        for (int i = 1; i <= 3; i++)
        {
          enemy[BattleSystem.target].barriertime[i] = 0;
        }
        BattleSystem.BreakSound.Play();
      }
      damage = (int)(player.at * player.magni);
      enemy[BattleSystem.target].OnDamage(damage);
      flowchart.SendFungusMessage("skill7");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill8()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.magni = 2.5f;
      damage = (int)(player.at * player.magni);
      for (int i = 0; i <= BattleSystem.SaveEnemys; i++)
      {
        enemy[i].OnDamage(damage);
      }
      BattleSystem.ExtentSound.Play();
      flowchart.SendFungusMessage("skill8");
      return;
    }
    else
    {
      CoolTime();
    }
  }

  public void Skill9()
  {
    if (player.ct[Num] == 0)
    {
      player.ct[Num] = player.maxct[Num] + 1;
      player.magni = 2.5f;
      damage = (int)(player.at * player.magni);
      for (int i = 0; i <= BattleSystem.SaveEnemys; i++)
      {
        enemy[i].OnPenetrateDamage(damage);
      }
      BattleSystem.OrangeSound.Play();
      flowchart.SendFungusMessage("skill9");
      return;
    }
    else
    {
      CoolTime();
    }
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
