using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineCreator : MonoBehaviour {

    public GameObject linePrefab;
    Line activeLine;

    List<GameObject> allLines = new List<GameObject>();
    public Button clear;

    public static string toolType;

    // Use this for initialization
    void Start () {

        Button btnclear = clear.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btnclear.onClick.AddListener(clearCanvas);

    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetMouseButtonDown(0))
        {

            GameObject lineGO = Instantiate(linePrefab);

            activeLine = lineGO.GetComponent<Line>();

            allLines.Add(lineGO);
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if(activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }


    }

    private void clearCanvas()
    {

        Debug.Log("You have clicked the button!");

        for (int i = 0; i < allLines.Count; i++)
        {
            Destroy(allLines[i]);
        }
        allLines.Clear();

    }

    public void eraserTool()
    {

        toolType = "eraser";
        Debug.Log(toolType);

    }


    public void addCollider ()
    {
        for (int i = 0; i < allLines.Count; i++)
        {
            allLines[i].AddComponent<PolygonCollider2D>();
        }
    }

}
