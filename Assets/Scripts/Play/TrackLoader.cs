using UnityEngine;
using System.Collections;

public class TrackLoader : MonoBehaviour
{
	void Start ()
	{
        string FileName = DataTransfer.MapName;
        MapHolder map = SaveLoadManager.Load(FileName);
		for (int i = 0; i < map.mapParts.Count; i++)
            BrickManager.AddBrick(map.mapParts[i].legoPart).transform.SetParent(transform);

        BrickManager.AddFinishLine().transform.SetParent(transform);
    }

}
