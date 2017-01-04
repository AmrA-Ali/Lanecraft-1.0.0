using UnityEngine;
using UnityEngine.UI;
public class MapNameSetter : MonoBehaviour {
	void Start()
    { GetComponent<Button>().onClick.AddListener(delegate { setMapName(); }); }
    //Get the map name from the button's text
    //set the mapname string in the Datatransfer script to be equal to that string.
    void setMapName()
    {
        var name = GetComponentInChildren<Text>().text;
        DataTransfer.MapName = name;
    }
}