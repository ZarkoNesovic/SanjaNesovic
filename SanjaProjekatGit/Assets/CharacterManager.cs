using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text HealthText;
    

    float maxHealth = 100;
    float currentHealth=100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            currentHealth -= 5;
            HealthText.text = "Health " + currentHealth.ToString();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag=="Saw"){
            currentHealth -= 5;
            HealthText.text = "Health " + currentHealth.ToString();
        }
    }
}
