using UnityEngine;
using System.Collections;

public class HomeBaseManager : MonoBehaviour {

    public float health;
    public GUIStyle style;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //DO lose screen stuff TODO
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10,20, 100,20),Mathf.Ceil(health).ToString(),style);
    }

}
