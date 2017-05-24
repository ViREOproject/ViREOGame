using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to save settings chosen by the player
//settings include: 
// - paintball color
// - size of enemies

public class Settings : MonoBehaviour {

    public PaintballColour colour;
    public Vector3 ghostScale;
    public Vector3 witchScale;

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);
        //set default colour
        setPaintballColour(PaintballColour.Black);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void setGhostScale(Vector3 ghost)
    {
        ghostScale = ghost;
       
    }

    public Vector3 getGhostScale()
    {
        return ghostScale;
    }

    public void setWitchScale(Vector3 witch)
    {
        witchScale = witch;
    }

    public Vector3 getWitchScale()
    {
        return witchScale;
    }

    public void setPaintballColour(PaintballColour c)
    {
        colour = c;
    }

    public PaintballColour getPaintballColour()
    {
        return colour;
    }

    //the number assigned to each colour corresponds to its position in the array (found in the paintball script)
    public enum PaintballColour
    {
        Black = 0,
        Purple = 1,
        Orange = 2,
        Pink = 3
    };
}
