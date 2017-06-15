using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private static int waypointCount = 7;
    // put the points from unity interface
    public GameObject[] wayPointList = new GameObject[waypointCount];

    public int currentWayPoint = 0;
    GameObject targetWayPoint;

    public float speed = 0.1f;
    public int ranX;
    public int ranY;
    public int ranZ;

    AudioSource audio;
    public AudioClip impact;
    public AudioClip boo;
  
    float distance;
    bool played = false;

    private int scoreValue = 5;
    private bool hit;

    // Use this for initialization
    void Start ()
    {
        if (SceneManager.GetActiveScene().name.Equals("DevScene"))
        {
            audio = this.GetComponent<AudioSource>();
            //Generating random x y z for the ghost
            int ranX = Random.Range(0, 10);
            int ranY = Random.Range(0, 5);
            int ranZ = Random.Range(0, 10);

            for (int i = 0; i < waypointCount; i++)
            {
                wayPointList[i] = GameObject.FindWithTag("WP" + i);
            }
            //Debug.Log(wayPointList.Length);

            hit = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name.Equals("DevScene"))
        {
            //Debug.Log(currentWayPoint);
            // check if we have somewere to walk
            if (currentWayPoint < this.wayPointList.Length)
            {
                if (targetWayPoint == null)
                    targetWayPoint = wayPointList[currentWayPoint];
                walk();
            }

            distance = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

            if (distance < 6 && !played)
            {
                played = true;
                audio.PlayOneShot(boo);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Paintball>())
        {
            audio.PlayOneShot(impact);

            //Check to make sure that it hasn't alreay been hit
            if (!hit)
            {
                //Preventing multiple hits
                hit = true;
                Score_Manager.score += scoreValue;
            }
            
        }
    }

    void walk()
    {

        // rotate towards the target
        Vector3 target = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);

        transform.forward = Vector3.RotateTowards(transform.forward, target + new Vector3(ranX, ranY, ranZ), speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.transform.position + new Vector3(ranX, ranY, ranZ), speed * Time.deltaTime);

        
        if (transform.position == targetWayPoint.transform.position + new Vector3(ranX, ranY, ranZ))
        {
            //Generating a new set of random x y z coords for the ghost
            ranX = Random.Range(0, 10);
            ranY = Random.Range(0, 5);
            ranZ = Random.Range(0, 10);

            if (currentWayPoint != wayPointList.Length-1)
            {
                currentWayPoint++;
                targetWayPoint = wayPointList[currentWayPoint];
            }
            else
            {
                currentWayPoint = 0;
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
    }
}
