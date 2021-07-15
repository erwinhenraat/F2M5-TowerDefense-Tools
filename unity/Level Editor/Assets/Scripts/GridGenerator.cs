using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridGenerator : MonoBehaviour
{
 
    public TextAsset jsonFile;
    public GameObject[] tilePrefabs; 

    private JsonDataObject jdo;

    // Start is called before the first frame update
    void Start()
    {
        //Serializable Tile class maken - V
        //Serializable JsonDataObject class maken - V
        //inladen van JSON file - V
        //inladen van lijst met tiles vanuit JSON - V

        jdo = JsonDataObject.CreateJSONData(jsonFile.text);

      
       
        
      
        
        //Loop door lijst met tiles heen 

        //plaats plane prefabs afhankelijk van type

        if (tilePrefabs.Length == 0){
            throw new Exception("tilePrefabs is empty");
        }else{
            GenerateGrid();
        }
        


    }
    private void GenerateGrid(){
        int index = 0;
        foreach (Tile t in jdo.tiles)
        {
            
            GameObject prefab = tilePrefabs[0];
            switch(t.state){
                case "default":
                prefab = tilePrefabs[0];
                break;
                case "buildable":
                prefab = tilePrefabs[1];
                break;
                case "spawnpoint":
                prefab = tilePrefabs[2];
                break;
                case "waypoint":
                prefab = tilePrefabs[3];
                break;
                case "path":
                prefab = tilePrefabs[4];
                break;
            }
            float gridWidth = jdo.width;
            float tileSize =  prefab.GetComponent<Renderer>().bounds.size.x;
            float xpos = index % gridWidth * tileSize;
            float zpos = Mathf.Floor(index / gridWidth)*tileSize; 
            

            Instantiate(prefab, new Vector3(xpos,0f,zpos), Quaternion.identity , transform);
            
            if(index < jdo.tiles.Length)index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
