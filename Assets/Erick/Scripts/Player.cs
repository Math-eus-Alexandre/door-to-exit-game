using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5f;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
        
        _rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        AtualizarAnim();
    }

    private void Mover()
    
    {
        Vector3 direção = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direção += Vector3.up;
        if (Input.GetKey(KeyCode.S)) direção += Vector3.down;
        if (Input.GetKey(KeyCode.A)) direção += Vector3.left;
        if (Input.GetKey(KeyCode.D)) direção += Vector3.right;

        _rb.velocity = direção.normalized * velocidade;
    }

    private void AtualizarAnim()
    {
        // Velocidades para as animações de direção
        _animator.SetFloat("VelocidadeX", _rb.velocity.x);
        _animator.SetFloat("VelocidadeY", _rb.velocity.y);

        // --- CAMINHANDO ---
        bool andando = _rb.velocity.magnitude > 0.1f;
        _animator.SetBool("Caminhando", andando);

        // --- DIREÇÃO PARA CIMA/BAIXO ---
        bool subindo = Mathf.Abs(_rb.velocity.y) > 0.1f;
        _animator.SetBool("Atualizado", subindo);

        // --- FLIP PARA ESQUERDA/DIREITA ---
        if (_rb.velocity.x > 0.1f)
            _sr.flipX = false;
        else if (_rb.velocity.x < -0.1f)
            _sr.flipX = true;
    }
    
    
}
