using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float hspeed;
    //public float vspeed;
    public float jumpForce;
    public float curJumpsForce;
    private Rigidbody rb;
    private Collider coll;
    private bool isFrozen = false;
    private bool isGrounded;
    private bool isJump;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LevelLoader LevelLoader;
    public GameObject skin;
    public GameObject cloth;
    private Material _material;
    private Material _material2;
    private bool is_showing;
    private bool is_hiding;
    private float threshold = 0;
    [Header("show speed")]
    [Range(0, 1f)]
    public float speed_show;
    [Header("hide speed")]
    [Range(0, 1f)]
    public float hide_show;

    private int jumpCount;
    private bool jumpPressed;
    private bool jumpReleased;
    public int jumpsValue;
    static public int DeathNum = 0;
    private Text txtcount;

    private Animator anim;
    //private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        _material = skin.GetComponent<SkinnedMeshRenderer>().material;
        _material2 = cloth.GetComponent<SkinnedMeshRenderer>().material;
        GameObject.Find("save").SendMessage("OnClickLoad");
        txtcount = GameObject.Find("Txt_DeathNum").GetComponent<Text>();
        txtcount.text = DeathNum.ToString();
    }

    void Update()
    {
        if (isFrozen == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && jumpCount > 0)
            {
                jumpPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) && rb.velocity.y > 0)
            {
                jumpReleased = true;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene("Start");
        //}

        if (this.is_showing)
        {
            is_showing = false;
            DeathNum += 1;
            GameObject.Find("save").SendMessage("OnClickSave");
            LevelLoader.LoadThisLevel();
        }

        if (this.is_hiding)
        {
            this.threshold = Mathf.Lerp(this.threshold, 1, Time.deltaTime * this.speed_show);

            if (this.threshold >= (1 - 0.3))
            {
                this.threshold = 1;

                this.is_hiding = false;
                show();
            }
            this._material.SetFloat("_threshold", this.threshold);
            this._material2.SetFloat("_threshold", this.threshold);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);
        
        if (isFrozen == false)
        {
            GroundMovement();
            Jump();
            JumpRelease();
            anim.SetBool("isGround", isGrounded);
            if (rb.velocity.y < -0.01)
            {
                anim.SetBool("isFall", true);
                anim.SetBool("isJump", false);
            }
            else
            {
                anim.SetBool("isFall", false);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0.4f);
            anim.SetBool("isGround", true);
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);
            anim.SetBool("isRun", false);

        }
        
    }

    void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(horizontalMove * hspeed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localEulerAngles = new Vector3(0.0f, horizontalMove * 90, 0.0f);
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            jumpCount = jumpsValue;
            isJump = false;
            anim.SetBool("isJump", false);
            anim.SetBool("isCurJump", false);
        }
        else if(!isJump)
        {
            isJump = true;
            jumpCount = jumpsValue - 1;
        }

        if(jumpPressed && jumpCount>0 && isJump)
        {
            anim.SetBool("isCurJump", true);
            rb.velocity = new Vector3(rb.velocity.x, curJumpsForce);
            jumpCount--;
            jumpPressed = false;
            SoundManager.instance.CurJumpAudio();
        }
        else if (jumpPressed && jumpCount > 0 && isGrounded)
        {
            isJump = true;
            anim.SetBool("isJump", true);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
            SoundManager.instance.JumpAudio();
        }
    }
    void JumpRelease()
    {
        if (jumpReleased)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y*0.45f);
            jumpReleased = false;
        }
    }
    public void show()
    {
        this.is_hiding = false;
        this.threshold = 0.9f;
        
        this._material.SetFloat("_threshold", this.threshold);
        this._material2.SetFloat("_threshold", this.threshold);

        this.is_showing = true;
    }

    public void hide()
    {
        this.is_showing = false;

        this.threshold = 0.1f;

        this._material.SetFloat("_threshold", this.threshold);
        this._material2.SetFloat("_threshold", this.threshold);

        this.is_hiding = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "playerKiller")
        {
            hide();
            //anim.SetBool("isDead", true);
            isFrozen = true;
            SoundManager.instance.DeathAudio();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "warp")
        {
            isFrozen = true;
            SoundManager.instance.TeleAudio();
            LevelLoader.LoadNextLevel();
        }
    }
}


