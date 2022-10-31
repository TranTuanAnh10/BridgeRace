using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickContoller : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.Instance.createBrickPlayer();
            Destroy(this);
        }
    }
}
