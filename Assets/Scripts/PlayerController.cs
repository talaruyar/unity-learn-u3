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
        // a���daki asl�mda Physics.gravity = physics.gravity * gravityModifier; demek ama bir kez ve anlaml� yazmak i�in a�a��daki gib yazd�k
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //a�ap�dakini transform translate gibi d���nebiliriz.
            //ancak burada yapt���m�z g�� uygulayarak konumunu de�i�tirmek
            //ForceMode.Impulse addes force immediately that we want to apply
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    // a�a��daki fonksiyonu da collide etti�inde ground'dadr gibi bir kesinlik eklemek i�in yazdk.
    // yani when player collides with the ground an�.
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
