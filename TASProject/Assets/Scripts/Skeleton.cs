using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skeleton : MonoBehaviour {
    private static int waypointCount = 7;
    // put the points from unity interface
    public GameObject[] wayPointList = new GameObject[waypointCount];

    public int currentWayPoint = 0;
    GameObject targetWayPoint;

    public float speed = 0.5f;
    public int ranX;
    public int ranY;
    public int ranZ;

    public AudioClip impact;
    AudioSource audio;

    private int scoreValue = 10;
    private bool hit;


    // Use this for initialization
    void Start()
    {

        if (SceneManager.GetActiveScene().name.Equals("DevScene"))
        {
            //Generating random x y z for the witch
            int ranX = Random.Range(0, 5);
            int ranY = Random.Range(0, 10);
            int ranZ = Random.Range(0, 5);

            for (int i = 0; i < waypointCount; i++)
            {
                wayPointList[i] = GameObject.FindWithTag("WP" + i);
            }
            //Debug.Log(wayPointList.Length);

            hit = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("DevScene"))
        {
            //Debug.Log(currentWayPoint);
            // check if we have somewere to walk
            if (currentWayPoint < this.wayPointList.Length)
            {
                if (targetWayPoint == null)
                    targetWayPoint = wayPointList[currentWayPoint];
                //targetWayPoint = getClosestWaypoint(wayPointList);
                walk();
                //Debug.Log(targetWayPoint);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Paintball>())
        {
            audio = this.GetComponent<AudioSource>();
            audio.PlayOneShot(impact);

            //Check to make sure that it hasn't alreay been hit
            if (!hit)
            {
                Score_Manager.score += scoreValue;
            }
            //Preventing multiple hits
            hit = true;
        }
    }

    void walk()
    {
        //Debug.Log("x: "+ranX);
        //Debug.Log("y: "+ranY);
        //Debug.Log("z: "+ranZ);
        // rotate towards the target
        //Debug.Log(targetWayPoint.transform.position);
        Vector3 target = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);

        transform.forward = Vector3.RotateTowards(transform.forward, target + new Vector3(ranX, 0, ranZ), speed * Time.deltaTime, 0.0f);
        
        /*
        * move towards the target
        * 
        * The skeleton is unable to jump high enought to reach the waypoint.
        * Solution to this problem is to subtract the waypoint's y coord from itself.
        * Like this
        * (targetWayPoint.transform.position - new Vector3(0,targetWayPoint.transform.position.y))
        */

        transform.position = Vector3.MoveTowards(transform.position, (targetWayPoint.transform.position - new Vector3(0,targetWayPoint.transform.position.y)) + new Vector3(ranX, 0, ranZ), speed * Time.deltaTime);


        //Debug.Log("Witch"+targetWayPoint.transform.position);
        //Debug.Log("Waypoint " + targetWayPoint.transform.position);


        //Because of the issue with the skeleton not being able to jump we have to update the y coord here as well
        if (transform.position == (targetWayPoint.transform.position - new Vector3(0, 1.5f, 0)) + new Vector3(ranX, 0, ranZ))
        {
            //Generating a new set of random x y z coords for the witch
            ranX = Random.Range(0, 5);
            ranY = Random.Range(0, 10);
            ranZ = Random.Range(0, 5);
            if (currentWayPoint != wayPointList.Length - 1)
            {
                currentWayPoint++;
                targetWayPoint = wayPointList[currentWayPoint];
            }
            else
            {
                currentWayPoint = Random.Range(0, wayPointList.Length - 1);
                targetWayPoint = wayPointList[currentWayPoint];

            }
        }
    }

    GameObject getClosestWaypoint(GameObject[] waypoints)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in waypoints)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
