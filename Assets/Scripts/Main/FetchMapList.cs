using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FetchMapList : MonoBehaviour
{
    [SerializeField]
    private Button MapButton;
    public static string PlaySceneName = "_Play";
    void Start()
    {
        var ListofMaps = SaveLoadManager.GetAllMapsNames();
        Button gb;
        for (int i = 0; i < ListofMaps.Length; i++)
        {
            gb = Instantiate(MapButton);
            string name = ListofMaps[i].FilterFileExtension(SaveLoadManager.FileExtension);
#if MOBILE_INPUT
                name = name.Substring(name.LastIndexOf("/") + 1 );
#else
            name = name.Substring(name.IndexOf("\\") + 1);
#endif
            gb.GetComponentInChildren<Text>().text = name;
            gb.name = PlaySceneName;
            gb.transform.SetParent(transform);
            gb.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
