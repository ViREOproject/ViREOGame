using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintballController : MonoBehaviour {

   
    public AudioSource audio;
    private float nextFire;
    public float fireRate;
    public bool canShoot = true;
    public GameObject paintballOrigin;
    public Rigidbody paintball;
    public float paintballForce;

    public GameObject controllerRight;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    private SteamVR_TrackedController controller;
    int index;


    // Use this for initialization
    void Start () {

        controller = controllerRight.GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += TriggerPressed;
        trackedObj = controllerRight.GetComponent<SteamVR_TrackedObject>();
        audio = this.GetComponent<AudioSource>();
    
        

        
    }

    private void TriggerPressed(object sender, ClickedEventArgs e)
    {
        ShootPaintball();
        SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(2500);
    }

    // Update is called once per frame
    void Update () {

		
	}

    void ShootPaintball()
    {
        Rigidbody clone = Instantiate(paintball, paintballOrigin.transform.position, paintballOrigin.transform.rotation);
        clone.velocity = transform.forward * paintballForce;

        audio.Play();
    }

}
