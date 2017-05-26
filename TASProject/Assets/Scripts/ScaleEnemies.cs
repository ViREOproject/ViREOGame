using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEnemies: MonoBehaviour {

    public GameObject[] paintSplatters;
    public static int paintIndex = 0;
    public static GameObject paintSplatter;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //increase size button 
    public void btn1 ()
    {
        if (OptionsBtnPush.sc != null && OptionsBtnPush.sc.currentSetting.Equals("scale"))
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
        else if (OptionsBtnPush.sc != null && OptionsBtnPush.sc.currentSetting.Equals("paintColour"))
        {
            if (paintIndex < paintSplatters.Length-1)
            {
                //First click
                if (paintSplatter == null)
                {
                    paintIndex++;
                    paintSplatter = Instantiate(paintSplatters[paintIndex], new Vector3(47, 0, 14), Quaternion.Euler(new Vector3(90, 0, 0)));
                }
                else if(paintSplatter!=null)
                {
                    paintIndex++;
                    DestroyImmediate(paintSplatter);
                    paintSplatter = Instantiate(paintSplatters[paintIndex], new Vector3(47, 0, 14), Quaternion.Euler(new Vector3(90, 0, 0)));
                    
                }
            }
            else
            {
                //paintIndex++;
                DestroyImmediate(paintSplatter);
                paintIndex = 0;
                paintSplatter = Instantiate(paintSplatters[paintIndex], new Vector3(47, 0, 14), Quaternion.Euler(new Vector3(90, 0, 0)));

            }
            
        }
    }
    //decrease size button
    public void btn0()
    {
        if (OptionsBtnPush.sc != null && OptionsBtnPush.sc.currentSetting.Equals("scale"))
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
        else if(OptionsBtnPush.sc != null && OptionsBtnPush.sc.currentSetting.Equals("paintColour"))
        {

            if (paintIndex > 0)
            {
                //First click
                if (paintSplatter == null)
                {
                    paintIndex--;
                    paintSplatter = Instantiate(paintSplatters[paintIndex], new Vector3(47, 0, 14), Quaternion.Euler(new Vector3(90, 0, 0)));
                }
                else if (paintSplatter != null)
                {
                    paintIndex--;
                    DestroyImmediate(paintSplatter);
                    paintSplatter = Instantiate(paintSplatters[paintIndex], new Vector3(47, 0, 14), Quaternion.Euler(new Vector3(90, 0, 0)));

                }
            }
            else
            {
                
                DestroyImmediate(paintSplatter);
                paintIndex = paintSplatters.Length-1;
                paintSplatter = Instantiate(paintSplatters[paintIndex], new Vector3(47, 0, 14), Quaternion.Euler(new Vector3(90, 0, 0)));
            }
        }
        
    }
    //need this to save settings
    public int getPaintIndex(){return paintIndex;}
}
