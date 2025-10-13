using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public int total;

    private float movementX;
    private float movementY;
    private Vector3 jump;
    public float jumpforce;

    private bool isGrounded;
    public GameObject ground;

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winText;
    public GameObject capsule;
    public GameObject poweruptext;
    public Material sphere_material;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        jump = new Vector3(0.0f, 1.0f, 0.0f);
        SetCountText();
        winText.SetActive(false);
        capsule.SetActive(false);
        isGrounded = true;
        poweruptext.SetActive(false);
        sphere_material.color = Color.red;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        

        rb.AddForce(movement * speed);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnJump(InputValue jumpValue)
    {
        if (jumpValue.isPressed && isGrounded)
        {
            rb.AddForce(jump * jumpforce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            if (count >= total)
            {
                capsule.SetActive(true);
            }
        }

        if(other.gameObject.CompareTag("Goal"))
        {
            winText.SetActive(true);
            gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("capsule"))
        {
            speed = 10;
            capsule.SetActive(false);
            poweruptext.SetActive(true);
            sphere_material.color = Color.darkBlue;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("DisWall") && speed > 5)
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }

    }
}
