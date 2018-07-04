using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShapeCreator : MonoBehaviour {

    public Button rndmShape;
    public Sprite[] sprites;
    public List<string> wordlist = new List<string>(); 
    private List<GameObject> golist = new List<GameObject>();
    public Text theme;


    // Use this for initialization
    void Start () {

        wordlist.Add("Haus");
        wordlist.Add("Mann");
        wordlist.Add("Frau");
        wordlist.Add("Katze");
        wordlist.Add("Planze");
        wordlist.Add("Tier");
        wordlist.Add("Roboter");

        theme.text = "";

        Button btn = rndmShape.GetComponent<Button>();
        //Calls the TaskOnClick method when you click the Button
        btn.onClick.AddListener(createShape);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void createShape()
    {

        clear(golist);
        golist.Clear();

        for (int i = 0; i < Random.Range(3.0f, 10.0f); i++)
        {

            //Output this to console when the Button is clicked
            Debug.Log("You have clicked the button!");

            GameObject go = new GameObject("Primitive");

            // set the scaling
            Vector3 scale = new Vector3(Random.Range(0.1f, 0.5f), Random.Range(0.1f, 0.5f));
            go.transform.localScale = scale;

            SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
            renderer.sprite = sprites[Random.Range(0, 3)];

            //Rigidbody2D rb2d = go.AddComponent<Rigidbody2D>();
            //rb2d.bodyType = RigidbodyType2D.Static;

            PolygonCollider2D polcol2d = go.AddComponent<PolygonCollider2D>();

            // set the position
            Vector3 position = new Vector3(Random.Range(0.0f, 0.0f), Random.Range(-4.0f, 4.0f), 0);
            go.transform.position = position;
            Quaternion qTo = Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f));
            go.transform.rotation = qTo;




            if (golist.Count > 0)
            {
                while (collisionCheck(go, golist).Equals(false))
                {
                    // set the position
                    position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-4.0f, 4.0f), 0);
                    go.transform.position = position;
                    qTo = Quaternion.Euler(0, 0, Random.Range(-180.0f, 180.0f));
                    go.transform.rotation = qTo;

                }
            }
            Debug.Log("TEST: " + collisionCheck(go, golist));

            golist.Add(go);
        }

        for (int n = 0; n < golist.Count; n++)
        {
            Color tmp = golist[n].GetComponent<SpriteRenderer>().color;
            tmp.a = 0.1f;
            golist[n].GetComponent<SpriteRenderer>().color = tmp;
        }

        theme.text = wordlist[Random.Range(0, wordlist.Count)];

    }

    private bool collisionCheck(GameObject obj, List<GameObject> objlist)
    {
        Debug.Log("ENTER COLLISION CHECK");
        bool collision = false;

        PolygonCollider2D polycol = obj.GetComponent<PolygonCollider2D>();

        for (int i = 0; i < objlist.Count; i++)
        {
            if (polycol.bounds.Intersects(objlist[i].GetComponent<PolygonCollider2D>().bounds).Equals(true))
            {
                collision = true;
                Debug.Log("Collision: true");

            } else
            {
                Debug.Log("Collision: false");
            }
            
        }

        Debug.Log("RETURN: "+collision);
        return collision;
    }

    private void clear (List<GameObject> objlist)
    {
        for (int i = 0; i < objlist.Count; i++)
        {
            Destroy(objlist[i]);
        }

    }

}
