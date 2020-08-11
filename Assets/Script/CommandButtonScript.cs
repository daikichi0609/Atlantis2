using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandButtonScript : MonoBehaviour {

    public int CommandNum;
	private Button Button;

	// Use this for initialization
	void Start () {
		var colors = Button.GetComponentInChildren<Button>().colors;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
