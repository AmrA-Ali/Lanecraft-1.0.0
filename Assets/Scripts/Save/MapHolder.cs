using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[Serializable]
public class MapHolder
{
    private MapBricks mb;
    private MapInfo mi;
	public MapHolder (List<GameObject> TheSet)
	{
        mb = new MapBricks(TheSet);
        //mi = new global::MapInfo;
	}
}
