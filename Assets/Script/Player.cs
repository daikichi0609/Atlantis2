using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  //プレイヤーの情報
  public PlayerData PlayerData;
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
  public int[] effecttime;
  public bool[] barrier;
  public Slider HPSlider;
  public AudioSource DamageSound;
  public bool poison;

  // Use this for initialization
  void Start()
  {
    //パラメタ代入
    at = PlayerData.AT;
    df = PlayerData.DF;
    hp = PlayerData.HP;
    Maxhp = hp;
    for (int i = 1; i <= 4; i++)
    {
      ct[i] = PlayerData.CT[PlayerData.CommandNum[i]];
      maxct[i] = ct[i];
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
    if (barrier[1])
    {
      _damage = (int)(_damage * 0.5f);
    }
    _damage = _damage - df;
    if (_damage <= 0)
    {
      _damage = 1;
    }
    hp -= _damage;
    DamageSound.Play();
    HPSlider.value = hp;
  }

  public void OnSuccessiveDamage(int _damage, int _attackNum)
  {
    _damage = _damage - df;
    if (barrier[1])
    {
      _damage = (int)(_damage * 0.5f);
    }
    if (_damage <= 0)
    {
      _damage = 1;
    }
    for (int i = 0; i <= _attackNum; i++)
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

    if (barrier[1])
    {
      if (effecttime[1] != 0)
      {
        effecttime[1]--;
      }
      if (effecttime[1] == 0)
      {
        barrier[1] = false;
      }
    }
  }

  public void Poison()
  {
    //毒
    poison = true;
  }


}
