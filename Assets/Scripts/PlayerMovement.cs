using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FloatingJoystick joystick;  // Floating Joystick kullanmamdaki ama� , ekran�n her yerinde hareket alg�lamak istemem.
    [SerializeField] private Animator anim;

    [SerializeField] private float movementSpeed;

    void FixedUpdate()   // Karakterimiz i�in haz�rlad���m basit bir joystick kontrol�
    {     
       rb.velocity = new Vector3(joystick.Horizontal * movementSpeed, rb.velocity.y, joystick.Vertical * movementSpeed); // Cismimin sadece x ve z eksenlerinde hareket yapmas�n� istiyorum.

        if (joystick.Horizontal != 0 || joystick.Vertical != 0 )  // e�er oyuncumuz hareket ediyorsa a�a��daki kod blo�u aktif oluyor. 
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity); // hareket edilen y�ne baks�n
            anim.SetBool("isMoving", true);  // ko�ma animasyonu etkinle�sin
        }
        else
        {
            anim.SetBool("isMoving", false); // karakterimiz duruyorsa animasyonumuz 'Idle' konumuna gelsin.
        }    
    }
}
