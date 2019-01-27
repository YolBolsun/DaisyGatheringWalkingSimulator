using UnityEngine;
using System.Collections;

public class BaseDefenceEnemy : MonoBehaviour {

    public float movementSpeed;
    public float dps;
    public float range;
    public float health;

    Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if ((target.position - transform.position).magnitude > range)
        {
            transform.Translate((target.position - transform.position).normalized * Time.deltaTime * movementSpeed);
        }
        else
        {
            target.gameObject.GetComponent<HomeBaseManager>().TakeDamage(dps * Time.deltaTime);
        }
	}
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
