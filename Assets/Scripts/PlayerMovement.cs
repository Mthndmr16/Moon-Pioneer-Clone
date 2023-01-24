using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FloatingJoystick joystick;  // Floating Joystick kullanmamdaki amaç , ekranýn her yerinde hareket algýlamak istemem.
    [SerializeField] private Animator anim;

    [SerializeField] private float movementSpeed;

    void FixedUpdate()   // Karakterimiz için hazýrladýðým basit bir joystick kontrolü
    {     
       rb.velocity = new Vector3(joystick.Horizontal * movementSpeed, rb.velocity.y, joystick.Vertical * movementSpeed); // Cismimin sadece x ve z eksenlerinde hareket yapmasýný istiyorum.

        if (joystick.Horizontal != 0 || joystick.Vertical != 0 )  // eðer oyuncumuz hareket ediyorsa aþaðýdaki kod bloðu aktif oluyor. 
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity); // hareket edilen yöne baksýn
            anim.SetBool("isMoving", true);  // koþma animasyonu etkinleþsin
        }
        else
        {
            anim.SetBool("isMoving", false); // karakterimiz duruyorsa animasyonumuz 'Idle' konumuna gelsin.
        }    
    }
}
