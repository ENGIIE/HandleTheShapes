using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;

    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos)
    {

        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        // Check if the mouse has moved enough for us to insert new point 
        //If it has : Insert point at mouse position
        if(Vector2.Distance(points.Last(), mousePos) > 0.1f)
        {
            SetPoint(mousePos);
        }

    }

    void SetPoint (Vector2 point)
    {

        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

    }

    private void OnMouseOver()
    {
        Debug.Log("ewrwre");

        if (LineCreator.toolType == "eraser")
        {
            Debug.Log("12");
        }
    }

}
