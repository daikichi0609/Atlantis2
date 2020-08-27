using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCommandTextScript : MonoBehaviour
{

  public PlayerData PlayerData;
  public Text Text;
  public int Num;
  public int CommandNum;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    CommandNum = PlayerData.CommandNum[Num];
    Text.text = PlayerData.skillname[CommandNum];
    //Text.color = PlayerData.buttonColors[CommandNum];
  }
}
