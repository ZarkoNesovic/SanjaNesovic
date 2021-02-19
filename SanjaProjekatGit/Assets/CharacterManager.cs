using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CharacterManager : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    [SerializeField] Text HealthText;
    [SerializeField] Text Score;



    //float maxHealth = 1000;
    float currentHealth=100;
    float score = 0;

    void Start()
    {
        HealthText.text = "Health " + currentHealth.ToString();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.P))
        {
            currentHealth = 1;
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
        if (currentHealth == 0)
            anim.SetBool("Dead", true);
        }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag=="Saw"){
            if (currentHealth > 0)
            {
                currentHealth -= 1;
            }
            else
            {
                currentHealth = 0;
                
            }
            

            HealthText.text = "Health " + currentHealth.ToString();
        }

        

        
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Collectable")
        {
            score += 10;
        }
        Score.text = "Score " + score.ToString();
    }
}
