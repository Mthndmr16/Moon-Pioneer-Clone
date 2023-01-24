using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;  // Target (Player) 
    [SerializeField] private Vector3 offset;   // karakterimiz ile kamera arasindaki mesafeyi belirten degisken  
    [SerializeField] private float cameraFollowSpeed = 5f;

    void Start()
    {
        if (target != null)  // guvenlik onlemi amacli.
        {
            // MoveTheCamera();
            target = GameObject.FindObjectOfType<PlayerMovement>().transform;  // playerMovemment adlý scripte git oradan transform deðiþkenini çek.
        }

      //  offset = DistanceOffset(target); // karakterimiz ile kamera arasindaki mesafeyi baslangicta offset degiskenine aktariyoruz.
    }


    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, cameraFollowSpeed * Time.deltaTime);
    }

}
