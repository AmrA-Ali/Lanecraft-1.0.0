using UnityEngine;
using UnityEngine.UI;
public class DoneSave : MonoBehaviour {
    [SerializeField]
    private Text mapName;
	void Start () {
        GetComponent<Button>().onClick.AddListener(delegate { Confirm(); });
	}
    void Confirm()  {
        gameObject.map().info.name = mapName.text;
        gameObject.map().Save();
    }
}
