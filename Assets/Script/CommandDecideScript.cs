using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandDecideScript : MonoBehaviour
{
  public PlayerData PlayerData;
  public CommandDecideButtonScript[] ButtonScript;
  public int CommandNum;
  public int[] OldNum;
  public bool[] changed;
  public GameObject[] CommandMenu;
  public GameObject CommandDecideMenu;

  // Use this for initialization
  void Start()
  {
    OldNum[1] = PlayerData.CommandNum[1];
    OldNum[2] = PlayerData.CommandNum[2];
    OldNum[3] = PlayerData.CommandNum[3];
    OldNum[4] = PlayerData.CommandNum[4];
  }

  // Update is called once per frame
  void Update()
  {
    ButtonScript[1].CommandNum = PlayerData.CommandNum[1];
    ButtonScript[2].CommandNum = PlayerData.CommandNum[2];
    ButtonScript[3].CommandNum = PlayerData.CommandNum[3];
    ButtonScript[4].CommandNum = PlayerData.CommandNum[4];
  }

  public void CommandDecide1()
  {
    if (changed[1])
    {
      PlayerData.CommandNum[1] = OldNum[1];
      changed[1] = false;
      return;
    }
    else if (!changed[1])
    {
      NumberReset();
      changed[1] = true;
      PlayerData.CommandNum[1] = CommandNum;
    }
  }
  public void CommandDecide2()
  {
    if (changed[2])
    {
      PlayerData.CommandNum[2] = OldNum[2];
      changed[2] = false;
      return;
    }
    else if (!changed[2])
    {
      NumberReset();
      changed[2] = true;
      PlayerData.CommandNum[2] = CommandNum;
    }
  }
  public void CommandDecide3()
  {
    if (changed[3])
    {
      PlayerData.CommandNum[3] = OldNum[3];
      changed[3] = false;
      return;
    }
    else if (!changed[3])
    {
      NumberReset();
      changed[3] = true;
      PlayerData.CommandNum[3] = CommandNum;
    }
  }
  public void CommandDecide4()
  {
    if (changed[4])
    {
      PlayerData.CommandNum[4] = OldNum[4];
      changed[4] = false;
      return;
    }
    else if (!changed[4])
    {
      NumberReset();
      changed[4] = true;
      PlayerData.CommandNum[4] = CommandNum;
    }
  }
  public void NumberReset()
  {
    for (int i = 1; i <= 4; i++)
    {
      PlayerData.CommandNum[i] = OldNum[i];
      changed[i] = false;
    }
  }

  public void Finish()
  {
    for (int i = 1; i <= 4; i++)
    {
      changed[i] = false;
    }
    CommandNum = 0;
    CommandDecideMenu.SetActive(false);
    CommandMenu[0].SetActive(true);
    CommandMenu[1].SetActive(true);
  }
}
