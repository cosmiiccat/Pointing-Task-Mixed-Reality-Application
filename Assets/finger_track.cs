using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class finger_track : MonoBehaviour
{
    private Vector3 point1;
    private Vector3 point2;

    MixedRealityPose pose;
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphere3;
    public GameObject sphere4;
    public GameObject sphere5;
    public GameObject sphere6;
    public GameObject sphere7;
    public GameObject sphere8;
    public GameObject sphere9;
    public GameObject sphere10;
    public GameObject sphere11;
    public GameObject sphere12;
    public GameObject sphere13;
    public GameObject sphere14;
    public GameObject sphere15;
    public GameObject sphere16;
    public GameObject sphere17;
    public GameObject sphere18;
    public GameObject sphere19;
    public GameObject sphere20;
    public GameObject sphere_center;

    static void showred(GameObject sphere_center, GameObject sphere1, GameObject sphere2, GameObject sphere3, GameObject sphere4, GameObject sphere5, GameObject sphere6, GameObject sphere7, GameObject sphere8, GameObject sphere9, GameObject sphere10, GameObject sphere11, GameObject sphere12, GameObject sphere13, GameObject sphere14, GameObject sphere15, GameObject sphere16, GameObject sphere17, GameObject sphere18, GameObject sphere19, GameObject sphere20)
    {
        sphere1.gameObject.SetActive(false);
        sphere2.gameObject.SetActive(false);
        sphere3.gameObject.SetActive(false);
        sphere4.gameObject.SetActive(false);
        sphere5.gameObject.SetActive(false);
        sphere6.gameObject.SetActive(false);
        sphere7.gameObject.SetActive(false);
        sphere8.gameObject.SetActive(false);
        sphere9.gameObject.SetActive(false);
        sphere10.gameObject.SetActive(false);
        sphere11.gameObject.SetActive(false);
        sphere12.gameObject.SetActive(false);
        sphere13.gameObject.SetActive(false);
        sphere14.gameObject.SetActive(false);
        sphere15.gameObject.SetActive(false);
        sphere16.gameObject.SetActive(false);
        sphere17.gameObject.SetActive(false);
        sphere18.gameObject.SetActive(false);
        sphere19.gameObject.SetActive(false);
        sphere20.gameObject.SetActive(false);

        sphere_center.gameObject.SetActive(true);
        sphere_center.GetComponent<Renderer>().material.color = new Color(140, 0, 0);

        return;
    }

    static void showall(GameObject sphere_center, GameObject sphere1, GameObject sphere2, GameObject sphere3, GameObject sphere4, GameObject sphere5, GameObject sphere6, GameObject sphere7, GameObject sphere8, GameObject sphere9, GameObject sphere10, GameObject sphere11, GameObject sphere12, GameObject sphere13, GameObject sphere14, GameObject sphere15, GameObject sphere16, GameObject sphere17, GameObject sphere18, GameObject sphere19, GameObject sphere20)
    {
        sphere_center.gameObject.SetActive(false);
        //sphere_center.GetComponent<Renderer>().material.color = new Color(140, 0, 0);

        sphere1.gameObject.SetActive(true);
        sphere2.gameObject.SetActive(true);
        sphere3.gameObject.SetActive(true);
        sphere4.gameObject.SetActive(true);
        sphere5.gameObject.SetActive(true);
        sphere6.gameObject.SetActive(true);
        sphere7.gameObject.SetActive(true);
        sphere8.gameObject.SetActive(true);
        sphere9.gameObject.SetActive(true);
        sphere10.gameObject.SetActive(true);
        sphere11.gameObject.SetActive(true);
        sphere12.gameObject.SetActive(true);
        sphere13.gameObject.SetActive(true);
        sphere14.gameObject.SetActive(true);
        sphere15.gameObject.SetActive(true);
        sphere16.gameObject.SetActive(true);
        sphere17.gameObject.SetActive(true);
        sphere18.gameObject.SetActive(true);
        sphere19.gameObject.SetActive(true);
        sphere20.gameObject.SetActive(true);

        return;
    }

    static void check(GameObject Obj, Vector3 p1, GameObject sphere_center, GameObject sphere1, GameObject sphere2, GameObject sphere3, GameObject sphere4, GameObject sphere5, GameObject sphere6, GameObject sphere7, GameObject sphere8, GameObject sphere9, GameObject sphere10, GameObject sphere11, GameObject sphere12, GameObject sphere13, GameObject sphere14, GameObject sphere15, GameObject sphere16, GameObject sphere17, GameObject sphere18, GameObject sphere19, GameObject sphere20)
    {
        Vector3 p2;
        
        p2 = Obj.transform.position;

        //print("position" + p2);

        var a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
        var b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
        var c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

        var dist = Math.Sqrt(a + b + c);

        //print("Distance" + dist);

        if (dist < 0.1)
        {
            //var multiplier = (int)((0.1 - dist) * 100);
            Obj.GetComponent<Renderer>().material.color = new Color(140, 140, 0);
            finger_track.showred(sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        }

        if (dist > 0.1)
        {
            Obj.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        }

        return;
    }

    static void checkred(GameObject Obj, Vector3 p1, GameObject sphere_center, GameObject sphere1, GameObject sphere2, GameObject sphere3, GameObject sphere4, GameObject sphere5, GameObject sphere6, GameObject sphere7, GameObject sphere8, GameObject sphere9, GameObject sphere10, GameObject sphere11, GameObject sphere12, GameObject sphere13, GameObject sphere14, GameObject sphere15, GameObject sphere16, GameObject sphere17, GameObject sphere18, GameObject sphere19, GameObject sphere20)
    {
        Vector3 p2;

        p2 = Obj.transform.position;

        print("position" + p2);

        var a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
        var b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
        var c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

        var dist = Math.Sqrt(a + b + c);

        print("Distance" + dist);
        if (dist < 0.03)
        {
            //var multiplier = (int)((0.1 - dist) * 100);
            Obj.GetComponent<Renderer>().material.color = new Color(140, 140, 0);
            finger_track.showall(sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        }

        //if (dist > 0.1)
        //{
        //Obj.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        //}

        return;
    }

    // Start is called before the first frame update
    void Start()
    {

        finger_track.showred(sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        //GameObject.Find("Sphere_center").GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        //sphere_center.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        //sphere_center = GameObject.Find("Sphere_center");
        //sphere1 = GameObject.Find("Sphere1");
        //sphere2 = GameObject.Find("Sphere2");
        //sphere3 = GameObject.Find("Sphere3");
    }

    // Update is called once per frame
    void Update()
    {
        //if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexDistalJoint, Handedness.Right, out pose))
        //{
        //end = pose.Position;
        //}

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            //indexObject.GetComponent<Renderer>().enabled = true;
            point1 = pose.Position;
            //var dir = end - start;
            //var mid = -((dir) * 4.0f) + end;
            //var mid = start;
            //indexObject.transform.position = pose.Position;
            //indexObject.transform.position = new Vector3(pose.Position.x, pose.Position.y, pose.Position.z+0.1f);
            //indexObject.transform.position = mid;
            //indexObjectPosition = indexObject.transform.position;
            print("indexObjectPosition:" + point1);
            //Debug.Log("Index object position " + indexObject.transform.position);
            //Debug.Log(IP_Address);
        }

        finger_track.checkred(sphere_center, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);

        finger_track.check(sphere1, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere2, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere3, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere4, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere5, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere6, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere7, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere8, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere9, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere10, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere11, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere12, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere13, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere14, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere15, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere16, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere17, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere18, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere19, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);
        finger_track.check(sphere20, point1, sphere_center, sphere1, sphere2, sphere3, sphere4, sphere5, sphere6, sphere7, sphere8, sphere9, sphere10, sphere11, sphere12, sphere13, sphere14, sphere15, sphere16, sphere17, sphere18, sphere19, sphere20);

        //GameObject.Find("Sphere_center").GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        //sphere_center.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        //sphere1.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        //sphere2.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        //sphere3.GetComponent<Renderer>().material.color = new Color(0, 204, 102);


        /*if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            //indexObject.GetComponent<Renderer>().enabled = true;
            start = pose.Position;
            //var dir = end - start;
            //var mid = -((dir) * 4.0f) + end;
            var mid = start;
            //indexObject.transform.position = pose.Position;
            //indexObject.transform.position = new Vector3(pose.Position.x, pose.Position.y, pose.Position.z+0.1f);
            //indexObject.transform.position = mid;
            //indexObjectPosition = indexObject.transform.position;
            print("indexObjectPosition:" + mid);
            //Debug.Log("Index object position " + indexObject.transform.position);
            //Debug.Log(IP_Address);

        }*/
    }
}
