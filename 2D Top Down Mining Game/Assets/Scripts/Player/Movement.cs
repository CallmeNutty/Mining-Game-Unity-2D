using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rb2d;
	
	// Update is called once per frame
	void Update ()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        ExtensionMethods.LookAt2D(transform, Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetKey(KeyCode.W))
        {
            rb2d.AddRelativeForce(new Vector2(0, 5), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(new Vector2(-2, 0), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(new Vector2(2, 0), ForceMode2D.Force);
        }
	}
}
