﻿using UnityEngine;
using System.Collections;

public class SavingTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Map mm = new Map();
        mm.AddBrick("Line",true);
        mm.AddBrick("Line",true);
        mm.AddBrick("Line",true);
        mm.AddBrick("TurnRight",true);
        mm.AddBrick("TurnRight",true);
        mm.AddBrick("Line",true);
        mm.AddBrick("Line",true);
        mm.AddBrick("Line",true);
        mm.AddBrick("Line",true);
        mm.AddBrick("Line",true);
        mm.AddBrick("TurnRight",true);
        mm.AddBrick("TurnRight",true);

        mm.info.name = "The Second Track";
        mm.Save();
    }
	
}