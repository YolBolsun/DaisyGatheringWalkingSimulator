using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int healthRemaining;
    public float movementSpeed;
    public int damage;

    public Animation walkAnimation;
    public Animation attackAnimation;
    public Animation deathAnimation;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    public void TakeDamage(int damage)
    {
        healthRemaining -= damage;
        if(healthRemaining <= 0)
        {
            healthRemaining = 0;
            //TODOdisable zombie movement
            //TODO play death animation
            //TODODestroy after death animation ends
            Destroy(this.gameObject);
        }
    }
    public void Move()
    {
        transform.LookAt(player.transform.position);
        transform.Translate((player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime,Space.World);
    }

    
}
