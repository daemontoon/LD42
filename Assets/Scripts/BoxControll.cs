using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControll : MonoBehaviour {

    public int color;
    GameObject test;
    public bool thrown;
    public bool moving;
    public bool good;
    Rigidbody2D rb2d;
    float interval = 0.5F;
    float nextTime = 0;
    SpriteRenderer m_SpriteRenderer;
    float sinceLastAction;
    public float actionTimeout = 0.2F;



    // Use this for initialization
    void Start ()
    {

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        sinceLastAction = 0F;
        actionTimeout = 0.2F;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextTime)
        {
            if(gameObject.layer == 9)
            {
                m_SpriteRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1f);
                nextTime += interval;
            }
            if (gameObject.layer == 10)
            {
                m_SpriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
                nextTime += interval;

            }

        }
        if (rb2d.velocity == new Vector2(0, 0))
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }

    void LateUpdate()
    {
        if (thrown == true && moving == false && good == false)
        {
            sinceLastAction += Time.deltaTime;
            Debug.Log(sinceLastAction);
            if (sinceLastAction > actionTimeout)
            {
                Debug.Log(sinceLastAction);
                Debug.Log(actionTimeout);
                gameObject.layer = 9;
                thrown = false;
                sinceLastAction = 0;
            }
        }

    }




}
