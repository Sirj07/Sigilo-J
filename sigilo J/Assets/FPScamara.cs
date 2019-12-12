using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScamara : MonoBehaviour
{

    string advertencia = "invertirmoviento tambien para mejor funcionamiento boton en esfera"; // se crea una variable tipo string (cadena) la cual tiene un mesaje entre comillas 
    float mouseX; // se definene las variables mousex,mousey como tipo float
	float mouseY;

	public bool invertirmouse=false;// se crea una variable tipo bool(verdadero falso)=falso 

	void Update() //  se  usa la funcion  update  la cual se actuliza constantemente 
	{

        if (invertirmouse == true) // se crea un condicional con el cual si invertir mouse es true cambiara la informacion de  
        {                                       // mouse Y a positiva y de mouse x negativa cual hace que la al usar el mouse hacia esa direcion ira ala contraria
            mouseY += Input.GetAxis("Mouse Y");
            mouseX -= Input.GetAxis("Mouse X");
            Debug.Log("mensaje"+ advertencia); //  imprimira en consola el mensaje del la variable string
        }
		else // si no es true seguira de manera normal el movimiento de mouse 
		{
			mouseY -= Input.GetAxis("Mouse Y"); // (en input.getaxis devuele el valor virtual de mouse )
            mouseX += Input.GetAxis("Mouse X");
        }
        
        
		transform.eulerAngles = new Vector3(mouseY, mouseX, 0); // se modifica la rotacion del objeto en el eje X,Y


		
		if (mouseY >= 20.0f) // se uno un condinal para que la camara no rotara completamente el cual si el si el eje x el mayor igual a 45 devolvera a 45
		{                    // y lo mismo aplica para  arriba
			mouseY = 20.0f;
		}
		if (mouseY <= 0f)
		{
			mouseY = 0f;
		}


	}
}


