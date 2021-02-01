using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSaw : MonoBehaviour
{
    // Start is called before the first frame update
    float sawSpeed = 300;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, sawSpeed * Time.deltaTime);
    }
}
