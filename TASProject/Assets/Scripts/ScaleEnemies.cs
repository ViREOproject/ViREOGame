using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEnemies: MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //increase size button 
    public void btn1 ()
    {
        if (GameObject.FindGameObjectWithTag("Ghost").transform.localScale.y < 94)
        {
            GameObject.FindGameObjectWithTag("Ghost").transform.localScale += new Vector3(10, 10, 10);
           
        }

        if (GameObject.FindGameObjectWithTag("Witch").transform.localScale.y < 0.5)
        {
            GameObject.FindGameObjectWithTag("Witch").transform.localScale += new Vector3(.05f, .05f, .05f);
        }
    }
    //decrease size button
    public void btn0()
    {
        if (GameObject.FindGameObjectWithTag("Ghost").transform.localScale.y > 35)
        {
            GameObject.FindGameObjectWithTag("Ghost").transform.localScale -= new Vector3(10, 10, 10);
        }

        if (GameObject.FindGameObjectWithTag("Witch").transform.localScale.y > 0.24)
        { 
            GameObject.FindGameObjectWithTag("Witch").transform.localScale -= new Vector3(.05f, .05f, .05f);
        }
    }
}
