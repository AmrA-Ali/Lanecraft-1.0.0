using UnityEngine;
using System.Collections;

public class SavingTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MapManager mm = new MapManager();
        mm.AddBrick("Line");
        mm.AddBrick("Line");
        mm.AddBrick("Line");
        mm.AddBrick("TurnRight");
        mm.AddBrick("TurnRight");
        mm.AddBrick("Line");
        mm.AddBrick("Line");
        mm.AddBrick("Line");
        mm.AddBrick("TurnRight");
        mm.AddBrick("TurnRight");
        mm.AddBrick("TurnLeft");

        mm.info.name = "7mada";
        mm.Save();
    }
	
}
