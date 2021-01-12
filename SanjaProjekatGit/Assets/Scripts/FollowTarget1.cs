using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;

    //min and max values y
    public bool YMaxEnabled = false;
    public float Ymax = 0;
    public bool YMinEnabled = false;
    public float Ymin = 0;




    //min and max values x

    public bool XMaxEnabled = false;
    public float Xmax = 0;
    public bool XMinEnabled = false;
    public float Xmin = 0;

    void FixedUpdate()
    {
        Vector3 targetPos = target.position;

        //vertikalno

        if (YMinEnabled && YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, Ymin, Ymax);
        }
        else if (YMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, Ymin, target.position.y);
        }
        else if (YMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, Ymax);
        }

        //horizontalno

        if (XMinEnabled && XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, Xmin, Xmax);
        }
        else if (XMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, Xmin, target.position.x);
        }
        else if (XMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, Xmax);
        }



        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

}
