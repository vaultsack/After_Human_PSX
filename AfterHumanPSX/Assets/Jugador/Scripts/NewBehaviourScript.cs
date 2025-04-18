using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento
    public Transform cameraTransform; // Referencia a la cámara

    private CharacterController characterController;

    void Start()
    {
        // Obtener el componente CharacterController
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Capturar entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crear un vector de dirección basado en la entrada
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Calcular el ángulo relativo a la cámara
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            // Rotar el personaje hacia la dirección deseada
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Calcular la dirección final del movimiento
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Mover al personaje
            characterController.Move(moveDirection * speed * Time.deltaTime);
        }
    }
}
