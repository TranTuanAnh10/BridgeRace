using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject brickInPlayer;
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 6, player.transform.position.z - 7);
       // brickInPlayer.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.6f, player.transform.position.z - 0.6f);
    }
}
