using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarCommandButtonScript : MonoBehaviour
{

  public BattleParam BattleParam;
  public Button Button;
  public Color[] color;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (BattleParam.Aries)
    {
      Button.GetComponent<Image>().color = color[1];
    }
    else if (BattleParam.Leo)
    {
      Button.GetComponent<Image>().color = color[2];
    }
    else if (BattleParam.Sagittarius)
    {
      Button.GetComponent<Image>().color = color[3];
    }
  }
}
