using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpinner : MonoBehaviour
{

    static bool rotated = false;
    static Vector3 yRot = Vector3.zero;

    private void Update()
    {
        rotate();
        transform.Rotate(yRot);
    }

    static void rotate()
    {
        if (!rotated)
        {
            rotated = true;
            yRot = Vector3.up * Time.deltaTime * 50f;
        }
    }

    private void LateUpdate()
    {
        rotated = false;
    }
}
