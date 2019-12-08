using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Vector3 touchPosition;
    private Vector3 direction;
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    
    private Text plusText;  
    private GameManager gm;
    private AudioManager am;
    private GameObject canvas;
    private bool isMoving;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();       
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);          
            rb.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;
            isMoving = true;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
                isMoving = false;
            }

            if (rb.velocity.magnitude >= 0.2 && !AudioManager.instance.isPlaying)
            {
                AudioManager.instance.Play("SpaceSound");

            }
            else if(rb.velocity.magnitude < 0.2)
            {
                AudioManager.instance.Stop("SpaceSound");
            }

        }

        if(Input.GetMouseButton(1))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;
            direction = (mousePosition - transform.position);
            if (!Input.GetButton("Stop"))
            {
                rb.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;
                isMoving = true;
            }
            else
            {
                rb.velocity = Vector2.zero;
                Debug.Log(rb.velocity);
                isMoving = false;
            }

            if (rb.velocity.magnitude >= 0.2 && !AudioManager.instance.isPlaying)
            {
                AudioManager.instance.Play("SpaceSound");

            }
            else if (rb.velocity.magnitude < 0.2)
            {
                AudioManager.instance.Stop("SpaceSound");
            }
        }
        transform.up = direction;
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gem"))
        {
            if(collision.gameObject.name == "GemYellow(Clone)")
            {
                gm.gem += 1;
                gm.plusDisplay = 1;
                gm.GemPicked();
            }
                              
            else if(collision.gameObject.name == "GemBlue(Clone)")
            {
                gm.gem += 5;
                gm.plusDisplay = 5;
                gm.GemPicked();
            }
            
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("GemCollected");


        }
    }

}
