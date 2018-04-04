using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject firingPoint;
    [SerializeField]
    private GameObject emptyBulletHolder;

    public int damagePerShot;
    [SerializeField]
    private float firingSpeed;
    private float timer;
	
	// Update is called once per frame
	void Update ()
    {      
        if (Input.GetKey(KeyCode.Space))
        {
            //Begin Firing
            timer += Time.deltaTime;

            if (timer > 1 / firingSpeed)
            {
                Fire(10, bullet, firingPoint, emptyBulletHolder); //Fire Bullet
                timer = 0; // reset timer for fire rate
            }
        }
    }

    //Method responsible for spawning bullets and managing them
    void Fire(float bulletSpeed, GameObject bullet, GameObject firingPoint, GameObject emptyBulletHolder)
    {
        //Variable which holds the instantiated bullet
        GameObject spawnedBullet;

        //Instantiate bullet and assign it to spawned bullet as a GameObject
        spawnedBullet = Instantiate(bullet, firingPoint.transform.position, gameObject.transform.rotation, emptyBulletHolder.transform) as GameObject;
        
        spawnedBullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, bulletSpeed), ForceMode2D.Impulse); //Add a relative force to the bullet
    }
}
