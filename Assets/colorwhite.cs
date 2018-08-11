using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorwhite : MonoBehaviour {

    SpriteRenderer m_SpriteRenderer;
    // Use this for initialization
    void Start ()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        m_SpriteRenderer.color = new Color(0.9f, 0.9f, 0.9f, 1f);
    }
}
