using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 birdStartPosition;
    public float maximumDragDistance;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }
    // Start is called before the first frame update

    void Start()
    {
        rb.isKinematic = true; //To float the bird in the air - it controlls by ourselves.
        //birdStartPosition = transform.position; //It is the vector3 value so, we don't use it.
        birdStartPosition = rb.position; //Vector2 position of the player.


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnMouseUp()
    {
       
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 currentPosition = rb.position;
        Vector2 direction = birdStartPosition - currentPosition;
        direction.Normalize();
        rb.isKinematic = false; //whenever the release the mouse should be active.
        rb.AddForce(direction * 500f);
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Mouse position into World point to refer that into world coordinates.
        Vector2 desiredPosition = mousePosition; //Limiting the value that bird should be.
        if(desiredPosition.x > birdStartPosition.x)
        {
            desiredPosition.x = birdStartPosition.x;
        }
        //transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); //Assigning that mouse position to new position to the bird.
       
        float distance = Vector2.Distance(desiredPosition, birdStartPosition);
      
        if(distance > maximumDragDistance)
        {
            Vector2 direction = desiredPosition - birdStartPosition;
            direction.Normalize();
            desiredPosition = birdStartPosition + (direction * maximumDragDistance);
        }
        rb.position = desiredPosition;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
        StartCoroutine(ResetAfterDelay()); //After collision we are stoping the bird for some frame of seconds.
       
         
    }
    
    IEnumerator ResetAfterDelay()
    {
       
        yield return new WaitForSeconds(5f);
        Debug.Log("Its in a Coroutine function");
        rb.position = birdStartPosition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero; //After hitting it's moves forward, we want it to original position.


    }
}
