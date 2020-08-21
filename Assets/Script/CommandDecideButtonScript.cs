using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandDecideButtonScript : MonoBehaviour
{
  public PlayerData PlayerData;
  public int CommandNum;
  public Text CommandText;
  public GameObject CommandButton;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    CommandText.text = PlayerData.skillname[CommandNum];
    CommandButton.GetComponent<Image>().color = PlayerData.buttonColors[CommandNum];
  }
}
