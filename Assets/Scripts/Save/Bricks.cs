using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

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
