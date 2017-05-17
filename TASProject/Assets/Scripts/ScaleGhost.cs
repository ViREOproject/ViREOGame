using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleGhost : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void btn0 ()
    {
        if (GameObject.FindGameObjectWithTag("Ghost").transform.localScale.y < 94)
        {
            GameObject.FindGameObjectWithTag("Ghost").transform.localScale += new Vector3(10, 10, 10);
        }
    }

    public void btn1()
    {
        if (GameObject.FindGameObjectWithTag("Ghost").transform.localScale.y > 35)
        {
            GameObject.FindGameObjectWithTag("Ghost").transform.localScale -= new Vector3(10, 10, 10);
        }
    }
}
