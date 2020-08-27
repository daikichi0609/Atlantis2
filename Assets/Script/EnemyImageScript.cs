using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImageScript : MonoBehaviour
{
  public BattleSystemScript BattleSystem;
  public BattleTextScript BattleText;
  public int Num;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Click()
  {
    BattleSystem.target = Num;
    BattleSystem.Target[Num].SetActive(true);
    switch (Num)
    {
      case 0:
        BattleSystem.Target[1].SetActive(false);
        BattleSystem.Target[2].SetActive(false);
        break;
      case 1:
        BattleSystem.Target[0].SetActive(false);
        BattleSystem.Target[2].SetActive(false);
        break;
      case 2:
        BattleSystem.Target[0].SetActive(false);
        BattleSystem.Target[2].SetActive(false);
        break;
    }
    BattleText.EnemyText(Num);
  }
}
