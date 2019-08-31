using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    #region PUBLIC_VARS
    public float speed = 10f;
    public float junpForce;
    public TextMeshProUGUI PlayerName;
    public GameObject TeleportButton;
    //public GameObject PlayerNameGameObject;

    #endregion
    #region PRIVATE_VARS
    private Rigidbody2D rb;
    float horizontal;
    float vertical;
    private Animator anim;
    bool jump = true;
    PlayerClass mPlayer;
    SpriteRenderer spriteRenderer;
    GameObject teleportPointObject;

    #endregion
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        CreateUser();
        
    }
    void CreateUser()
    {
        if(mPlayer == null)
        {
            mPlayer = new PlayerClass();
            mPlayer.id = 0;
            mPlayer.name = "John";
            PlayerName.text = mPlayer.name;
            string json = JsonUtility.ToJson(mPlayer);
        }
    }
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(horizontal)+Mathf.Abs(vertical));
        //if (!Mathf.Approximately(horizontal, 0))
        //{
        //    //transform.localScale = new Vector3(Mathf.Sign(horizontal), 1, 1);
        //}
        CheckRotation();
        if (Input.GetButtonDown("Jump") && !jump)
        {
            rb.AddForce(new Vector2(transform.position.x, junpForce));
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Blackout(false));
        }

    }
    void CheckRotation()
    {
        if (horizontal > 0)
        {   
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

    }
    IEnumerator Blackout(bool inverse)
    {
        Material tempMaterial = Camera.main.GetComponentInChildren<Renderer>().material;
        Color tempColor = tempMaterial.GetColor("_Color");
        if (!inverse)
        {
            while (tempColor.a < 1f)
            {
                yield return new WaitForEndOfFrame();
                tempColor.a = tempColor.a + 0.04f;
                tempMaterial.SetColor("_Color", tempColor);
            }
        }
        else if (inverse)
        {
            while (tempColor.a > 0f)
            {
                yield return new WaitForEndOfFrame();
                tempColor.a = tempColor.a - 0.01f;
                tempMaterial.SetColor("_Color", tempColor);
            }
        }
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        //vertical = Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            TeleportButton.SetActive(true);
            teleportPointObject = collision.gameObject;
            Debug.Log("door");
        }
    }
    public void black()
    {
        StartCoroutine(Blackout(false));
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            TeleportButton.SetActive(false);
        }
    }

    public void CallTimeTimer()
    {

    }
    public void Teleport()
    {
        teleportPointObject.GetComponent<DoorScript>().TeleportObject(this.gameObject);
    }
}
