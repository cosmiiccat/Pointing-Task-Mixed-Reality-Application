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
using Random = UnityEngine.Random;

public class dynamictoggle : MonoBehaviour
{
    public GameObject[] ball;
    public GameObject cube;
    //private int[] selected;
    private List<int> selected;

    /*public GameObject ball1;
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
    public GameObject ball17;*/

    private Vector3 p1;
    private Vector3 p2;
    public bool sts;
    MixedRealityPose pose;
    private int rand_num;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<17; i++)
        {
            if (i == 0)
            {
                ball[i].gameObject.SetActive(true);
                ball[i].GetComponent<Renderer>().material.color = new Color(140, 0, 0);
            }
            else
            {
                ball[i].gameObject.SetActive(false);
                ball[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
            }
        }
        selected = new List<int>();

        rand_num = Random.Range(1, 16);

        /*ball1.gameObject.SetActive(true);
        ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);

        ball2.gameObject.SetActive(false);
        ball2.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball3.gameObject.SetActive(false);
        ball3.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball4.gameObject.SetActive(false);
        ball4.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball5.gameObject.SetActive(false);
        ball5.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball6.gameObject.SetActive(false);
        ball6.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball7.gameObject.SetActive(false);
        ball7.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball8.gameObject.SetActive(false);
        ball8.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball9.gameObject.SetActive(false);
        ball9.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball10.gameObject.SetActive(false);
        ball10.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball11.gameObject.SetActive(false);
        ball11.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball12.gameObject.SetActive(false);
        ball12.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball13.gameObject.SetActive(false);
        ball13.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball14.gameObject.SetActive(false);
        ball14.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball15.gameObject.SetActive(false);
        ball15.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball16.gameObject.SetActive(false);
        ball16.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

        ball17.gameObject.SetActive(false);
        ball17.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        sts = true;*/
        sts = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            p1 = pose.Position;
            //("indexObjectPosition:" + point1);
        }

        print("sts = " + sts);

        p2 = cube.transform.position;

        var acube = (p1[0] - p2[0]) * (p1[0] - p2[0]);
        var bcube = (p1[1] - p2[1]) * (p1[1] - p2[1]);
        var ccube = (p1[2] - p2[2]) * (p1[2] - p2[2]);

        var distcube = Math.Sqrt(acube + bcube + ccube);

        if(distcube < 0.05)
        {
            rand_num = Random.Range(1, 16);
            //selected = Array.Empty<int>();
            selected = new List<int>();
        }
        
        for (int i=0; i<17; i++)
        {
            if (i == 0)
            {
                p2 = ball[i].transform.position;

                var a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
                var b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
                var c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

                var dist = Math.Sqrt(a + b + c);

                if (dist < 0.03)
                {
                    for (int j=0; j<17; j++)
                    {
                        if(j == i)
                        {
                            ball[i].gameObject.SetActive(false);
                        }
                        else
                        {
                            ball[j].gameObject.SetActive(true);
                        }

                        ball[j].gameObject.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                    }

                    //Random rd = new Random();

                    //int rand_num = rd.Next(1, 16);
                    
                    ball[rand_num].GetComponent<Renderer>().material.color = Color.green;

                    /*//var multiplier = (int)((0.1 - dist) * 100);
                    ball[i].gameObject.SetActive(false);
                    //ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                    ball[1].gameObject.SetActive(true);
                    ball[2].gameObject.SetActive(true);
                    ball[3].gameObject.SetActive(true);
                    ball[4].gameObject.SetActive(true);
                    ball[5].gameObject.SetActive(true);
                    ball[6].gameObject.SetActive(true);
                    ball[7].gameObject.SetActive(true);
                    ball[8].gameObject.SetActive(true);
                    ball[9].gameObject.SetActive(true);
                    ball[10].gameObject.SetActive(true);
                    ball12.gameObject.SetActive(true);
                    ball13.gameObject.SetActive(true);
                    ball14.gameObject.SetActive(true);
                    ball15.gameObject.SetActive(true);
                    ball16.gameObject.SetActive(true);
                    ball17.gameObject.SetActive(true);
                    sts = false;
                    */
                }
            }
            else
            {
                if (selected.Capacity > 0)
                {
                    for (int k = 0; k < selected.Capacity; k++)
                    {
                        ball[selected[k]].GetComponent<Renderer>().material.color = new Color(0, 0, 60);
                        if(ball[selected[k]].gameObject.transform.localScale[0] < 0.05)
                        {
                            ball[selected[k]].gameObject.transform.localScale += new Vector3(0.0001f, 0.0001f, 0.0001f);
                        }
                    }

                    return;
                }

                p2 = ball[i].transform.position;

                var a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
                var b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
                var c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

                var dist = Math.Sqrt(a + b + c);

                if (dist < 0.03)
                {
                    ball[i].GetComponent<Renderer>().material.color = new Color(0, 0, 60);
                    for (int j = 0; j < 17; j++)
                    {
                        if (j == 0)
                        {
                            ball[j].gameObject.SetActive(true);
                        }
                        else
                        {
                            ball[j].gameObject.SetActive(false);
                        }
                    }

                    /*//var multiplier = (int)((0.1 - dist) * 100);
                    ball[i].gameObject.SetActive(false);
                    //ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                    ball[1].gameObject.SetActive(true);
                    ball[2].gameObject.SetActive(true);
                    ball[3].gameObject.SetActive(true);
                    ball[4].gameObject.SetActive(true);
                    ball[5].gameObject.SetActive(true);
                    ball[6].gameObject.SetActive(true);
                    ball[7].gameObject.SetActive(true);
                    ball[8].gameObject.SetActive(true);
                    ball[9].gameObject.SetActive(true);
                    ball[10].gameObject.SetActive(true);
                    ball12.gameObject.SetActive(true);
                    ball13.gameObject.SetActive(true);
                    ball14.gameObject.SetActive(true);
                    ball15.gameObject.SetActive(true);
                    ball16.gameObject.SetActive(true);
                    ball17.gameObject.SetActive(true);
                    sts = false;
                    */
                }

                if (dist < 0.09)
                {
                    ball[i].GetComponent<Renderer>().material.color = new Color(0, 0, 60);
                    selected.Add(i);
                    /*//var multiplier = (int)((0.1 - dist) * 100);
                    ball[i].gameObject.SetActive(false);
                    //ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                    ball[1].gameObject.SetActive(true);
                    ball[2].gameObject.SetActive(true);
                    ball[3].gameObject.SetActive(true);
                    ball[4].gameObject.SetActive(true);
                    ball[5].gameObject.SetActive(true);
                    ball[6].gameObject.SetActive(true);
                    ball[7].gameObject.SetActive(true);
                    ball[8].gameObject.SetActive(true);
                    ball[9].gameObject.SetActive(true);
                    ball[10].gameObject.SetActive(true);
                    ball12.gameObject.SetActive(true);
                    ball13.gameObject.SetActive(true);
                    ball14.gameObject.SetActive(true);
                    ball15.gameObject.SetActive(true);
                    ball16.gameObject.SetActive(true);
                    ball17.gameObject.SetActive(true);
                    sts = false;
                    */
                }
            }
        }

        /*
        if (true)
        {
            print("red");
            p2 = ball[0].transform.position;

            //print("position" + p2);

            var a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            var b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            var c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            var dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.03)
            {
                //var multiplier = (int)((0.1 - dist) * 100);
                ball[0].gameObject.SetActive(false);
                //ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball[1].gameObject.SetActive(true);
                ball[2].gameObject.SetActive(true);
                ball[3].gameObject.SetActive(true);
                ball[4].gameObject.SetActive(true);
                ball[5].gameObject.SetActive(true);
                ball[6].gameObject.SetActive(true);
                ball[7].gameObject.SetActive(true);
                ball[8].gameObject.SetActive(true);
                ball[9].gameObject.SetActive(true);
                ball[10].gameObject.SetActive(true);
                ball12.gameObject.SetActive(true);
                ball13.gameObject.SetActive(true);
                ball14.gameObject.SetActive(true);
                ball15.gameObject.SetActive(true);
                ball16.gameObject.SetActive(true);
                ball17.gameObject.SetActive(true);
                sts = false;
            }
        }

        sts = false;
        
        if (true)
        {
            print("white");
            //sphere2
            p2 = ball2.transform.position;

            //print("position" + p2);

            var a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            var b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            var c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            var dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball2.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere3
            p2 = ball3.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball3.GetComponent<Renderer>().material.color = new Color(0, 0, 60);
                
                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere4
            p2 = ball4.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball4.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere5
            p2 = ball5.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.16)
            {
                ball5.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere6
            p2 = ball6.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball6.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere7
            p2 = ball7.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.15)
            {
                ball7.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere8
            p2 = ball8.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball8.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere9
            p2 = ball9.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.15)
            {
                ball9.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere10
            p2 = ball10.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball10.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere11
            p2 = ball11.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.15)
            {
                ball11.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere12
            p2 = ball12.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball12.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere13
            p2 = ball13.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.15)
            {
                ball13.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere14
            p2 = ball14.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball14.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere15
            p2 = ball15.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.15)
            {
                ball15.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }

            //sphere16
            p2 = ball16.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.2)
            {
                ball16.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }
            //sphere17
            p2 = ball17.transform.position;

            //print("position" + p2);

            a = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            b = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            c = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(a + b + c);

            //print("Distance" + dist);

            if (dist < 0.15)
            {
                ball17.GetComponent<Renderer>().material.color = new Color(0, 0, 60);

                //var multiplier = (int)((0.1 - dist) * 100);
                ball1.gameObject.SetActive(true);
                ball1.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
                ball2.gameObject.SetActive(false);
                ball3.gameObject.SetActive(false);
                ball4.gameObject.SetActive(false);
                ball5.gameObject.SetActive(false);
                ball6.gameObject.SetActive(false);
                ball7.gameObject.SetActive(false);
                ball8.gameObject.SetActive(false);
                ball9.gameObject.SetActive(false);
                ball10.gameObject.SetActive(false);
                ball11.gameObject.SetActive(false);
                ball12.gameObject.SetActive(false);
                ball13.gameObject.SetActive(false);
                ball14.gameObject.SetActive(false);
                ball15.gameObject.SetActive(false);
                ball16.gameObject.SetActive(false);
                ball17.gameObject.SetActive(false);
                sts = true;
            }
        
        }*/

        

    }
}
