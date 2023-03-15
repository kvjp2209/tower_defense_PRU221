using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.Drawing;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    private Point blueSpawn, redSpawn;

    [SerializeField]
    private GameObject bluePortalPrefab;

    [SerializeField]
    private GameObject redPortalPrefab;

    public float TileSize
    {
        //Tinh toan kich thuoc cac vien gach vao dung vi tri
        get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }
    // Start is called before the first frame update
    void Start()
    {
       // CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }
/*
    private void TestPoint()
    {

    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();


        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 maxTile = Vector3.zero;


        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < mapY; y++) // Vi tri y
        {
            //chuoi tung dong
            char[] newTiles = mapData[y].ToCharArray();
            for (int x = 0; x < mapX; x++) // Vi tri x
            {
                //duyet tung type tile trong mang de tao tile
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);

            }
        }

        maxTile = Tiles[new Point(mapX - 1, mapY - 1)].transform.position;

        CameraMovement.SetLimits(new Vector3(maxTile.x + TileSize, maxTile.y - TileSize));

        //Sinh Portal
        SpawnPortals();
    }*/
/*
    private void PlaceTile(string titleType, int x, int y, Vector3 worldStart)
    {
        //"1" = 1
        int tileIndex = int.Parse(titleType);


        // tao mot o moi va tham chieu len o co trong vien newTile
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        //dat newTile vao o co toa do tinh tu do (x,y) va luu dia chi vao tile
        newTile.GetComponent<TileScript>().Setup(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0));

        //Them o nay vao Tiles voi toa do (x,y)
        Tiles.Add(new Point(x, y), newTile);
    }*/

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Map") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);

        return data.Split('-');
    }

/*    private void SpawnPortals()
    {
        blueSpawn = new Point(0, 0);
        //Tao portal blue o toa do (0,0)
        Instantiate(bluePortalPrefab, Tiles[blueSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);


        redSpawn = new Point(15, 6);
        //Tao portal blue o toa do (x , y)
        Instantiate(bluePortalPrefab, Tiles[redSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }*/
}
