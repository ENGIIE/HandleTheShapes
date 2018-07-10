using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

       gameObject.AddComponent<PolygonCollider2D>();
       gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;

    }

    // Update is called once per frame
    void Update () {

        

	}

    private void OnMouseOver()
    {

        Debug.Log("Mouse over Form");
        FormPaint.freeSpace = false;

    }

}
