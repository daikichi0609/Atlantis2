using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonScript : MonoBehaviour
{

  public PlayerData PlayerData;
  public int Num;
  private Button Button;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Num == 5)
    {
      if (PlayerData.Lv < 3)
      {
        Button.interactable = false;
      }
    }
  }
}
