using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
  public Player player;
  public BattleSystemScript BattleSystem;
  public EnemyData EnemyData;
  public Fungus.Flowchart flowchart = null;
  //各パラメタ
  public int hp;
  public int Maxhp;
  public int at;
  public int saveat;
  public int df;
  public int savedf;
  public int heal;
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
  public int poisontime;
  public int burntime;
  public int clamtime;
  public int regenetime;
  public int damage;
  public float magni;
  public int attackNum;
  public int playerattackNum;
  public int ctNum;
  public GameObject DestroySound;
  public GameObject EnemyImage;
  public AudioSource BarrierSound;
  public Slider HPSlider;
  public Image sliderImage;
  public bool destroy;
  public string name;
  public bool[] condition;

  public enum EnemyType
  {
    GOBLIN,
    SLIME,
    MASH,
    SEED
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

    name = EnemyData.enemyName;
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
    if (destroy)
    {
      return;
    }
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

  public void OnSuccessiveDamage(int _damage)
  {
    if (destroy)
    {
      return;
    }
    attackNum = Random.Range(2, 6);
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
    for (int i = 1; i <= attackNum; i++)
    {
      hp -= _damage;
      BattleSystem.KnuckleAttackSound.Play();
    }
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }

  public void OnPenetrateDamage(int _damage)
  {
    if (destroy)
    {
      return;
    }
    if (_damage <= 0)
    {
      _damage = 1;
    }
    hp -= _damage;
    BattleSystem.PenetrateAttackSound.Play();
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }
  public void OnPenetrateSuccessiveDamage(int _damage)
  {
    if (destroy)
    {
      return;
    }
    attackNum = Random.Range(2, 6);
    if (_damage <= 0)
    {
      _damage = 1;
    }
    for (int i = 1; i <= attackNum; i++)
    {
      hp -= _damage;
      BattleSystem.PenetrateAttackSound.Play();
    }
    if (hp <= 0)
    {
      hp = 0;
    }
    HPSlider.value = hp;
  }

  public void HealDamage(int _heal)
  {
    if (destroy)
    {
      return;
    }
    hp = hp + _heal;
    if (hp > Maxhp)
    {
      hp = Maxhp;
    }
    HPSlider.value = hp;
  }

  /*public void RandomCommand()
  {
    int count = 0; // ctが0のものを数える用の変数
    List<int> ctList = new List<int>();
    for (int i = 1; i <= 4; i++)
    {
      if (ct[i] == 0)
      { //もしctが0のものがあったら
        count++; //countをプラスする
        ctList.Add(i); //Listにその番号を記録する
      }
    }
    ctNum = 0;
    if (count >= 2)
    { //もしCountが2以上(ctが0のものが2個以上だったら)
      while (ctNum == 0)
      {
        int x = Random.Range(0, ctList.Count);
        ctNum = ctList[x]; //ctNumに0~4の内、ctが0の中からランダムな値を入れる
      }
    }
    Debug.Log(ctNum); //このctNumにランダムな値が取れるからこれを使う！
  }*/

  public void DeathCheck()
  {
    if (!destroy)
    {
      BattleSystem.EnemyTurnBack();
      Finish();
      destroy = true;
      switch (type)
      {
        case EnemyType.GOBLIN:
          flowchart.SendFungusMessage("goblinfinish");
          break;
        case EnemyType.SLIME:
          flowchart.SendFungusMessage("slimefinish");
          break;
        case EnemyType.MASH:
          flowchart.SendFungusMessage("mashfinish");
          break;
        case EnemyType.SEED:
          flowchart.SendFungusMessage("seedfinish");
          break;
      }
    }
  }

  public void EnemyAction()
  {
    if (destroy)
    {
      NextAction();
      return;
    }
    switch (type)
    {
      case EnemyType.GOBLIN:
        if (ct[4] == 0 && hp <= Maxhp * 0.8)
        {
          GOBLINSkill4();
        }
        else if (ct[3] == 0 && hp >= Maxhp * 0.2)
        {
          GOBLINSkill3();
        }
        else if (ct[1] == 0 && ct[2] == 0)
        {
          ctNum = Random.Range(1, 3);
          switch (ctNum)
          {
            case 1:
              GOBLINSkill1();
              break;

            case 2:
              GOBLINSkill2();
              break;
          }
        }
        else if (ct[1] == 0)
        {
          GOBLINSkill1();
        }
        else if (ct[2] == 0)
        {
          GOBLINSkill2();
        }
        else
        {
          damage = at;
          player.OnDamage(damage);
          BattleSystem.AttackSound.Play();
          flowchart.SendFungusMessage("goblinattack");
          return;
        }
        break;

      case EnemyType.SLIME:
        if (ct[4] == 0 && hp <= Maxhp * 0.6)
        {
          SLIMESkill4();
        }
        else if (ct[3] == 0 && hp <= Maxhp * 0.8)
        {
          SLIMESkill3();
        }
        else if (ct[1] == 0 && player.hp <= player.Maxhp * 0.2)
        {
          SLIMESkill1();
        }
        else if (ct[2] == 0)
        {
          SLIMESkill2();
        }
        else if (ct[1] == 0)
        {
          SLIMESkill1();
        }
        else
        {
          damage = at;
          player.OnDamage(damage);
          BattleSystem.AttackSound.Play();
          flowchart.SendFungusMessage("slimeattack");
          return;
        }
        break;

      case EnemyType.MASH:
        if (ct[4] == 0 && hp <= Maxhp * 0.9)
        {
          MASHSkill4();
        }
        else if (ct[3] == 0 && hp <= Maxhp * 0.8 && !player.barrier)
        {
          MASHSkill3();
        }
        else if (ct[2] == 0 && player.hp >= player.Maxhp * 0.6 && !player.barrier)
        {
          MASHSkill2();
        }
        else if (ct[1] == 0)
        {
          MASHSkill1();
        }
        else if (ct[2] == 0 && !player.barrier)
        {
          MASHSkill2();
        }
        else
        {
          damage = at;
          player.OnDamage(damage);
          BattleSystem.AttackSound.Play();
          flowchart.SendFungusMessage("mashattack");
          return;
        }
        break;

      case EnemyType.SEED:
        if (ct[4] == 0 && hp <= Maxhp * 0.9)
        {
          SEEDSkill4();
        }
        else if (ct[3] == 0 && hp >= Maxhp * 0.2)
        {
          SEEDSkill3();
        }
        else if (ct[1] == 0 && ct[2] == 0)
        {
          ctNum = Random.Range(1, 3);
          switch (ctNum)
          {
            case 1:
              SEEDSkill1();
              break;

            case 2:
              SEEDSkill2();
              break;
          }
        }
        else if (ct[1] == 0)
        {
          SEEDSkill1();
        }
        else if (ct[2] == 0)
        {
          SEEDSkill2();
        }
        else
        {
          damage = at;
          player.OnDamage(damage);
          BattleSystem.AttackSound.Play();
          flowchart.SendFungusMessage("seedattack");
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
      if (barriertime[i] != 0)
      {
        barriertime[i]--;
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

    if (player.Prebarrier)
    {
      player.barrier = true;
    }

    CheckCondition();

    NextAction();

  }

  public void NextAction()
  {
    for (int i = 0; i <= 3; i++)
    {
      condition[i] = false;
    }
    if (BattleSystem.Enemys == 0)
    {
      player.PlayerTurnFinish();
      BattleSystem.Enemys = BattleSystem.SaveEnemys;
      return;
    }
    else if (BattleSystem.Enemys == 1)
    {
      flowchart.SendFungusMessage("enemy1");
      BattleSystem.Enemys--;
      return;
    }
    else if (BattleSystem.Enemys == 2)
    {
      flowchart.SendFungusMessage("enemy2");
      BattleSystem.Enemys--;
      return;
    }
  }

  public void CheckCondition()
  {
    if (regenetime != 0 && !condition[0])
    {
      condition[0] = true;
      regenetime--;
      hp = hp + (int)(Maxhp * 0.1f);
      HPSlider.value = hp;
      BattleSystem.RegeneSound.Play();
      StartCoroutine(Checking(() =>
            {
              CheckCondition();
            }));
      return;
    }
    if (poisontime != 0 && !condition[1])
    {
      condition[1] = true;
      poisontime--;
      hp = hp - (int)(Maxhp * 0.1f);
      HPSlider.value = hp;
      BattleSystem.PoisonSound.Play();
      StartCoroutine(Checking(() =>
            {
              CheckCondition();
            }));
      return;
    }
    if (burntime != 0 && !condition[2])
    {
      condition[2] = true;
      burntime--;
      hp = hp - (int)(saveat * 0.2f);
      HPSlider.value = hp;
      BattleSystem.BurnSound.Play();
      StartCoroutine(Checking(() =>
            {
              CheckCondition();
            }));
      return;
    }
    if (clamtime != 0 && !condition[3])
    {
      condition[3] = true;
      clamtime--;
      return;
    }
  }

  public delegate void functionType();
  private IEnumerator Checking(functionType callback)
  {
    while (true)
    {
      yield return new WaitForFixedUpdate();
      if (!BattleSystem.RegeneSound.isPlaying && !BattleSystem.PoisonSound.isPlaying && !BattleSystem.BurnSound.isPlaying)
      {
        callback();
        break;
      }
    }
  }
  public void Finish()
  {
    DestroySound.SetActive(true);
    EnemyImage.SetActive(false);
  }

  public void GOBLINSkill1()
  {
    ct[1] = maxct[1] + 1;
    int lucky = Random.Range(0, 10);
    magni = 2.0f;
    if (lucky == 0)
    {
      magni = magni * 2.0f;
    }
    damage = (int)(at * magni);
    player.OnDamage(damage);
    BattleSystem.SlashSound.Play();
    flowchart.SendFungusMessage("goblinskill1");
    return;
  }
  public void GOBLINSkill2()
  {
    ct[2] = maxct[2] + 1;
    magni = 1.5f;
    damage = (int)(at * magni);
    playerattackNum = 2;
    player.OnSuccessiveDamage(damage, playerattackNum);
    BattleSystem.DoubleSlashSound.Play();
    flowchart.SendFungusMessage("goblinskill2");
    return;
  }
  public void GOBLINSkill3()
  {
    ct[3] = maxct[3] + 1;
    at = at + saveat;
    atBufftime[1] = 5;
    BattleSystem.RageSound.Play();
    flowchart.SendFungusMessage("goblinskill3");
    return;
  }
  public void GOBLINSkill4()
  {
    ct[4] = maxct[4] + 1;
    df = df + savedf;
    dfBufftime[1] = 5;
    BattleSystem.ProtectSound.Play();
    flowchart.SendFungusMessage("goblinskill4");
    return;
  }

  public void SLIMESkill1()
  {
    ct[1] = maxct[1] + 1;
    int lucky = Random.Range(0, 10);
    magni = 2.0f;
    damage = (int)(at * magni);
    player.OnDamage(damage);
    BattleSystem.SlimeSound.Play();
    if (!player.Prebarrier)
    {
      if (lucky == 0)
      {
        player.atDeBufftime[3] = 3;
        player.at = player.at - (int)(saveat * 0.2f);
      }
    }
    flowchart.SendFungusMessage("slimeskill1");
    return;
  }

  public void SLIMESkill2()
  {
    ct[2] = maxct[2] + 1;
    if (!player.Prebarrier)
    {
      player.poisontime = 4;
    }
    magni = 1.0f;
    damage = (int)(at * magni);
    player.OnDamage(damage);
    BattleSystem.VenomSound.Play();
    flowchart.SendFungusMessage("slimeskill2");
    return;
  }

  public void SLIMESkill3()
  {
    ct[3] = maxct[3] + 1;
    barriertime[1] = 6;
    BattleSystem.BarrierSound.Play();
    flowchart.SendFungusMessage("slimeskill3");
    return;
  }

  public void SLIMESkill4()
  {
    ct[4] = maxct[4] + 1;
    heal = (int)(Maxhp * 0.4f);
    HealDamage(heal);
    BattleSystem.HealSound.Play();
    flowchart.SendFungusMessage("slimeskill4");
    return;
  }

  public void MASHSkill1()
  {
    ct[1] = maxct[1] + 1;
    int lucky = Random.Range(0, 10);
    magni = 2.0f;
    damage = (int)(at * magni);
    player.OnDamage(damage);
    if (!player.Prebarrier)
    {
      if (lucky == 0)
      {
        player.dfDeBufftime[3] = 3;
        player.df = player.df - (int)(savedf * 0.2f);
      }
    }
    BattleSystem.WhipSound.Play();
    flowchart.SendFungusMessage("mashskill1");
    return;
  }

  public void MASHSkill2()
  {
    ct[2] = maxct[2] + 1;
    if (!player.Prebarrier)
    {
      player.poisontime = 4;
    }
    magni = 1.0f;
    damage = (int)(at * magni);
    player.OnDamage(damage);
    BattleSystem.VenomSound.Play();
    flowchart.SendFungusMessage("mashskill2");
    return;
  }

  public void MASHSkill3()
  {
    ct[3] = maxct[3] + 1;
    if (!player.Prebarrier)
    {
      player.at = player.at - (int)(player.saveat * 0.5);
      player.atDeBufftime[1] = 4;
      BattleSystem.DebuffSound.Play();
    }
    flowchart.SendFungusMessage("mashskill3");
    return;
  }

  public void MASHSkill4()
  {
    ct[4] = maxct[4] + 1;
    regenetime = 4;
    BattleSystem.TakerootSound.Play();
    flowchart.SendFungusMessage("mashskill4");
    return;
  }

  public void SEEDSkill1()
  {
    ct[1] = maxct[1] + 1;
    int lucky = Random.Range(0, 10);
    magni = 2.0f;
    damage = (int)(at * magni);
    player.OnDamage(damage);
    if (!player.Prebarrier)
    {
      if (lucky == 0)
      {
        player.dfDeBufftime[3] = 3;
        player.df = player.df - (int)(savedf * 0.2f);
      }
    }
    BattleSystem.WhipSound.Play();
    flowchart.SendFungusMessage("seedskill1");
    return;
  }

  public void SEEDSkill2()
  {
    ct[2] = maxct[2] + 1;
    int lucky = Random.Range(0, 10);
    magni = 2.0f;
    damage = (int)(at * magni);
    player.OnDamage(damage);
    if (lucky == 0)
    {
      atBufftime[0] = 4;
      at = at + (int)(saveat * 0.2f);
    }
    flowchart.SendFungusMessage("seedskill2");
    BattleSystem.BiteSound.Play();
    return;
  }

  public void SEEDSkill3()
  {
    ct[3] = maxct[3] + 1;
    at = at + saveat;
    atBufftime[1] = 5;
    BattleSystem.RageSound.Play();
    flowchart.SendFungusMessage("seedskill3");
    return;
  }

  public void SEEDSkill4()
  {
    ct[4] = maxct[4] + 1;
    regenetime = 4;
    BattleSystem.TakerootSound.Play();
    flowchart.SendFungusMessage("seedskill4");
    return;
  }


}
