using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Sprite monsterName;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       BirdController birdController  = collision.gameObject.GetComponent<BirdController>(); //Monoster should only collides by gameobject which is in Birdcontroller.
        if(birdController!= null || collision.gameObject.tag == "Crate") //If bird hits the monster or crate hits the monster, the monster had to die.
        {
            //Destroy(gameObject);
            MonsterDeath();
            //birdController = null;
            if(true)
            {
                birdController = null;
                Debug.Log("No more attacks on this Monster");
                
            }
            
           
        }
       
        

   }
    private void MonsterDeath()
    {
 
        gameObject.SetActive(false);
        Debug.Log("Your monster dead");
        score = score + 1;
        Debug.Log(score);
       

        //gameObject.SetActive(true);




        // Destroy(gameObject);


        //GetComponent<SpriteRenderer>().sprite = monsterName;

    }
   
}
