using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] Transform brickParent;
    [SerializeField] Transform brickParentInPlayer;
    [SerializeField] Transform brickParentInBridge;
    [SerializeField] Text brickInBackpack;
    [SerializeField] Text brickInBridge;
    private Vector3 firstPosBackpack = new Vector3(0, 0.3f, 0);
    private const float tweenTime = 0.7f;
    List<GameObject> objects;
    List<Vector3> listPosSpawn = new List<Vector3>();
    private Vector3 nextPos;
    private Vector3 zero;
    private float spawnTime = 10f;
    private float timer = 10f;
    private float brickInBridgeCount = 0f;
    void Start()
    {
        Instance = this;
        objects = new List<GameObject>();
        nextPos = firstPosBackpack;
        brickInBridge.text = "Bridge: " + brickInBridgeCount + "/20";
        brickInBackpack.text = "Backpack: " + objects.Count;
    }
    void Update()
    {
        if(Time.time > timer && listPosSpawn.Count > 0)
        {
            BrickSpawner.Instance.reSpawnBrick(listPosSpawn);
            timer = Time.time + spawnTime;
        }
    }
    
    public void takeBrick()
    {
        int index = objects.Count-1;
        if(index >= 0)
        {
            nextPos -= new Vector3(0f, objects[index].transform.localScale.y + 0.01f, 0f);
            Bridge.Instance.moveBrickToBridge(objects[index]);
            brickInBridge.text = "Bridge: " + brickInBridgeCount + "/20";
            objects.RemoveAt(index);
            brickInBackpack.text = "Backpack: " + objects.Count;
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
        brickInBackpack.text = "Backpack: "+ objects.Count;
    }
}
