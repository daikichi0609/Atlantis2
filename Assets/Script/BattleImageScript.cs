using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleImageScript : MonoBehaviour
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
    switch (Num)
    {
      case 0:
        BattleText.GuardText();
        break;
      case 1:
        BattleText.PoisonText();
        break;
      case 2:
        BattleText.BurnText();
        break;
      case 3:
        BattleText.ClamText();
        break;
    }
  }
}
