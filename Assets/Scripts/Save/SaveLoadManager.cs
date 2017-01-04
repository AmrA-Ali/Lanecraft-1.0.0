using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;


public class SaveLoadManager : MonoBehaviour
{
    public static String MapsFolder = Application.persistentDataPath + "/Maps/";
    public static String FileExtension = ".dat";
    public static void CreateMapsFolder()
    {
        Directory.CreateDirectory(MapsFolder);
    }
    public static void SaveCurrentLego(String FileName)
    {
        //Save(AddNew.TheSet, FileName);
    }

    public static string[] GetAllMapsNames()
    {
        return Directory.GetFiles(Application.persistentDataPath + "/Maps");
    }


    public static void Save(List<GameObject> TheSet, String FileName)
    {
        MapHolder map = MapHolder.CreateMapHolder(TheSet);
        Save(map, FileName);
    }
    public static void Save(List<List<Vector3>> ListofDots, String FileName)
    {
        MapHolder map = MapHolder.CreateMapHolder(ListofDots);
        Save(map, FileName);
    }
    public static void Save(MapHolder map, String fileName)
    {
        String fullFileName = MapsFolder + fileName + FileExtension;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(fullFileName);

        bf.Serialize(file, map);
        file.Close();

        print("File saved successfully");
    }

    public static MapHolder Load(string fileName)
    {
        string fullFileName = MapsFolder + fileName + FileExtension;

        if (File.Exists(fullFileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(fullFileName, FileMode.Open);
            MapHolder m = (MapHolder)bf.Deserialize(file);
            file.Close();
            print("File loaded successfully");
            return m;
        }
        else
        {
            print("File not found");
        }
        return null;
    }

}
