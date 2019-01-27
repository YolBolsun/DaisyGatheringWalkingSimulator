using UnityEngine;
using System.Collections;

public class HomeBaseGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (GUILayout.Button("Farm"))
        {
            Application.LoadLevel("MainMenu");
        }
        if (GUILayout.Button("Shop"))
        {
            Application.LoadLevel("MainMenu");
        }
        if (GUILayout.Button("CraftShop"))
        {
            Application.LoadLevel("MainMenu");
        }
        if (GUILayout.Button("Walls"))
        {
            Application.LoadLevel("MainMenu");
        }
        if (GUILayout.Button("Defend Your Base"))
        {
            Application.LoadLevel("RaidDefence");
        }
        if (GUILayout.Button("Scavenge For Supplies"))
        {
            Application.LoadLevel("ScavengeMode");
        }
        if (GUILayout.Button("Temporary Raid someone else"))
        {
            Application.LoadLevel("RaidOffense");
        }
        if (GUILayout.Button("Main Menu"))
        {
            Application.LoadLevel("MainMenu");
        }

    }
}
