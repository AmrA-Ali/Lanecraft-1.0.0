using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class MapBricks
{
    public List<string> mapParts;
    public MapBricks(List<GameObject> TheSet)
    {
        for (int i = 0; i < TheSet.Count; i++)
        {
            mapParts.Add(TheSet[i].name.Substring(0, TheSet[i].name.Length - "(Clone)".Length));
        }
    }
}
