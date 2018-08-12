using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabscript : MonoBehaviour
{

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform holdpoint;
    public float throwforce;
    public LayerMask notgrabbed;
    SpriteRenderer sprite;
    private Vector2 mousePos;
    private Vector2 direction;

    public BoxControll movingBox;
    public Rigidbody2D ball;
    private Vector2 mouseStartPosition;
    private Vector2 mouseEndPosition;

    public bool didClick;
    public bool didDrag;
    public bool canInteract;
    private float ballVelocityX;
    private float ballVelocityY;
    public float constantSpeed;


    // Use this for initialization
    void Start()
    {
        canInteract = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!grabbed)
        {
            Physics2D.queriesStartInColliders = false;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.x = -(transform.position.x - mousePos.x);
            direction.y = -(transform.position.y - mousePos.y);


            hit = Physics2D.Raycast(transform.position, direction, distance);

            if (hit.collider != null && hit.collider.tag == "grabbable" && hit.collider.gameObject.layer == 9)
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

            }
            
            //grab
        }



        if (Input.GetMouseButtonDown(1))
        {

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, direction, distance);

                if (hit.collider != null && hit.collider.tag == "grabbable" && hit.collider.gameObject.layer == 9)
                {
                    ball = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    grabbed = true;

                }


                //grab
            }
            else if (!Physics2D.OverlapPoint(holdpoint.position, notgrabbed))
            {
                grabbed = false;

                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3) * throwforce;
                }


                //throw
            }


        }

        if (grabbed)
        { 
            hit.collider.gameObject.transform.position = holdpoint.position;

            if(Input.GetMouseButtonDown(0) && canInteract)
            {
                MouseClicked();
            }
            if(Input.GetMouseButton(0) && didClick)
            {
                MouseDragged();
            }
            if (Input.GetMouseButtonUp(0) && canInteract)
            {
                RealeaseMouse();
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }

    public void MouseClicked()
    {
        mouseStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        didClick = true;
    }
    public void MouseDragged()
    {
        didDrag = true;

    }
    public void RealeaseMouse()
    {
        grabbed = false;
        mouseEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ballVelocityX = (mouseStartPosition.x - mouseEndPosition.x)/2;
        ballVelocityY = (mouseStartPosition.y - mouseEndPosition.y)/2;
        Vector2 tempVelocity = new Vector2(ballVelocityX, ballVelocityY).normalized + new Vector2(ballVelocityX, ballVelocityY); //
        ball.velocity = constantSpeed * tempVelocity;
        movingBox = ball.GetComponent<BoxControll>();
        movingBox.thrown = true;
        movingBox.gameObject.layer = 11; 
        didClick = false;
        didDrag = false;

    }
}
