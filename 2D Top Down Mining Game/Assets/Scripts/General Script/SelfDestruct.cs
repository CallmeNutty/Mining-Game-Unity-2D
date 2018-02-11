using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private float selfDestructTime;

    //Co-Routine which destroys the object after specified time
    private IEnumerator ISelfDestruct(float selfDestructTimer)
    {
        yield return new WaitForSeconds(selfDestructTimer);
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start ()
    {
        //Begin self-destruction timer
        StartCoroutine(ISelfDestruct(selfDestructTime));
	}
}
