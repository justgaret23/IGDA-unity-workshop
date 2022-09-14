using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpHeight;
    public float moveSpeedMultiplier;
    private Camera cam;
    private Rigidbody playerRigidbody;
    private bool isGrounded;
    public bool canMove = true;
    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(canMove){
            UpdatePlayerMove();
            PerformPlayerJump();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("grounded");
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider other) {
        switch(other.gameObject.tag){
            case "Sphere":
                GameManager.instance.IncreaseScore(2);
                Destroy(other.gameObject);
                break;

            case "Cylinder":
                GameManager.instance.IncreaseScore(4);
                Destroy(other.gameObject);
                break;

            case "Capsule":
                GameManager.instance.IncreaseScore(6);
                Destroy(other.gameObject);
                break;
        }
    }

    private void UpdatePlayerMove(){
        float vertMovement = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeedMultiplier;
        float horiMovement = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeedMultiplier;

        transform.position += new Vector3(horiMovement, 0, vertMovement);
        /*
        if(Input.GetAxis("Vertical")){
            transform.position += new Vector3(0, 0, moveSpeedMultiplier *  Time.deltaTime);
        }
    
        if(Input.GetKey("s")){
            transform.position += new Vector3(0, 0, -moveSpeedMultiplier * Time.deltaTime);
        }
        
        if(Input.GetKey("a")){
            transform.position += new Vector3(-moveSpeedMultiplier *  Time.deltaTime, 0, 0);
        }
        
        if(Input.GetKey("d")){
            transform.position += new Vector3(moveSpeedMultiplier * Time.deltaTime, 0, 0);
        }
        */
    }

    private void PerformPlayerJump(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && playerRigidbody.velocity.y == 0){
            Debug.Log("Pressed");
            playerRigidbody.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

}
