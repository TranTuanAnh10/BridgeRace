using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject brick;
    [SerializeField] Transform brickParent;
    private Vector3 firstPos = new Vector3(-12f, 0.15f, 13f);
    // Start is called before the first frame update
    void Start()
    {
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
}
