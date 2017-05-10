using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour {

    private static int waypointCount = 7;
    // put the points from unity interface
    public GameObject[] wayPointList = new GameObject[waypointCount];

    public int currentWayPoint = 0;
    GameObject targetWayPoint;

    public float speed = 5f;
    public int ranX;
    public int ranY;
    public int ranZ;

    public AudioClip impact;
    AudioSource audio;


    // Use this for initialization
    void Start()
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
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentWayPoint);
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = getClosestWaypoint(wayPointList);
            walk();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Paintball>())
        {
            audio = this.GetComponent<AudioSource>();
            audio.PlayOneShot(impact);
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

        transform.forward = Vector3.RotateTowards(transform.forward, target + new Vector3(ranX, ranY, ranZ), speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.transform.position + new Vector3(ranX, ranY, ranZ), speed * Time.deltaTime);

       
        //Debug.Log("Waypoint " + targetWayPoint.transform.position);
        if (transform.position == targetWayPoint.transform.position + new Vector3(ranX, ranY, ranZ))
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
                currentWayPoint = Random.Range(0,wayPointList.Length-1);
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
