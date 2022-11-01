using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner Instance;
    public GameObject brick;
    [SerializeField] Transform brickParent;
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
    }
    public void spawnFromPool(Vector3 positon, Quaternion rotation)
    {
        int index = listPool.Count - 1;
        listPool[index].SetActive(true);
        listPool[index].transform.position = positon;
        listPool[index].transform.rotation = rotation;
        updateColorBirck(listPool[index]);
        listPool.RemoveAt(index);
    }
    void updateColorBirck(GameObject newBrick)
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
                updateColorBirck(newBrick);
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
