using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Movimiento : MonoBehaviour {

    float velocidad = 0.3f;
    float mouseX;

    public Animator caminar;


   void Awake()
    {
        caminar.enabled=false;
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.W))
        {
            
            caminar.enabled=true;
            
            transform.position += transform.forward * velocidad;
            
            

        }
         if (Input.GetKeyUp(KeyCode.W))
        {
            
            caminar.enabled=false;

        }
       
       
       
       
       
       
       
       
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * velocidad;
            caminar.enabled=true;

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            
            caminar.enabled=false;

        }
        
        
        
        
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * velocidad;
            caminar.enabled=true;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            
            caminar.enabled=false;

        }
        
        
        
        
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * velocidad;
            caminar.enabled=true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            
            caminar.enabled=false;

        }

       // Debug.Log(mouseX);
        transform.eulerAngles = new Vector3(0, mouseX, 0);


    }
}
