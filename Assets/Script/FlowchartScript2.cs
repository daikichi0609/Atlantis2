using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowchartScript2 : MonoBehaviour
{

    public Fungus.Flowchart flowchart = null;
    public string message = "";

    public BattleParam BattleParam;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (BattleParam.Trigger)
            {
                BattleParam.Trigger = false;
                flowchart.SendFungusMessage(message);
            }
            
        }
    }
}
