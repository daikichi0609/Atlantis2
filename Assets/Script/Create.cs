using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Create : MonoBehaviour
{
    public CommandButtonScript CommandButton;
    public RectTransform contentRectTransform;
    public Button button;
    public string[] skillname;
    private void Start()
    {
        for(int i = 0; i <= 29; i++){
            CommandButton.CommandNum = i;
            var obj = Instantiate(button,contentRectTransform);
            obj.GetComponentInChildren<Text>().text = skillname[i];
        }
    }
}