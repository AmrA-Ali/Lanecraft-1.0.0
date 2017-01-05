using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MapManager 
{
    public Info info;
    public Bricks bricks;
    public MapManager()
    {
        info = new Info();
        bricks = new Bricks();
    }
    public void Save()
    {
        DoCalculations();
        SaveLoadManager.Save(info, info.code);
        SaveLoadManager.Save(bricks, info.code);
    }
    public void Build()
    {
        FetchBricks();
        foreach (var brick in bricks.list)
            AddBrick(brick);
        AddFinishLine();
    }
    public void FetchBricks()
    {
        bricks = SaveLoadManager.LoadBrickFile(info.code);
    }

    public static MapManager[] FetchMapsInfo()
    {
        List<MapManager> maps = new List<MapManager>();
        foreach (var code in SaveLoadManager.FetchMapsInfoCodes())
        {
            MapManager m = new MapManager();
            m.info = SaveLoadManager.LoadInfoFile(code.FilterFileExtension(SaveLoadManager.FileExtension));
            maps.Add(m);
        }
        return maps.ToArray();
    }
    //MyList
    public static List<GameObject> TheSet = new List<GameObject>();

    private static GameObject[] ListofPrefabs = Resources.LoadAll<GameObject>("Prefabs/Shapes");

    private static GameObject FinishLinePrefab = Resources.Load<GameObject>("Prefabs/YOUJUSTWON");



    public GameObject AddFinishLine()
    {
        var temp = AddBrick(FinishLinePrefab);
        ClearSet();
        return temp;
    }

    public static void RemoveLastObject()
    {
        if (TheSet.Count >= 1)
        {
            MonoBehaviour.Destroy(TheSet[TheSet.Count - 1]);
            TheSet.RemoveAt(TheSet.Count - 1);
        }
    }

    private GameObject AddBrick(GameObject mygb)
    {
        GameObject gb2;
        Transform trans;
        if (TheSet.Count == 0)
        {
            gb2 = MonoBehaviour.Instantiate(mygb) as GameObject;
            gb2.transform.position = new Vector3(0, 0, 0);
            TheSet.Add(gb2);
            bricks.list.Add(gb2.name);
        }
        else
        {
            trans = TheSet[TheSet.Count - 1].transform.GetChild(1);
            gb2 = MonoBehaviour.Instantiate(mygb, trans.position, trans.rotation) as GameObject;
            TheSet.Add(gb2);
            bricks.list.Add(gb2.name);
        }
        return gb2;
    }

    public GameObject AddBrick(string objectName)
    {
        foreach (var e in ListofPrefabs)
            if (objectName == e.name)
                return AddBrick(e);
        return null;
    }

    private static void ClearSet()
    {
        TheSet.Clear();
    }
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

    }

}