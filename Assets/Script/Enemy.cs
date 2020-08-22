using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  public Player player;
  public EnemyData EnemyData;
  public Fungus.Flowchart flowchart = null;
  //各パラメタ
  public int hp;
  public int Maxhp;
  public int at;
  public int saveat;
  public int df;
  public int savedf;
  public int[] ct;
  public int[] maxct;
  public bool[] atBuff;
  public int[] atBufftime;
  public bool[] dfBuff;
  public int[] dfBufftime;
  public int damage;
  public float magni;
  public int attackNum;
  public int playerattackNum;
  public GameObject DestroySound;
  public GameObject EnemyImage;

  public AudioSource CountMaxSound;
  public AudioSource BarrierSound;

  bool barrier;
  //hpUI
  public Slider HPSlider;

  public enum EnemyType
  {
    GOBLIN,
    SLIME
  }
  public EnemyType type;


  // Use this for initialization
  void Start()
  {
    hp = EnemyData.maxHp;
    at = EnemyData.at;
    df = EnemyData.df;
    Maxhp = hp;
    saveat = at;
    savedf = df;
    for (int i = 1; i <= 4; i++)
    {
      maxct[i] = EnemyData.ct[i];
    }

    HPSlider.maxValue = Maxhp;
    HPSlider.value = hp;
  }


  // Update is called once per frame
  void Update()
  {

  }
  public void OnDamage(int _damage)
  {
    hp -= _damage - df;
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }

  public void OnSuccessiveDamage(int _damage)
  {
    attackNum = Random.Range(2, 6);
    for (int i = 0; i <= attackNum; i++)
    {
      hp -= _damage - df;
    }
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }
  public void EnemyAction()
  {
    if (hp <= 0)
    {
      switch (type)
      {
        case EnemyType.GOBLIN:
          flowchart.SendFungusMessage("goblinfinish");
          break;
        case EnemyType.SLIME:
          flowchart.SendFungusMessage("enemyfinish1");
          break;
      }
      return;
    }

    switch (type)
    {
      case EnemyType.GOBLIN:
        if (ct[4] != 0)
        {
          ct[4] = maxct[4];
          df = df + savedf;
          dfBufftime[1] = 5;
          dfBuff[1] = true;
          flowchart.SendFungusMessage("goblinskill4");
          Debug.Log("4");
          return;
        }
        else if (ct[3] != 0)
        {
          ct[3] = maxct[3];
          at = at + saveat;
          atBufftime[1] = 5;
          atBuff[1] = true;
          flowchart.SendFungusMessage("goblinskill3");
          Debug.Log("3");
          return;
        }
        else if (ct[1] != 0)
        {
          ct[1] = maxct[1];
          magni = 2.0f;
          damage = (int)(at * magni);
          player.OnDamage(damage);
          flowchart.SendFungusMessage("goblinskill1");
          Debug.Log("1");
          return;
        }
        else if (ct[2] != 0)
        {
          ct[2] = maxct[2];
          magni = 1.5f;
          damage = (int)(at * magni);
          playerattackNum = 2;
          player.OnSuccessiveDamage(damage, playerattackNum);
          flowchart.SendFungusMessage("goblinskill2");
          Debug.Log("2");
          return;
        }
        else
        {
          damage = at;
          player.OnDamage(damage);
          flowchart.SendFungusMessage("goblinattack");
          Debug.Log("0");
          return;
        }
        break;
    }
  }

  public void EnemyTurnFinish()
  {
    if (player.hp <= 0)
    {
      flowchart.SendFungusMessage("lose");
      return;
    }

    for (int i = 1; i <= 4; i++)
    {
      if (ct[i] != 0)
      {
        ct[i]--;
      }
    }

    for (int i = 1; i <= 3; i++)
    {
      if (atBufftime[i] != 0)
      {
        atBufftime[i]--;
      }
      if (dfBufftime[i] != 0)
      {
        dfBufftime[i]--;
      }
    }

    if (atBuff[1])
    {
      if (atBufftime[1] == 0)
      {
        at = at - saveat;
      }
    }
    if (dfBuff[1])
    {
      if (dfBufftime[1] == 0)
      {
        df = df - savedf;
      }
    }
    flowchart.SendFungusMessage("enemyturnback");
  }
  public void Finish()
  {
    DestroySound.SetActive(true);
    EnemyImage.SetActive(false);
  }
}
