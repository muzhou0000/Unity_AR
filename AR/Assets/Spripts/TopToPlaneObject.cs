using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//第一次用的時候會添加指定物件
[RequireComponent(typeof(ARRaycastManager))]
public class TopToPlaneObject : MonoBehaviour
{
    [Header("放置的物件")]
    public GameObject tapObject;


    private ARRaycastManager arRaycast;
    private List<ARRaycastHit> hits=new List<ARRaycastHit>();

    private Vector2 mousePos;
    private void Start()
    {
        arRaycast = GetComponent<ARRaycastManager>();
    }
    private void Update()
    {
        TapObject();
    }
    void TapObject()
    {
        //判斷是否點擊
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = Input.mousePosition;
        }
        if (arRaycast.Raycast(mousePos, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            GameObject temp = Instantiate(tapObject, pose.position, pose.rotation);
            Vector3 look = transform.position;
            look.y = temp.transform.position.y;
            temp.transform.LookAt(look);
        }
        //儲存點擊座標
        //AR射線碰撞
    }
}
