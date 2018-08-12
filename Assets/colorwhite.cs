using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorwhite : MonoBehaviour {
    float interval = 0.5F;
    float nextTime = 0;
    SpriteRenderer m_SpriteRenderer;
    // Use this for initialization
    void Start ()
    {

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            m_SpriteRenderer.color = new Color(0.8f, 0.8f, 0.8f, 1f);
            nextTime += interval;

        }
    }
}
