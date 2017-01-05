using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class Info 
{
    public string creator;
    public OurVector3 minBound, maxBound;
    public DateTime dateCreated;
    public DateTime dateUpdated;
    public int brickCount;
    public Stats statistics;
    public int difficulty = 0;
    public int highestScore = 0;
    public string name;
    public string code;
    public Info()
    {
        name = "OMG";
        creator = "ALi";
        minBound = new OurVector3();
        maxBound = new OurVector3();

    }
    [Serializable]
    public class Stats
    {
        public int turnRights, turnLefts, curveUps, curveDowns, lines;
        public int obstacleCount;
    }
    [Serializable]
    public class OurVector3
    {
       public  float x, y, z;
        public OurVector3() { }
        public OurVector3(Vector3 vec)
        {
            this.x = vec.x;
            this.y = vec.y;
            this.z = vec.z;
        }
        public Vector3 getAll()
        {
            return new Vector3(x, y, z);
        }
    }
}
