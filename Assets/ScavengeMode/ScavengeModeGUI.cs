using UnityEngine;
using System.Collections;

public class ScavengeModeGUI : MonoBehaviour {

    WebCamTexture cam = new WebCamTexture();
	// Use this for initialization
	void Start () {
        cam.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
        if (GUILayout.Button("Home Base"))
        {
            Application.LoadLevel("HomeBase");

        }
    }
}
