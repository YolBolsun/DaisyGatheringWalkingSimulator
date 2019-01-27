using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Weapon equippedWeapon;
    public int health = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.touches.Length > 0)
        {
            equippedWeapon.Shoot();
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            equippedWeapon.Shoot();
            //Debug.Log("Shooting");
        }
	}
    void OnTriggerEnter(Collider coll) {
    
        if(coll.tag == "Enemy")
        {
            TakeDamage(coll.gameObject.GetComponent<Enemy>().damage);
            GameObject.Destroy(coll.gameObject);
        }
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            //TODO play loss screen
        }
    }
}
