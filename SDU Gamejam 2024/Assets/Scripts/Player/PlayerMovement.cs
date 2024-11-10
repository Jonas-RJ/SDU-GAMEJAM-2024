using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public HealthController hc;

    [SerializeField] float m_MoveSpeed;
    [SerializeField] float m_RotateSpeed;

    private Rigidbody2D m_rb;

    private Vector2 m_MovementInput;
    private Vector2 m_SmoothedMovementInput;
    private Vector2 m_SmoothMoveVelocity;
    // Start is called before the first frame update


    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //kalder funktionerne der styrer velocity og rotation :)
        SetPlayerVelocity();
        RotateWithInput();
    }

    private void SetPlayerVelocity()
    {
        // laver en smoothened vector som gør movement bedre og markant mindre jank.
        //vektoren starter ved nul, og øges gradvist
        m_SmoothedMovementInput = Vector2.SmoothDamp(m_SmoothedMovementInput, m_MovementInput, ref m_SmoothMoveVelocity, 0.1f);

        //sætter velocity med smoothened vectormovement og med MoveSpeed variabel. 
        m_rb.velocity = m_SmoothedMovementInput * m_MoveSpeed;
    }

    private void RotateWithInput()
    {
        // if - hvis man er i bevægelse. basically hvis en vektor ikke er 0.
        if (m_MovementInput != Vector2.zero)
        {

            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, m_SmoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, m_RotateSpeed * Time.deltaTime);


            m_rb.MoveRotation(rotation);

        }
    }

    private void OnMove(InputValue inputValue)
    {
        m_MovementInput = inputValue.Get<Vector2>();

    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.CompareTag("EnemyBullet"))
        {
            print("damage taken");
            hc.takeDamage(2);
        }
    }
}
