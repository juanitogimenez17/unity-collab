using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador.
    public float turnSpeed = 100f; // Velocidad de rotación del jugador.

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        TurnPlayer();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal"); // A, D o flechas izquierda y derecha.
        float moveZ = Input.GetAxis("Vertical"); // W, S o flechas arriba y abajo.

        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void TurnPlayer()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
    }
}