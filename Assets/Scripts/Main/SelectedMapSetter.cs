using UnityEngine;
using UnityEngine.UI;
public class SelectedMapSetter : MonoBehaviour
{
    public MapManager selectedMap;
    void Start()
    { GetComponent<Button>().onClick.AddListener(delegate { setMap(); }); }
    //set the map in the Datatransfer script.
    void setMap()
    {
        DataTransfer.selectedMap = selectedMap;
    }
}