using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float jumpForce = 0.0f;
    [SerializeField] private int jumpHeight = 10;
    [SerializeField] private float Speed;
    [SerializeField] Animator anim;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public Button PauseButton;

    private int desiredLane = 1;//0 :left, 1 :middle, 2 :right
    public float laneDistance = 2.5f;//the distance between two lanes

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        anim.SetBool("IsGameStart", true);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f) ;
    }
    // Update is called once per frame
    private void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }
        
        anim.SetBool("IsGameStart", true);


        Vector3 pos = gameObject.transform.position;
        float tempSpeed = Speed * Time.deltaTime;

        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        move *= tempSpeed;

        if (SwipeManager.swipeUp)
        {
            jumpForce = jumpHeight;
        }
        
        Vector3 power = new Vector3(move.x , jumpForce, move.y);

        if (rb.velocity.magnitude <= (tempSpeed * tempSpeed)) //???????
        {
            rb.AddForce(power, ForceMode.Impulse);

            //This line is to make grounding speed higher than lifting speed
            Physics.gravity = new Vector3(0, -5 * 9.81f, 0);
        }

        pos.z += move.y;
        pos.x += move.x;

        gameObject.transform.position = pos;
        //Assign new coordintes to the existing game object to see the change

        if (move != Vector2.zero)
        {
            anim.SetFloat("Speed", 10);
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        jumpForce = 0;

        //we need to gather the inputs on which lane we should be

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }
        //calculate where should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up ;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //to add smoothnes
        transform.position = Vector3.Lerp(transform.position ,targetPosition ,80f * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            PauseButton.gameObject.SetActive(false);

            FindObjectOfType<AudioManager>().StopSound("MainTheme");

            FindObjectOfType<AudioManager>().PlaySound("GameOver");
     
            PlayerManager.gameOver = true;

            
        }

    }
}
