using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [SerializeField] Text brickInBackpack;
    [SerializeField] Text brickInBridge;
    List<Vector3> listPosSpawn = new List<Vector3>();
    private float spawnTime = 10f;
    private float timer = 10f;
    void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if(Time.time > timer && listPosSpawn.Count > 0)
        {
            BrickSpawner.Instance.reSpawnBrick(listPosSpawn);
            timer = Time.time + spawnTime;
        }
    }
    public void setListPosSpawn(Transform _transform)
    {
        listPosSpawn.Add(_transform.position);
    }
}
