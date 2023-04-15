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

public class resetbutton : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball5;
    public GameObject ball6;
    public GameObject ball7;
    public GameObject ball8;
    public GameObject ball9;
    public GameObject ball10;
    public GameObject ball11;
    public GameObject ball12;
    public GameObject ball13;
    public GameObject ball14;
    public GameObject ball15;
    public GameObject ball16;
    public GameObject ball17;
    public GameObject cube;

    private Vector3 p1;
    private Vector3 p2;
    MixedRealityPose pose;
    // Start is called before the first frame update
    void Start()
    {
        cube.GetComponent<Renderer>().material.color = new Color(102, 0, 102);
    }

    // Update is called once per frame
    void Update()
    {
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            p1 = pose.Position;
            //("indexObjectPosition:" + point1);
        }

        cube.GetComponent<Renderer>().material.color = new Color(102, 0, 102);

        p2 = cube.transform.position;

        //print("position" + p2);

        var a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
        var b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
        var c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

        var dist = Math.Sqrt(a + b + c);

        //print("Distance" + dist);

        if (dist < 0.05)
        {
            //var multiplier = (int)((0.1 - dist) * 100);
            ball1.gameObject.SetActive(true);
            //ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
            ball2.gameObject.SetActive(true);
            ball2.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball2.gameObject.SetActive(false);

            ball3.gameObject.SetActive(true);
            ball3.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball3.gameObject.SetActive(false);

            ball4.gameObject.SetActive(true);
            ball4.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball4.gameObject.SetActive(false);

            ball5.gameObject.SetActive(true);
            ball5.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball5.gameObject.SetActive(false);

            ball6.gameObject.SetActive(true);
            ball6.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball6.gameObject.SetActive(false);

            ball7.gameObject.SetActive(true);
            ball7.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball7.gameObject.SetActive(false);

            ball8.gameObject.SetActive(true);
            ball8.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball8.gameObject.SetActive(false);

            ball9.gameObject.SetActive(true);
            ball9.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball9.gameObject.SetActive(false);

            ball10.gameObject.SetActive(true);
            ball10.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball10.gameObject.SetActive(false);

            ball11.gameObject.SetActive(true);
            ball11.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball11.gameObject.SetActive(false);

            ball12.gameObject.SetActive(true);
            ball12.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball12.gameObject.SetActive(false);

            ball13.gameObject.SetActive(true);
            ball13.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball13.gameObject.SetActive(false);

            ball14.gameObject.SetActive(true);
            ball14.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball14.gameObject.SetActive(false);

            ball15.gameObject.SetActive(true);
            ball15.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball15.gameObject.SetActive(false);

            ball16.gameObject.SetActive(true);
            ball16.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball16.gameObject.SetActive(false);

            ball17.gameObject.SetActive(true);
            ball17.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            ball17.gameObject.SetActive(false);
        
        }
    }
}
