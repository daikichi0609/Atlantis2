using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  //プレイヤーの情報
  public PlayerData PlayerData;
  public BattleSystemScript BattleSystem;
  public Fungus.Flowchart flowchart = null;
  //各パラメタ
  public int hp;
  public int Maxhp;
  public int at;
  public int saveat;
  public int df;
  public int savedf;
  public float magni;
  public int[] ct;
  public int[] maxct;
  public int[] barriertime;
  //１＝5割 2＝8割 3 = 10割
  public int[] atBufftime;
  //１＝×２ ２＝×3.5 3=×5
  public int[] dfBufftime;
  //１＝×２ ２＝×3.5 3=×5
  public int[] atDeBufftime;
  //１＝×0.5 ２＝×0 3=×0.8
  public int[] dfDeBufftime;
  //１＝×0.5 ２＝×0 3=×0.8
  public int regenetime;
  public int poisontime;
  public int burntime;
  public int clamtime;
  public bool barrier;
  public bool Prebarrier;
  public Slider HPSlider;
  public Image sliderImage;
  public bool[] condition;

  // Use this for initialization
  void Start()
  {
    //パラメタ代入
    at = PlayerData.AT;
    df = PlayerData.DF;
    hp = PlayerData.HP;
    Maxhp = hp;
    saveat = at;
    savedf = df;
    for (int i = 1; i <= 4; i++)
    {
      maxct[i] = PlayerData.CT[PlayerData.CommandNum[i]];
    }
    HPSlider.maxValue = Maxhp;
    HPSlider.value = hp;
  }

  // Update is called once per frame
  void Update()
  {
    if (poisontime != 0)
    {
      sliderImage.color = BattleSystem.Textcolor[8];
    }
    else if (burntime != 0)
    {
      sliderImage.color = BattleSystem.Textcolor[9];
    }
    else if (clamtime != 0)
    {
      sliderImage.color = BattleSystem.Textcolor[10];
    }
    else
    {
      sliderImage.color = BattleSystem.Textcolor[7];
    }

    if (barriertime[3] != 0)
    {
      barriertime[1] = 0;
      barriertime[2] = 0;
    }
    else if (barriertime[2] != 0)
    {
      barriertime[1] = 0;
    }
  }

  public void OnDamage(int _damage)
  {
    _damage = _damage - df;
    if (barriertime[1] != 0)
    {
      _damage = (int)(_damage * 0.5f);
    }
    else if (barriertime[2] != 0)
    {
      _damage = (int)(_damage * 0.2f);
    }
    if (_damage <= 0 || barriertime[3] != 0)
    {
      _damage = 1;
    }
    hp -= _damage;
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }

  public void OnSuccessiveDamage(int _damage, int _attackNum)
  {
    _damage = _damage - df;
    if (barriertime[1] != 0)
    {
      _damage = (int)(_damage * 0.5f);
    }
    else if (barriertime[2] != 0)
    {
      _damage = (int)(_damage * 0.2f);
    }
    if (_damage <= 0 || barriertime[3] != 0)
    {
      _damage = 1;
    }
    for (int i = 1; i <= _attackNum; i++)
    {
      hp -= _damage;
    }
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }

  public void OnPenetrateDamage(int _damage)
  {
    if (_damage <= 0)
    {
      _damage = 1;
    }
    hp -= _damage;
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }

  public void OnPenetrateSuccessiveDamage(int _damage, int _attackNum)
  {
    if (_damage <= 0)
    {
      _damage = 1;
    }
    for (int i = 1; i <= _attackNum; i++)
    {
      hp -= _damage;
    }
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }

  public void HealDamage(int _heal)
  {
    hp = hp + _heal;
    if (hp > Maxhp)
    {
      hp = Maxhp;
    }
    HPSlider.value = hp;
  }

  public void PlayerTurnFinish()
  {
    for (int i = 1; i <= 4; i++)
    {
      if (ct[i] != 0)
      {
        ct[i]--;
      }
    }

    for (int i = 1; i <= 3; i++)
    {
      if (barriertime[i] != 0)
      {
        barriertime[i]--;
        if (barriertime[i] == 0)
        {
          Prebarrier = false;
          barrier = false;
        }
      }
    }

    for (int i = 0; i <= 3; i++)
    {
      if (atBufftime[i] != 0)
      {
        atBufftime[i]--;
        if (atBufftime[i] == 0)
        {
          switch (i)
          {
            case 0:
              at = at - (int)(saveat * 0.2);
              break;
            case 1:
              at = at - saveat;
              break;
            case 2:
              at = at - (int)(saveat * 2.5f);
              break;
            case 3:
              at = at - saveat * 4;
              break;
          }
        }
      }
      if (dfBufftime[i] != 0)
      {
        dfBufftime[i]--;
        if (dfBufftime[i] == 0)
        {
          switch (i)
          {
            case 0:
              df = df - (int)(savedf * 0.2);
              break;
            case 1:
              df = df - savedf;
              break;
            case 2:
              df = df - (int)(savedf * 2.5f);
              break;
            case 3:
              df = df - savedf * 4;
              break;
          }
        }
      }
    }

    for (int i = 1; i <= 3; i++)
    {

      if (atDeBufftime[i] != 0)
      {
        atDeBufftime[i]--;
        if (atDeBufftime[i] == 0)
        {
          switch (i)
          {
            case 1:
              at = at + (int)(saveat * 0.5f);
              break;
            case 2:
              at = at + saveat;
              break;
            case 3:
              at = at + (int)(saveat * 0.2f);
              break;
          }
        }
      }
      if (dfDeBufftime[i] != 0)
      {
        dfDeBufftime[i]--;
        if (dfDeBufftime[i] == 0)
        {
          switch (i)
          {
            case 1:
              df = df + (int)(savedf * 0.5f);
              break;
            case 2:
              df = df + savedf;
              break;
            case 3:
              df = df + (int)(savedf * 0.2f);
              break;
          }
        }
      }
    }
    CheckCondition();
  }
  public void CheckCondition()
  {
    if (hp <= 0)
    {
      flowchart.SendFungusMessage("lose");
      return;
    }
    if (regenetime != 0 && !condition[0])
    {
      condition[0] = true;
      regenetime--;
      hp = hp + (int)(Maxhp * 0.1f);
      HPSlider.value = hp;
      BattleSystem.RegeneSound.Play();
      flowchart.SendFungusMessage("regene");
      return;
    }
    else if (poisontime != 0 && !condition[1])
    {
      condition[1] = true;
      poisontime--;
      hp = hp - (int)(Maxhp * 0.1f);
      HPSlider.value = hp;
      BattleSystem.PoisonSound.Play();
      flowchart.SendFungusMessage("poison");
      return;
    }
    else if (burntime != 0 && !condition[2])
    {
      condition[2] = true;
      burntime--;
      hp = hp - (int)(saveat * 0.2f);
      HPSlider.value = hp;
      BattleSystem.BurnSound.Play();
      flowchart.SendFungusMessage("burn");
      return;
    }
    else if (clamtime != 0 && !condition[3])
    {
      condition[3] = true;
      clamtime--;
      return;
    }
    else
    {
      flowchart.SendFungusMessage("enemyturnback");
      return;
    }
  }
}
