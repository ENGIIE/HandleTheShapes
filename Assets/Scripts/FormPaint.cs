using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormPaint : MonoBehaviour
{

    public Transform triangle;
    public Transform rectangle;
    public Transform circle;

    private Transform rndm;

    public KeyCode mouseLeft;
    private string toolType;

    static public bool freeSpace = true;

    List<GameObject> allForms = new List<GameObject>();
    List<Transform> formList = new List<Transform>();

    // Use this for initialization
    void Start()
    {

        formList.Add(triangle);
        formList.Add(rectangle);
        formList.Add(circle);
       
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        if (Input.GetKey(mouseLeft))
        {
         
            if(freeSpace == true)
            {

                rndm = formList[(int)Random.RandomRange(0, 3)];

                Vector3 scale = new Vector3(Random.Range(0.02f, 0.2f), Random.Range(0.02f, 0.2f));
                rndm.transform.localScale = scale;

                allForms.Add(Instantiate(rndm, objPosition, rndm.rotation).gameObject);

            }
            

        }

    }


    public void formsTransparent()
    {

        for (int n = 0; n < allForms.Count; n++)
        {
            Color tmp = allForms[n].GetComponent<SpriteRenderer>().color;
            tmp.a = 0.1f;
            allForms[n].GetComponent<SpriteRenderer>().color = tmp;
        }

    }


}
