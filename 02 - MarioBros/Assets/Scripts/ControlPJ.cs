using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPJ : MonoBehaviour
{
    public int velocidad;
    private int _velocidad;
    public Vector2 fuerzaSalto;

    private Transform miTransform;
    private Rigidbody2D miRigidbody;
        private Animator miAnimator;


    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
        miRigidbody = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        isGrounded = true;
        miAnimator.SetBool("isGrounded", isGrounded);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Acciones();
       UpdateAnimaciones();

        _velocidad = 0;

    }

    private void CheckInput()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && miRigidbody.velocity.y == 0)
        {
            miRigidbody.AddForce(fuerzaSalto, ForceMode2D.Impulse);
            isGrounded = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            miRigidbody.AddForce(fuerzaSalto, ForceMode2D.Impulse);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            _velocidad = -velocidad;
            miTransform.localScale = new Vector3(-1, 1, 1);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            _velocidad = velocidad;
            miTransform.localScale = new Vector3(1, 1, 1);
        }

    }

    private void Acciones()
    {
        miTransform.Translate(Vector3.right * _velocidad * Time.deltaTime);
    }
    private void UpdateAnimaciones()
    {
        if (_velocidad < 0 || _velocidad > 0)

            miAnimator.SetInteger("velocidad", 1);
        else
            miAnimator.SetInteger("velocidad", 0);

        miAnimator.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform)
        {
            isGrounded = true;
        }

        if (collision.transform.tag.Equals("bloque"))
        {
            if(GetComponent<SpriteRenderer>().bounds.min.y < collision.transform.position.y)
            {
                miTransform.parent = collision.transform;
                Debug.Log("Colisiona");
            }
        }
    }
}
