using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //polja za animacije
    private Animator animator;
    private string currentState;
    private const string idle = "Idle";
    private const string walkUp = "WalkUp";
    private const string walkDown = "WalkDown";
    private const string walkLeft = "WalkLeft";
    private const string walkRight = "WalkRight";

    private float movementSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //kretanje za playera
        //movement speed je polje, konstantna
        /*mnozimo movement speed sa time delta time jer se ova funkcija poziva
         * u razlicitim intervalima u zavisnosti od fpsa igre
        */
        if (Input.GetKey(KeyCode.W))
        {
            //azuriranje kretanja
            Vector3 playerPosition = transform.position;
            playerPosition.y += movementSpeed * Time.deltaTime;
            transform.position = playerPosition;

            //azuriranje animacije
            changeAnimationState(walkUp);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //azuriranje kretanja
            Vector3 playerPosition = transform.position;
            playerPosition.y -= movementSpeed * Time.deltaTime;
            transform.position = playerPosition;

            //azuriranje animacije
            changeAnimationState(walkDown);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //azuriranje kretanja
            Vector3 playerPosition = transform.position;
            playerPosition.x -= movementSpeed * Time.deltaTime;
            transform.position = playerPosition;

            //azuriranje animacije
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                changeAnimationState(walkLeft);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //azuriranje kretanja
            Vector3 playerPosition = transform.position;
            playerPosition.x += movementSpeed * Time.deltaTime;
            transform.position = playerPosition;

            //azuriranje animacije
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            { 
                changeAnimationState(walkRight);
            }
        }

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            //ako se ne pomera igrac animacija idle se pusta
            changeAnimationState(idle);
        }
    }

    private void changeAnimationState(string newState)
    {
        //zaustavlja da trenutna animacija se iznova pokrece
        if (currentState == newState)
        {
            return;
        }
        //pusta novu animaciju 
        animator.Play(newState);
        //azurira trenutnu animaciju da bude nova
        currentState = newState;
    }
}
