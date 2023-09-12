using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // aþðýdaki aslýmda Physics.gravity = physics.gravity * gravityModifier; demek ama bir kez ve anlamlý yazmak için aþaðýdaki gib yazdýk
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //aþapýdakini transform translate gibi düþünebiliriz.
            //ancak burada yaptýðýmýz güç uygulayarak konumunu deðiþtirmek
            //ForceMode.Impulse addes force immediately that we want to apply
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    // aþaðýdaki fonksiyonu da collide ettiðinde ground'dadr gibi bir kesinlik eklemek için yazdk.
    // yani when player collides with the ground aný.
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
