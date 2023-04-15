using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public static class ExportData
{
    public static void ExportCsv<Vector3>(List<Vector3> genericList, string fileName)
    {
        var sb = new StringBuilder();
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        basePath = "C:\\Users\\DELL\\Desktop\\Pointing_Task_MR\\data";
        var finalPath = Path.Combine(basePath, fileName + ".csv");
        //Console.WriteLine(finalPath +  "  " + basePath);
        var header = "";
        var info = typeof(Vector3).GetProperties();
        if (!File.Exists(finalPath))
        {
            var file = File.Create(finalPath);
            file.Close();
            foreach (var prop in typeof(Vector3).GetProperties())
            {
                header += prop.Name + "; ";
            }
            header = header.Substring(0, header.Length - 2);
            sb.AppendLine(header);
            TextWriter sw = new StreamWriter(finalPath, true);
            sw.Write(sb.ToString());
            sw.Close();
        }
        foreach (var obj in genericList)
        {
            sb = new StringBuilder();
            var line = "";
            foreach (var prop in info)
            {
                line += prop.GetValue(obj, null) + "; ";
            }
            line = line.Substring(0, line.Length - 2);
            sb.AppendLine(line);
            TextWriter sw = new StreamWriter(finalPath, true);
            sw.Write(sb.ToString());
            sw.Close();
        }
    }
}

public static class makeCSV
{
    public static void createCSV(List<Vector3> curList, string fileName)
    {
        var sb = new StringBuilder();
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        basePath = "C:\\Users\\DELL\\Desktop\\Pointing_Task_MR\\data";
        var finalPath = Path.Combine(basePath, fileName + ".csv");

        for (int k=0; k<curList.Count; k++)
        {
            sb = new StringBuilder();
            var line = "";
            line = curList[k].ToString("F6");
            sb.AppendLine(line);
            TextWriter sw = new StreamWriter(finalPath, true);
            sw.Write(sb.ToString());
            sw.Close();
        }
    }
}

public class experiment : MonoBehaviour
{
    public GameObject[] sphere;
    public GameObject centerSphere;
    private int randNum;
    //private List<Vector3> path;

    private Vector3 p1;
    private Vector3 p2;
    MixedRealityPose pose;

    public GameObject clone;// this is an empty object. Only one linerenderer component is added 
    private LineRenderer Line;
    Vector3[] path;
    List<Vector3> POS = new List<Vector3>();
    private Vector3 Hand_POS;

    int trajnum = 1;

    void Awake()
    {
        path = POS.ToArray();// initialize 
        Line = clone.GetComponent<LineRenderer>();// get the linerender component 
        //Line.material = new Material(Shader.Find("particles/additive"));
        Line.SetColors(Color.blue, Color.red);// set the color 
        Line.SetWidth(0.01f, 0.01f);// set the width 
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<sphere.Length;  i++)
        {
            sphere[i].SetActive(false);
            sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        }

        centerSphere.SetActive(true);
        centerSphere.GetComponent<Renderer>().material.color = new Color(140, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            p1 = pose.Position;
            //("indexObjectPosition:" + point1);
        }

        if(centerSphere.activeSelf)
        {
            if(POS.Capacity > 0)
            {
                string filename = "traj" + trajnum.ToString();
                makeCSV.createCSV(POS, filename);
                POS = new List<Vector3>();
                trajnum += 1;
            }

            POS = new List<Vector3>();
        }
        else
        {
            POS.Add(p1);// add the current coordinate into the linked list 
            path = POS.ToArray();// convert to array 
            Line.SetVertexCount(path.Length); //when there is data;// set the vertex number 
            Line.SetPositions(path);// set the vertex position
        }

        var x = 0.0;
        var y = 0.0;
        var z = 0.0;
        var dist = 0.0;

        if(centerSphere.activeSelf)
        {
            p2 = centerSphere.transform.position;

            x = (p1[0] - p2[0]) * (p1[0] - p2[0]);
            y = (p1[1] - p2[1]) * (p1[1] - p2[1]);
            z = (p1[2] - p2[2]) * (p1[2] - p2[2]);

            dist = Math.Sqrt(x + y + z);

            if (dist <= 0.03)
            {
                randNum = Random.Range(1, 4);
                centerSphere.SetActive(false);

                if (randNum == 1)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        sphere[i].SetActive(true);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }

                    int randSphere = Random.Range(1, 7);
                    sphere[randSphere].GetComponent<Renderer>().material.color = Color.green;

                    for (int i = 7; i < sphere.Length; i++)
                    {
                        sphere[i].SetActive(false);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }
                }
                else if(randNum == 2)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        sphere[i].SetActive(false);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }

                    for (int i = 17; i < sphere.Length; i++)
                    {
                        sphere[i].SetActive(false);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }

                    for (int i = 7; i < 17; i++)
                    {
                        sphere[i].SetActive(true);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }

                    int randSphere = Random.Range(7, 17);
                    sphere[randSphere].GetComponent<Renderer>().material.color = Color.green;
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        sphere[i].SetActive(false);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }

                    for (int i = 17; i < sphere.Length; i++)
                    {
                        sphere[i].SetActive(true);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }

                    for (int i = 7; i < 17; i++)
                    {
                        sphere[i].SetActive(false);
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                    }

                    int randSphere = Random.Range(17, sphere.Length+1);
                    sphere[randSphere].GetComponent<Renderer>().material.color = Color.green;
                }
            }
        }
        

        for(int i=0; i<sphere.Length; i++)
        {
            if (sphere[i].activeSelf)
            {
                p2 = sphere[i].transform.position;

                x = (p1[0] - p2[0]) * (p1[0] - p2[0]);
                y = (p1[1] - p2[1]) * (p1[1] - p2[1]);
                z = (p1[2] - p2[2]) * (p1[2] - p2[2]);

                dist = Math.Sqrt(x + y + z);

                if (dist <= 0.03)
                {
                    for (int j = 0; j < sphere.Length; j++)
                    {
                        sphere[i].GetComponent<Renderer>().material.color = new Color(255, 255, 255);
                        sphere[j].SetActive(false);
                    }

                    centerSphere.SetActive(true);

                    break;
                }
            }
        }

    }
}
