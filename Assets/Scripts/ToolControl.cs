using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolControl : MonoBehaviour {

	public void activateFormPaint ()
    {
        GetComponent<FormPaint>().enabled = true;

    }

    public void deactivateFormPaint()
    {
        GetComponent<FormPaint>().enabled = false;

    }

    public void activateLineCreator()
    {
        GetComponent<LineCreator>().enabled = true;

    }

    public void deactivateLineCreator()
    {
        GetComponent<LineCreator>().enabled = true;

    }

}
