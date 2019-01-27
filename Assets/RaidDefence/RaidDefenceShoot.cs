using UnityEngine;
using System.Collections;

public class RaidDefenceShoot : MonoBehaviour {

    public RaidDefenceWeapon weapon;

    float nextShot = 0;

    int layerMask = 1 << 8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touches.Length != 0)
        {
            //Need to get this raycast to recognize the contact meaning it needs a 3d object with the sprite on it

            Touch touch = Input.touches[0];
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            //Vector2 direction2D = new Vector2(ray.direction)
            if (Physics.Raycast(ray,out hit, Mathf.Infinity,layerMask))
            {
                Debug.Log("Hit");

                BaseDefenceEnemy enemy = hit.collider.gameObject.GetComponent<BaseDefenceEnemy>();
                enemy.TakeDamage(weapon.damage);
            }
        }
	}
}
