using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BrickManager : MonoBehaviour {
    //MyList
    public static List<GameObject> TheSet = new List<GameObject>();
    private static GameObject[] ListofPrefabs = Resources.LoadAll<GameObject>("Prefabs/Shapes");
    private static GameObject FinishLinePrefab = Resources.Load<GameObject>("Prefabs/YOUJUSTWON");
    public static GameObject AddFinishLine()
    {
        var temp= AddBrick(FinishLinePrefab);
        ClearSet();
        return temp;
    }
    public static void RemoveLastObject()
    {
        if (TheSet.Count >= 1)
        {
            Destroy(TheSet[TheSet.Count - 1]);
            TheSet.RemoveAt(TheSet.Count - 1);
        }
    }
    private static GameObject AddBrick(GameObject mygb)
    {
        GameObject gb2;
        Transform trans;
        if (TheSet.Count == 0)
        {
            gb2 = Instantiate(mygb) as GameObject;
            gb2.transform.position = new Vector3(0, 0, 0);
            TheSet.Add(gb2);
        }
        else
        {
            trans = TheSet[TheSet.Count - 1].transform.GetChild(1);
            gb2 = Instantiate(mygb, trans.position, trans.rotation) as GameObject;
            TheSet.Add(gb2);
        }
        return gb2;
    }
    public static GameObject AddBrick(string objectName)
    {
        foreach( var e in ListofPrefabs)
            if (objectName == e.name)
                return AddBrick(e);
        return null;
    }
    private static void ClearSet()
    {
        TheSet.Clear();
    }
}