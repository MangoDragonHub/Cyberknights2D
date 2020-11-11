using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// This controls the dymanic zoom and motion of the camera and establish camera boundaries for both players.
    /// Made by Rashad Patterson 10/14/20
    /// 
    /// </summary>


    //The Header Tooltips are used for Organization Purposes...
    [Header("General")]

    [SerializeField] Camera gameCam;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [Header("Camera Boundaries")]
    public float camBoundariesMin = 3;
    public float camBoundariesMax = 10;

    [Header("Camera Zoom Settings")]
    public float camInitalZoom = 3;
    public float camMaxZoom = 5;
    public float camSmoothing = 10;
    [SerializeField] bool zooming = false;



    // Update is called once per frame
    void Update()
    {
        CameraZoomingFunction();  
    }

    void CameraZoomingFunction() 
    {
        if (player1.transform.position.x < -camBoundariesMin)
        {

            if (!zooming)
            {
                zooming = true;
                //Changes the Othographic Size smoothly from the its inital view to the wide view smoothly.
                //Have the two main values in the Lerp (A, B) and the (T) value to is how much the value will blend in either (A) or (B). 
                gameCam.orthographicSize = Mathf.Lerp(gameCam.fieldOfView, camMaxZoom, Time.deltaTime * camSmoothing);
                
            }
            else
            {
                //Zoom in back to original lens
                zooming = false;
                gameCam.orthographicSize = Mathf.Lerp(gameCam.fieldOfView, camInitalZoom, Time.deltaTime * camSmoothing);
            }

        }
    }
}
