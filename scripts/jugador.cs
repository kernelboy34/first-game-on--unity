using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float fuerzasalto;
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    public gamemanager gamem;
    // Start is called before the first frame update
    void Start()
    {
       animator =GetComponent<Animator>();
       rigidbody2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ){
            animator.SetBool("estasaltando",true);
            rigidbody2d.AddForce(new Vector2(0,fuerzasalto));




        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Suelo"){
              animator.SetBool("estasaltando",false);
        }
        if (collision.gameObject.tag == "obstaculo"){
              gamem.gameOver = true ;
        }
    }
}
