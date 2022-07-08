using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private GameObject spawnPrefab;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.touchCount > 0) // If the screen has been tapped!
        {
            if(GameManager.instance.activePlayer == null)
            {
                if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon)) // Check if it touches a plane and populates a list of hitpoints
                {
                    Pose hitPose = hits[0].pose;
                    Instantiate(spawnPrefab, hitPose.position, Quaternion.identity); // Instantiate a robot
                }
            }

        }
    }
}
