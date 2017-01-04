using UnityEngine;
//Check if there are any available maps
public class CountMaps : MonoBehaviour {
    public static bool ThereAreMaps;
	void Start () { ThereAreMaps = (SaveLoadManager.GetAllMapsNames().Length >0); }
}