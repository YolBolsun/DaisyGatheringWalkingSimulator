using UnityEngine;
using System.Collections;

public class RaidOffenseGUI : MonoBehaviour {

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
