using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour {

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject firingPoint;
    [SerializeField]
    private GameObject emptyBulletHolder;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Fire(4, bullet, firingPoint, emptyBulletHolder);
        }
    }

    void Fire(float bulletSpeed, GameObject bullet, GameObject firingPoint, GameObject emptyBulletHolder)
    {
        GameObject spawnedBullet;
        spawnedBullet = Instantiate(bullet, firingPoint.transform.position, gameObject.transform.rotation, emptyBulletHolder.transform) as GameObject;
        spawnedBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
    }
}
