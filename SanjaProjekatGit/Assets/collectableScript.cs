using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collectable");
        if (collision.gameObject.tag == "Character")
        {            
            Destroy(this.gameObject);
        }
    }
}
