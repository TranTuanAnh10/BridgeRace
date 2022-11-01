using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] GameObject brick;
    [SerializeField] GameObject checkPoin;
    [SerializeField] Transform brickParent;
    [SerializeField] Transform brickParentInPlayer;
    [SerializeField] Transform brickParentInBridge;
    private Vector3 firstPos = new Vector3(-7f, 0.15f, 6f);
    private Vector3 firstPosBackpack = new Vector3(0, 0.3f, 0);
    private Vector3 firstPosBridge = new Vector3(0, 0, 0.2f);
    private const float tweenTime = 0.7f;
    List<GameObject> objects;
    List<Vector3> listPosSpawn = new List<Vector3>();
    private Vector3 nextPos;
    private Vector3 nextPosBridge;
    private Vector3 zero;
    private float spawnTime = 10f;
    private float timer = 10f;
    void Start()
    {
        Instance = this;
        createBrick();
        objects = new List<GameObject>();
        nextPos = firstPosBackpack;
        nextPosBridge = firstPosBridge;
    }
    void Update()
    {
        if(Time.time > timer && listPosSpawn.Count > 0)
        {
            spawnBrick();
            timer = Time.time + spawnTime;
        }
    }
    void createBrick()
    {
        for (var i = 0; i < 8; i++)
            for(var j = 0; j < 8; j++)
            {
                BrickSpawner.Instance.spawnFromPool(new Vector3(firstPos.x + (j * 2), firstPos.y, firstPos.z - (i * 2)), Quaternion.identity);
                //updateColorBirck(newBrick);
            }
    }
    void spawnBrick()
    {
        for (var i = 0; i < listPosSpawn.Count; i++)
        {
            BrickSpawner.Instance.spawnFromPool(listPosSpawn[i], Quaternion.identity);
            listPosSpawn.RemoveAt(i);
            //updateColorBirck(newBrick);
        }
    }
    public void takeBrick()
    {
        int index = objects.Count-1;
        Debug.Log(index);
        if(index >= 0)
        {
            objects[index].transform.SetParent(brickParentInBridge);
            objects[index].transform.DOLocalMove(nextPosBridge, tweenTime);
            objects[index].transform.DOLocalRotate(zero, tweenTime);
            objects[index].tag = "Untagged";
            checkPoin.transform.DOLocalMove(new Vector3(0f, 1.1f, nextPosBridge.z + 0.1f), 1f);
            nextPosBridge += new Vector3(0f, objects[index].transform.localScale.y, objects[index].transform.localScale.z );
            nextPos -= new Vector3(0f, objects[index].transform.localScale.y + 0.01f, 0f);
            objects.RemoveAt(index);
        }
        else
        {
            Debug.Log("fdfdfdfgd");
        }
    }
    public void pickUpBrick(GameObject objectPickUp)
    {
        objectPickUp.transform.SetParent(brickParentInPlayer);
        listPosSpawn.Add(objectPickUp.transform.position);
        objectPickUp.transform.DOLocalMove(nextPos, tweenTime);
        objectPickUp.transform.DOLocalRotate(zero, tweenTime);
        nextPos += new Vector3(0f,objectPickUp.transform.localScale.y+0.01f * objects.Count, 0f);
        objects.Add(objectPickUp);
    }
}
