using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner Instance;
    public GameObject brick;
    [SerializeField] Transform brickParent;
    private Vector3 firstPos = new Vector3(-7f, 0.15f, 6f);
    private int listBrickBlue = 0;
    private int listBrickGreen = 0;
    private int listBrickYellow = 0;
    private int listBrickRed = 0;
    public int size;
    private int maxBirck = 16;
    List<GameObject> listPool = new List<GameObject>();
    void Start()
    {
        Instance = this;
        for(int i=0; i< size; i++)
        {
            GameObject obj = Instantiate(brick, brickParent);
            obj.SetActive(false);
            listPool.Add(obj);
        }
        createBrick();
    }
    private void FixedUpdate()
    {
        
    }
    public void reSpawnBrick(List<Vector3> listPosSpawn)
    {
        for (var i = 0; i < listPosSpawn.Count; i++)
        {
            spawnFromPool(listPosSpawn[i], Quaternion.identity);
            listPosSpawn.RemoveAt(i);
        }
    }
    void createBrick()
    {
        for (var i = 0; i < 8; i++)
            for (var j = 0; j < 8; j++)
            {
                spawnFromPool(new Vector3(firstPos.x + (j * 2), firstPos.y, firstPos.z - (i * 2)), Quaternion.identity);
                //updateColorBirck(newBrick);
            }
    }
    public void spawnFromPool(Vector3 positon, Quaternion rotation)
    {
        int index = listPool.Count - 1;
        listPool[index].SetActive(true);
        listPool[index].tag = "Brick";
        listPool[index].transform.position = positon;
        listPool[index].transform.rotation = rotation;
        updateColorBrick(listPool[index]);
        listPool.RemoveAt(index);
    }
    void updateColorBrick(GameObject newBrick)
    {
        int ramdom = Random.Range(1, 5);
        if(listBrickRed <= maxBirck || listBrickBlue <= maxBirck || listBrickGreen <= maxBirck || listBrickYellow <= maxBirck)
            if (ramdom == 1 && listBrickRed <= maxBirck)
            {//red
                newBrick.GetComponent<MeshRenderer>().material.color = Color.red;
                listBrickRed++;
            }
            else if (ramdom == 2 && listBrickBlue <= maxBirck)
            {
                //blue
                newBrick.GetComponent<MeshRenderer>().material.color = Color.blue;
                listBrickBlue++;
            }
            else if (ramdom == 3 && listBrickGreen <= maxBirck)
            {
                //green
                newBrick.GetComponent<MeshRenderer>().material.color = Color.green;
                listBrickGreen++;
            }
            else if (ramdom == 4 && listBrickYellow <= maxBirck)
            {
                //yellow
                newBrick.GetComponent<MeshRenderer>().material.color = Color.yellow;
                listBrickYellow++;
            }
            else
            {
                updateColorBrick(newBrick);
            }
    }
    public void updateCountListBrick(Color color)
    {
        if (color == Color.blue)
            listBrickBlue--;
        else if (color == Color.red)
            listBrickRed--;
        else if (color == Color.green)
            listBrickGreen--;
        else
            listBrickYellow--;
    }
}
