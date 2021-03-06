﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Map
{
    #region variables
    public Info info;
    public Bricks bricks;
    public static Map curr;
    public static GameObject mapParent;
    private List<GameObject> TheSet;
    private static GameObject[] Shapes = Resources.LoadAll<GameObject>("Prefabs/Shapes");
    private static GameObject FinishLinePrefab = Resources.Load<GameObject>("Prefabs/YOUJUSTWON");
    #endregion

    #region ctor
    public Map()
    {
        TheSet = new List<GameObject>();
        info = new Info();
        bricks = new Bricks();
    }
    #endregion

    #region loading
    public void Save()
    {
        DoCalculations();
        SaveLoadManager.Save(info, info.code);
        SaveLoadManager.Save(bricks, info.code);
    }
    public void CreateMapParent()
    {
        if (mapParent == null)
        {
            mapParent = new GameObject();
            mapParent.name = "Track";
        }
    }   
    public void FetchBricks()
    {
        bricks = SaveLoadManager.LoadBrickFile(info.code);
    }
    public static Map[] FetchMapsInfo()
    {
        List<Map> maps = new List<Map>();
        foreach (var code in SaveLoadManager.FetchMapsInfoCodes())
        {
            Map m = new Map();
            m.info = SaveLoadManager.LoadInfoFile(code.FilterFileExtension(SaveLoadManager.FileExtension));
            maps.Add(m);
        }
        return maps.ToArray();
    }
    #endregion

    #region brickbuilding
    public void Build()
    {
        FetchBricks();
        foreach (string brickName in bricks.list)
        {
            AddBrick(brickName);
        }
        AddFinishLine();
    }
    public void RemoveLastObject()
    {
        if (TheSet.Count >= 1)
        {
            MonoBehaviour.Destroy(TheSet[TheSet.Count - 1]);
            TheSet.RemoveAt(TheSet.Count - 1);
        }
    }

    private GameObject AddBrick(GameObject mygb, bool building = false)
    {
        GameObject gb2;
        Transform trans;
        if (TheSet.Count == 0)
        {
            gb2 = MonoBehaviour.Instantiate(mygb) as GameObject;
            gb2.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            trans = TheSet[TheSet.Count - 1].transform.GetChild(1);
            gb2 = MonoBehaviour.Instantiate(mygb, trans.position, trans.rotation) as GameObject;
        }
        gb2.name = mygb.name;
        CreateMapParent();
        gb2.transform.SetParent(mapParent.transform);
        TheSet.Add(gb2);
        if (building)
        {
            bricks.list.Add(gb2.name);
            Camera.main.UpdateCamera(gb2.transform.GetChild(0));
        }
        return gb2;
    }

    public GameObject AddBrick(string objectName, bool building = false)
    {
        foreach (var e in Shapes)
        {
            if (objectName == e.name)
            {
                return AddBrick(e, building);
            }
        }
        return null;
    }

    public GameObject AddFinishLine()
    {
        var temp = AddBrick(FinishLinePrefab);
        ClearSet();
        return temp;
    }
    private void ClearSet()
    {
        TheSet.Clear();
    }
    #endregion

    #region calculations
    public void DoCalculations()
    {
        CalculateCount();
        CalculateBounds();
        CalculateCode();
    }

    void CalculateCount()
    {
        info.brickCount = bricks.list.Count;
    }
    private void CalculateCode()
    {
        info.code = "";
        info.code = info.name + info.brickCount;
    }

    public void CalculateBounds()
    {
        Vector3 trans;
        for (int i = 0; i < TheSet.Count; i++)
        {
            trans = TheSet[i].transform.position;
            if (trans.x < info.minBound.x)
                info.minBound.x = trans.x;
            if (trans.x > info.maxBound.x)
                info.maxBound.x = trans.x;

            if (trans.y < info.minBound.y)
                info.minBound.y = trans.y;
            if (trans.y > info.maxBound.y)
                info.maxBound.y = trans.y;

            if (trans.z < info.minBound.z)
                info.minBound.z = trans.z;
            if (trans.z > info.maxBound.z)
                info.maxBound.z = trans.z;
        }
        info.center = new Info.OurVector3((info.maxBound.get() + info.minBound.get()) / 2);

    }
    #endregion
}


[Serializable]
public class Bricks
{
    public List<string> list;
    public Bricks() { list = new List<string>(); }
    public Bricks(List<GameObject> TheSet)
    {
        for (int i = 0; i < TheSet.Count; i++)
        {
            list.Add(TheSet[i].name.Substring(0, TheSet[i].name.Length - "(Clone)".Length));
        }
    }
}


[Serializable]
public class Info
{
    public string creator;
    public OurVector3 minBound, maxBound, center;
    public DateTime dateCreated;
    public DateTime dateUpdated;
    public int brickCount;
    public Stats statistics;
    public int difficulty = 0;
    public int highestScore = 0;
    public string name;
    public string code;
    public Info()
    {
        name = "OMG";
        creator = "ALi";
        minBound = new OurVector3();
        maxBound = new OurVector3();

    }
    [Serializable]
    public class Stats
    {
        public int turnRights, turnLefts, curveUps, curveDowns, lines;
        public int obstacleCount;
    }
    [Serializable]
    public class OurVector3
    {
        public float x, y, z;
        public OurVector3() { }
        public OurVector3(Vector3 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }
        public Vector3 get()
        {
            return new Vector3(x, y, z);
        }
    }
}
