using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickContoller : MonoBehaviour
{
    public static BrickContoller Instance;
    private Collider _collider;
    private void Start()
    {
        Instance = this;
        _collider = GetComponent<Collider>();
    }
    /*public static Vector3 RandomPointInCollider()
    {
        Bounds bounds = _collider.bounds;
        Vector3 result = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
            );
        Debug.Log(result);
        return _collider.ClosestPoint(result);
    }*/

}
