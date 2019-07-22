using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    #region PUBLIC_VARS
    public float speed = 10f;
    public float junpForce;
    #endregion
    #region PRIVATE_VARS
    private Rigidbody2D rb;
    float horizontal;
    private Animator anim;
    bool jump = true;
    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        if (!Mathf.Approximately(horizontal, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        }
        if (Input.GetButtonDown("Jump") && !jump)
        {
            rb.AddForce(new Vector2(transform.position.x, junpForce*Time.fixedDeltaTime));
        }
        //Debug.Log(jump);
        //Debug.Log(Mathf.Abs(horizontal));
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        jump = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        jump = false;
    }
}
