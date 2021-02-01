using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSignScript : MonoBehaviour
{
    // Start is called before the first frame update
    public StoneWall Wall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Wall = Wall.GetComponent<StoneWall>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Wall.gameObject.SetActive(false);
    }
}
