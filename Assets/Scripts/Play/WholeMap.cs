using UnityEngine;
using System.Collections;

public class WholeMap : MonoBehaviour {

    public static float minX, minY, minZ, maxX, maxY, maxZ;
    public static Vector3 UltimateCenter;
	// Use this for initialization

	void Start () {
        UltimateCenter = new Vector3(0, 0, 0);
        minX = minY = minZ = 10000000;
        maxX = maxY = maxZ = -10000000;
    }
    public static void CalculateMapBounds()
    {
        Vector3 trans;
        for (int i = 0; i < BrickManager.TheSet.Count; i++)
        {
            trans = BrickManager.TheSet[i].transform.position;
            if (trans.x < minX)
                minX = trans.x;
            if (trans.x > maxX)
                maxX = trans.x;

            if (trans.y < minY)
                minY = trans.y;
            if (trans.y > maxY)
                maxY = trans.y;

            if (trans.z < minZ)
                minZ = trans.z;
            if (trans.z > maxZ)
                maxZ = trans.z;
        }

    }
    public static void ViewWholeMap()
    {
        CalculateMapBounds();
        Vector3 minPos, maxPos, Center;
        minPos = new Vector3(minX, minY, minZ);
        maxPos = new Vector3(maxX, maxY, maxZ);
        Center = UltimateCenter = (maxPos + minPos) / 2;
     //   print(Center);
        Camera.main.fieldOfView = 70;
        Camera.main.transform.position = new  Vector3(Center.x, maxY+30, minZ - 75f);
        Camera.main.transform.LookAt(Center);
    }
}
