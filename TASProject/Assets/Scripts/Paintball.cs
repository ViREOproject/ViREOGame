﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour {

    public Transform PaintPrefab;
    public Material[] material;
    Renderer rend;

    private readonly string GHOST = "Ghost";
    private readonly string SPHERE = "Sphere";
    private readonly string CUBE = "Cube";
    private readonly string WITCH = "Witch";

 

    private float SplashRange = 4f;

    private float MinScale = 0.5f;
    private float MaxScale = 1.5f;

    // DEBUG
    private bool mDrawDebug;
    private Vector3 mHitPoint;
    private List<Ray> mRaysDebug = new List<Ray>();


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        
        
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        
        if (collision.gameObject.tag.Contains(GHOST) || collision.gameObject.tag.Contains(CUBE) ||
            collision.gameObject.tag.Contains(SPHERE))
        {
            rend = collision.gameObject.GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[0];
            Destroy(collision.gameObject, 3);
        }
        else if (collision.gameObject.tag.Contains(WITCH))
        {
            rend = collision.gameObject.GetComponentInChildren<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = material[0];
            Destroy(collision.gameObject, 3);
        }
        else
        {
            
            Paint(pos, collision.gameObject);
        }
        
        //Paint(pos + contact.normal * (SplashRange / 4f));
         Destroy(gameObject);
    }

    public void Paint(Vector3 location)
    {
        //DEBUG
        mHitPoint = location;
        mRaysDebug.Clear();
        mDrawDebug = true;

       
        RaycastHit hit;

       
    

            // Get a random direction (beween -n and n for each vector component)
            var fwd = transform.TransformDirection(Random.onUnitSphere * SplashRange);

            mRaysDebug.Add(new Ray(location, fwd));

            // Raycast around the position to splash everwhere we can
            if (Physics.Raycast(location, fwd, out hit, SplashRange))
            {
                // Create a splash if we found a surface
                var paintSplatter = GameObject.Instantiate(PaintPrefab,
                                                           hit.point,

                                                           // Rotation from the original sprite to the normal
                                                           // Prefab are currently oriented to z+ so we use the opposite
                                                           Quaternion.FromToRotation(Vector3.back, hit.normal)
                                                           ) as Transform;


                // Random scale
                var scaler = Random.Range(MinScale, MaxScale);

                paintSplatter.localScale = new Vector3(
                    paintSplatter.localScale.x * scaler,
                    paintSplatter.localScale.y * scaler,
                    paintSplatter.localScale.z
                );
                

                // TODO: What do we do here? We kill them after some sec?
                Destroy(paintSplatter.gameObject, 25);
            }

        
    }

    public void Paint(Vector3 location, GameObject colObj)
    {
        //DEBUG
        mHitPoint = location;
        mRaysDebug.Clear();
        mDrawDebug = true;

        RaycastHit hit;
    
        Vector3 fwd = transform.TransformDirection(Vector3.up);

        mRaysDebug.Add(new Ray(location, fwd));

            
        if (Physics.Raycast(location, fwd, out hit, SplashRange))
        {
            // Create a splash if we found a surface
            var paintSplatter = GameObject.Instantiate(PaintPrefab,hit.point,
                                                           // Rotation from the original sprite to the normal
                                                           // Prefab are currently oriented to z+ so we use the opposite
                                                           Quaternion.FromToRotation(Vector3.back, hit.normal)
                                                           ) as Transform;
            paintSplatter.transform.parent = colObj.transform;


            // Random scale
            var scaler = Random.Range(MinScale, MaxScale);

            paintSplatter.localScale = new Vector3(
                    paintSplatter.localScale.x * scaler,
                    paintSplatter.localScale.y * scaler,
                    paintSplatter.localScale.z
            );

                


            // TODO: What do we do here? We kill them after some sec?
            Destroy(paintSplatter.gameObject, 25);
        }

    }
}
