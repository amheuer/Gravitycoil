using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronaughtSpin : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.Rotate(0.0f, 0.0f, 0.015f, Space.Self);
    }
}
