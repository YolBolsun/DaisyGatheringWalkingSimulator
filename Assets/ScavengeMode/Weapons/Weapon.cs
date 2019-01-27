using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    //public attributes
    public float attackSpeed;
    public float magazineSize;
    public int baseDamage;
    public float reloadSpeed;
    public float projectileSpeed;
    public int bulletsRemaining;

    public int burstNumber=1;
    public bool raycastWeapon;
    //not all guns will spawn projectiles most likely
    //some will just use raycasting
    public GameObject projectile;
    public Sprite reticle;

    public Animation reloadAnimation;
    public Animation shootAnimation;

    //private attributes
    float timeOfLastShot = 0;
    float timeBetweenShots;
    float shootDistance;
    GameObject player;

	// Use this for initialization
	void Start () {
        timeBetweenShots = 1 / attackSpeed;
        shootDistance = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemySpawn>().spawnRadius;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Shoot()
    {
       /* Debug.Log("Bullets remaining: " + bulletsRemaining);
        Debug.Log("Time: " + Time.realtimeSinceStartup);
        Debug.Log("Last Shot" + timeOfLastShot);
        Debug.Log("Time between shots"+ timeBetweenShots);*/
        if(bulletsRemaining > 0 && Time.realtimeSinceStartup > timeOfLastShot + timeBetweenShots)
        {

            if(raycastWeapon)
            {
                Debug.Log("Raycast Weapon");
                //do raycast stuff//TODO
                RaycastHit hitInfo;
                Physics.Raycast(player.transform.position, player.transform.forward, out hitInfo, shootDistance);
                Debug.Log(player.transform.position + " : " + player.transform.forward);
                if (hitInfo.collider != null && hitInfo.collider.gameObject.CompareTag("Enemy"))//TODO add enemy head hit box, enemy body hit box     
                {
                    hitInfo.collider.gameObject.GetComponent<Enemy>().TakeDamage(baseDamage);
                }
            }
            else
            {
                //spawn projectile//TODO
            }

            bulletsRemaining-=burstNumber;
            timeOfLastShot = Time.realtimeSinceStartup;
        }
    }
}
