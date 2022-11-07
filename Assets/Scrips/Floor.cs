using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    List<Color> listPlayer = new List<Color>();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            listPlayer.Add(collision.gameObject.GetComponent<PlayerMove>().SelfColor);
            BrickSpawner.Instance.activeBrickWithColor(collision.gameObject.GetComponent<PlayerMove>().SelfColor);
        }
    }
}