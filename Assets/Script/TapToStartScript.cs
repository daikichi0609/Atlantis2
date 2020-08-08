using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToStartScript : MonoBehaviour {

    public AudioSource AudioSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            AudioSource.Play();
            StartCoroutine(Checking(() =>
            {
                SceneManager.LoadScene("Start");
            }));
        }
	}

    public delegate void functionType();
    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!AudioSource.isPlaying)
            {
                callback();
                break;
            }
        }
    }
}
