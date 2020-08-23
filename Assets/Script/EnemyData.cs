using System.Collections;

using System.Collections.Generic;

using UnityEngine;



[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]

public class EnemyData : ScriptableObject
{

  public string enemyName;
  public int at;
  public int df;
  public int maxHp;
  public int[] ct;

}
