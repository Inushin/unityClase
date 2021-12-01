using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPj : MonoBehaviour
{
    public int velocidad;
    private int _velocidad;
    public Vector2 fuerzaSalto;

    private Transform miTransform;
    private Rigidbody2D miRigidbody;
    // Start is called before the first frame update

    //Variables para animaciones
    private bool isGrounded;
    private Animator miAnimator;

    //variables para control de área (pies en el suelo)
    public Transform izquierdaArriba, derechaAbajo;
    public LayerMask plataforma;

    void Start()
    {
        Time.timeScale = 1;
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
        }

        if(Input.GetKey(KeyCode.A))
        {
            _velocidad = -velocidad;
            miTransform.localScale = new Vector3(-1, 1, 1);
        } else if (Input.GetKey(KeyCode.D))
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
        if (_velocidad <0 || _velocidad>0)
        
            miAnimator.SetInteger("velocidad", 1);
        else
            miAnimator.SetInteger("velocidad", 0);

    miAnimator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        if (miRigidbody.velocity.y < 0 || miRigidbody.velocity.y > 0)
            isGrounded = Physics2D.OverlapArea(izquierdaArriba.position, derechaAbajo.position, plataforma);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.Equals("PlataformaMovil"))
        {
            if(GetComponent<SpriteRenderer>().bounds.min.y > collision.transform.position.y)
            {
                miTransform.parent = collision.transform;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("PlataformaMovil"))
        {
            if (GetComponent<SpriteRenderer>().bounds.min.y > collision.transform.position.y)
            {
                miTransform.parent = null;
            }
        }
    }
}
