using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bridge : MonoBehaviour
{
    public static Bridge Instance;
    [SerializeField] Transform brickParentInBridge;
    //[SerializeField] GameObject checkPoin;
    private Vector3 firstPosBridge = new Vector3(0, 0, 0.2f);
    private Vector3 nextPosBridge;
    private const float tweenTime = 0.7f;
    private Vector3 zero;
    private float brickInBridgeCount = 0f;
    private float maxBrickInBridge = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        nextPosBridge = firstPosBridge;
    }
    public void moveBrickToBridge(GameObject checkPoin, GameObject obj) 
    {
       if (brickInBridgeCount < maxBrickInBridge && obj !=null)
        {
            obj.transform.SetParent(brickParentInBridge);
            obj.transform.DOLocalMove(nextPosBridge, tweenTime);
            obj.transform.DOLocalRotate(zero, tweenTime);
            obj.tag = "Untagged";
            checkPoin.transform.DOLocalMove(new Vector3(0f, 1.1f, nextPosBridge.z + 0.1f), 1f);
            nextPosBridge += new Vector3(0f, 0f, obj.transform.localScale.z);
            brickInBridgeCount++;
        }
    }
}
