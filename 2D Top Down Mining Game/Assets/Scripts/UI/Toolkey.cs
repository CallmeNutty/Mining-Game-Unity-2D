using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolkey : MonoBehaviour
{
    [SerializeField]
    private Image panel;
    [SerializeField]
    private Text info;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        panel.rectTransform.position = new Vector3 (Input.mousePosition.x + 60, Input.mousePosition.y - 50);
	}

    public void ShowToolKey()
    {
        info.text = gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;
        panel.gameObject.SetActive(true);
    }

    public void HideToolKey()
    {
        panel.gameObject.SetActive(false);
    }
}
