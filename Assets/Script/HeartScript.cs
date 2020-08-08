using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartScript : MonoBehaviour {

    public MeshRenderer Mesh;
    public  ParticleSystem particle;

    string name;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update () {

        name = SceneManager.GetActiveScene().name;

        if (name == "Main")
        {
            Mesh.enabled = true;
            particle.Play();
        }
        else
        {
            Mesh.enabled = false;
            particle.Stop();
        }
    }
}
