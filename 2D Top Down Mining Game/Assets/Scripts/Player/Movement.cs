using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Declare Variables
    [SerializeField]
    private Rigidbody2D rb2d;
	
	// Update is called once per frame
	void Update ()
    {
        //Camera follows player(without rotating)
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        //LookAt Mouse
        ExtensionMethods.LookAt2D(transform, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        //Movement conditionals
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddRelativeForce(new Vector2(0, 5), ForceMode2D.Force);//Upwards Movement
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(new Vector2(-2, 0), ForceMode2D.Force);//Left Movement
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(new Vector2(2, 0), ForceMode2D.Force);//Right Movement
        }
	}
}
