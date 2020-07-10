using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleInput : MonoBehaviour
{

    private Vector3 targetPosition = new Vector3(46.78f, 4.24f, 1.1f);

    // Movement speed in units per second.
    public float speed = 0.6F;

    public AudioClip office;
    public AudioClip typing;
    public GameObject screen;
    public GameObject phoneCase;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private GameObject CameraObject;
    private GameObject SecondaryCamera;

    private Vector3 initPosCamObj;
    private Vector3 initPosSecond;
    private Vector3 initRotSecond;
    private void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;
        CameraObject = GameObject.Find("MoveMe").gameObject;
        initPosCamObj = CameraObject.transform.position;
        SecondaryCamera = GameObject.Find("SecondaryCamera").gameObject;
        initRotSecond = SecondaryCamera.transform.eulerAngles;
        initPosSecond = SecondaryCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.F))
        {
            Vector3 startPosition = SecondaryCamera.transform.position;
            // Calculate the journey length.
            journeyLength = Vector3.Distance(startPosition, targetPosition);
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            SecondaryCamera.transform.position = Vector3.Lerp(startPosition,
                                                                                 targetPosition, 
                                                                                 fractionOfJourney);
            CameraObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else if (Input.GetKey(KeyCode.G))
        {
            GetComponent<AudioSource>().clip = office;
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            CameraObject.transform.eulerAngles = new Vector3(0, 0, 0);
            CameraObject.transform.position = initPosCamObj;
            SecondaryCamera.transform.position = initPosSecond;
            SecondaryCamera.transform.eulerAngles = initRotSecond;
        }

        else if (Input.GetKey(KeyCode.H))
        {
            GetComponent<AudioSource>().clip = typing;
            GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            CameraObject.transform.position += new Vector3(0, 0, 0.1f);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            CameraObject.transform.position += new Vector3(0, 0, 0.1f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CameraObject.transform.position -= new Vector3(0, 0, 0.1f);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            CameraObject.transform.position -= new Vector3(0.1f, 0,0 );

        }
        else if (Input.GetKey(KeyCode.D))
        {
            CameraObject.transform.position += new Vector3(0.1f, 0, 0);

        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
        
            screen.SetActive(!screen.activeSelf);
            phoneCase.SetActive(!phoneCase.activeSelf);
                
        }
    }
}
