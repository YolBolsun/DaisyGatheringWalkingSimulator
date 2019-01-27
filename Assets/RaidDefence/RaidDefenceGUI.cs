using UnityEngine;
using System.Collections;

public class RaidDefenceGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
