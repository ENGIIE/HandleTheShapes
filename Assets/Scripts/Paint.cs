using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paint : MonoBehaviour
{

    public Transform baseDot;
    public Transform line;
    public KeyCode mouseLeft;
    private string toolType;
    public Button clear;
    List<GameObject> allDots = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

        Button btnclear = clear.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btnclear.onClick.AddListener(clearCanvas);

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (Input.GetKey(mouseLeft))
        {
            allDots.Add(Instantiate(baseDot, objPosition, baseDot.rotation).gameObject);
            //Instantiate(line, objPosition, line.rotation);
        }

    }


    private void clearCanvas()
    {

        Debug.Log("You have clicked the button!");

        for (int i = 0; i < allDots.Count; i++)
        {
            Destroy(allDots[i]);
        }
        allDots.Clear();

    }

    public void eraserTool()
    {

        this.toolType = "eraser";
        Debug.Log("Eraser");

    }
}
