using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public static BrickSpawner Instance;
    public GameObject brick;
    [SerializeField] Transform brickParent;
    private Vector3 firstPos = new Vector3(-7f, 0.15f, 6f);
    private List<GameObject> listBrickBlue = new List<GameObject>();
    private List<GameObject> listBrickGreen = new List<GameObject>();
    private List<GameObject> listBrickYellow = new List<GameObject>();
    private List<GameObject> listBrickRed = new List<GameObject>();
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
        if (index >= 0)
        {
            listPool[index].tag = "Brick";
            listPool[index].transform.position = positon;
            listPool[index].transform.rotation = rotation;
            updateColorBrick(listPool[index]);
            listPool.RemoveAt(index);
        }
    }
    void updateColorBrick(GameObject newBrick)
    {
        int ramdom = Random.Range(1, 5);
        if(listBrickRed.Count <= maxBirck || listBrickBlue.Count <= maxBirck || listBrickGreen.Count <= maxBirck || listBrickYellow.Count <= maxBirck)
            if (ramdom == 1 && listBrickRed.Count <= maxBirck)
            {//red
                newBrick.GetComponent<MeshRenderer>().material.color = Color.red;
                listBrickRed.Add(newBrick);
            }
            else if (ramdom == 2 && listBrickBlue.Count <= maxBirck)
            {
                //blue
                newBrick.GetComponent<MeshRenderer>().material.color = Color.blue;
                listBrickBlue.Add(newBrick);
            }
            else if (ramdom == 3 && listBrickGreen.Count <= maxBirck)
            {
                //green
                newBrick.GetComponent<MeshRenderer>().material.color = Color.green;
                listBrickGreen.Add(newBrick);
            }
            else if (ramdom == 4 && listBrickYellow.Count <= maxBirck)
            {
                //yellow
                newBrick.GetComponent<MeshRenderer>().material.color = Color.yellow;
                listBrickYellow.Add(newBrick);
            }
            else
            {
                updateColorBrick(newBrick);
            }
    }
    public void updateListBrick(Color _color,GameObject _object)
    {
        if (_color == Color.blue)
            listBrickBlue.Remove(_object);
        else if (_color == Color.red)
            listBrickRed.Remove(_object);
        else if (_color == Color.green)
            listBrickGreen.Remove(_object);
        else
            listBrickYellow.Remove(_object);
    }
    public List<GameObject> getListBrick(Color _color)
    {
        if (_color == Color.blue)
            return listBrickBlue;
        else if (_color == Color.red)
            return  listBrickRed;
        else if (_color == Color.green)
            return listBrickGreen;
        else
            return listBrickYellow;
    }
    public void activeBrickWithColor(Color _color)
    {
        if (_color == Color.blue)
        {
            foreach (GameObject _obj in listBrickBlue)
                _obj.SetActive(true);
        }    
        else if (_color == Color.red)
        {
            foreach (GameObject _obj in listBrickRed)
                _obj.SetActive(true);
        }
        else if (_color == Color.green)
        {
            foreach (GameObject _obj in listBrickGreen)
                _obj.SetActive(true);
        }
        else
        {
            foreach (GameObject _obj in listBrickYellow)
                _obj.SetActive(true);
        }
    }
}
