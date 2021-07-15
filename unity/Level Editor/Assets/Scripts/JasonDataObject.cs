using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class JsonDataObject{
    public int width;
    public int height;

    public Tile[] tiles;
    public static JsonDataObject CreateJSONData(string jsonString){
        return JsonUtility.FromJson<JsonDataObject>(jsonString);
    }
}