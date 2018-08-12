using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    private PlayerMotor motor;
	

	void Start ()
    {
        motor = GetComponent<PlayerMotor>();
	}
	
	
	void Update ()
    {
        //Detection des mouvements
        float _x = Input.GetAxisRaw("Horizontal");
        float _y = Input.GetAxis("Jump");

        if(_x < 0F)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (_x > 0F)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        // get velocity
        Vector2 _velocity = new Vector2(_x, _y);

        motor.RunAndJump(_velocity);

        //attrapage


    }
}
