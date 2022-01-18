using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class pickup : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public float pickupDistance = 5f;
    AudioSource pickupAS;
    public AudioClip pickupAC;
    Camera mainCam;
    public GameObject robbutton;
    public LayerMask layer;
    public GameObject wayarrow;
    private void Start()
    {
        pickupAS = GetComponent<AudioSource>();
        mainCam = Camera.main;
    }

    private void Update() 
    {
        ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit, pickupDistance, layer))
        {
            //pickupText.enabled = true;
            robbutton.SetActive(true);
            if (hit.transform.tag == "Statue")
            {
                Pickup();
            }
        }
        else
        {
            // pickupText.enabled = false;
            robbutton.SetActive(false);
        }
    }

    void Pickup()
    {
        if (CrossPlatformInputManager.GetButton("Rob")) 
        {
            Destroy(hit.transform.gameObject);
            pickupAS.PlayOneShot(pickupAC);
            //pickupText.enabled = false;
            robbutton.SetActive(false);
            wayarrow.SetActive(false);
           // MissionWaypoint MissionWaypointScript = this.transform.GetComponent<MissionWaypoint>();
        }
    }


}
