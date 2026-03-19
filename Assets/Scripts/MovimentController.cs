using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class MovimentController : NetworkBehaviour
{
    public CharacterController characterController;
    public float velocidade = 50f;
    public Animator animator;

    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float verical = Input.GetAxis("Vertical");

            Vector3 direcao = new Vector3(horizontal, 0, verical);
            if (direcao.magnitude > 0.1f)
            {
                //movimento do personagem
                characterController.Move(direcao * velocidade * Runner.DeltaTime);
                //rotacao do perspnage,
                transform.rotation = Quaternion.LookRotation(direcao);

                animator.SetBool("podeAndar", true);
            }
            else
            {
                animator.SetBool("podeAndar", false);
            }
        }
    }
}
