using UnityEngine;
using System.Collections;

public class BuildSession : MonoBehaviour {

    // Use this for initialization
    public Map map;
	void Awake () {
        gameObject.setMap(new Map());
    }
}
