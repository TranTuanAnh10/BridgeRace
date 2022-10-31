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
    private int brickPlayerCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        createBrick();
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
                Instantiate(brick, new Vector3(firstPos.x + (j * 2), firstPos.y, firstPos.z - (i*2)), Quaternion.identity, brickParent);
            }
    }
    public void createBrickPlayer()
    {
        GameObject brickClone = Instantiate(brick, new Vector3(0, 0.3f + (brickPlayerCount * 0.3f), 0f), Quaternion.identity, brickParentInPlayer);
        brickClone.transform.position = new Vector3(0, 0.3f + (brickPlayerCount * 0.3f), 0);
        brickPlayerCount++;
    }
}
