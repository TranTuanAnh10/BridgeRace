using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] Transform brickParentInPlayer;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] Animator playerAni;
    [SerializeField] bool isBot;
    [SerializeField] Transform movePosition;
    [SerializeField] Color SelfColor;

    private Vector3 firstPosBackpack = new Vector3(0, 0.3f, 0);
    private Vector3 nextPos;
    private Vector3 zero;
    private const float tweenTime = 0.7f;
    private NavMeshAgent navMeshAgent;
    GameObject _object;
    List<GameObject> objects;
    private void Awake()
    {
        if(isBot) navMeshAgent = GetComponent<NavMeshAgent>();
        nextPos = firstPosBackpack;
        objects = new List<GameObject>();
    }
    private void FixedUpdate()
    {
        if (isBot==false)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(inputX * speed, rb.velocity.y, inputY * speed);
            if (inputX != 0 || inputY != 0)
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
                playerAni.SetBool("IsRun", true);
            }
            else
            {
                playerAni.SetBool("IsRun", false);
            }
        }
        else
        {
            navMeshAgent.destination = movePosition.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Brick"))
        {
            Material material = other.gameObject.GetComponent<MeshRenderer>().material;
            Color color = material.color;
            if (color.Equals(SelfColor))
            {
                pickUpBrick(other.gameObject);
                BrickSpawner.Instance.updateCountListBrick(color);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("checkpoin"))
        {
            //Bridge.Instance.moveBrickToBridge();
            collision.gameObject.transform.parent.GetComponent<Bridge>().moveBrickToBridge(collision.gameObject, getPosBrick());
        }
    }
    public void pickUpBrick(GameObject objectPickUp)
    {
        objectPickUp.transform.SetParent(brickParentInPlayer);
        GameController.Instance.setListPosSpawn(objectPickUp.transform);
        objectPickUp.transform.DOLocalMove(nextPos, tweenTime);
        objectPickUp.transform.DOLocalRotate(zero, tweenTime);
        nextPos += new Vector3(0f, objectPickUp.transform.localScale.y + 0.01f, 0f);
        objects.Add(objectPickUp);
    }
    public GameObject getPosBrick()
    {
        int index = objects.Count - 1;
        if (index >= 0)
        {
            nextPos -= new Vector3(0f, objects[index].transform.localScale.y + 0.01f, 0f);
            _object = objects[index];
            objects.RemoveAt(index);
            return _object;
        }
        else return null;
    }
}

