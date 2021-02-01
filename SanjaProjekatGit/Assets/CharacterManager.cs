using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text HealthText;
    

    float maxHealth = 1000;
    float currentHealth=1000;

    void Start()
    {
        HealthText.text = "Health " + currentHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            currentHealth = 1000;
            HealthText.text = "Health " + currentHealth.ToString();
        }
        if (GetComponent<CharacterControler>().sliding)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag=="Saw"){
            currentHealth -= 1;
            HealthText.text = "Health " + currentHealth.ToString();
        }
        //Sliding sam stavio privremeno na public
        
    }
}
