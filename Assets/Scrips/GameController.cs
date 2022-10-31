using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] GameObject brick;
    [SerializeField] Transform brickParent;
    [SerializeField] Transform brickParentInPlayer;
    private Vector3 firstPos = new Vector3(-12f, 0.15f, 13f);
    private Vector3 firstPosBackpack = new Vector3(0, 0.3f, 0);
    private const float tweenTime = 0.7f;
    List<GameObject> _objects;
    private Vector3 _nextPos;
    private Vector3 zero;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        createBrick();
        _objects = new List<GameObject>();
        _nextPos = firstPosBackpack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void createBrick()
    {
        for (var i = 0; i < 14; i++)
            for(var j = 0; j < 13; j++)
            {
                GameObject newBrick = Instantiate(brick, new Vector3(firstPos.x + (j * 2), firstPos.y, firstPos.z - (i*2)), Quaternion.identity, brickParent);
                newBrick
            }
    }
    public void PushObject(GameObject objectToPush)
    {
        objectToPush.transform.SetParent(brickParentInPlayer);
        objectToPush.transform.DOLocalMove(_nextPos, tweenTime);
        objectToPush.transform.DOLocalRotate(zero, tweenTime);
        Debug.Log(objectToPush.transform.position);
        _nextPos += new Vector3(0f,(objectToPush.transform.localScale.y + 0.05f),0f);
        _objects.Add(objectToPush);
    }
}
