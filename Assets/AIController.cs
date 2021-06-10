using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
    private Transform[] crates;
    public string objectName;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jetpackForce;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float normalizeRotationSpeed;

    [SerializeField] private float boxLength;
    [SerializeField] private float boxHeight;
    [SerializeField] private Transform groundPosition;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private ParticleSystem jetpackParticle;

    private float moveInput;
    private bool isFlying;

    private Collider2D[] isGrounded = new Collider2D[1];

    private Rigidbody2D rigidbody;

    public Slider slider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isPlayer1)
        {
            moveInput = Input.GetAxis("Horizontal");
            isFlying = Input.GetKey(KeyCode.W);
        }
        else
        {
            moveInput = Input.GetAxis("Horizontalp2");
            isFlying = Input.GetKey(KeyCode.UpArrow);
        } */

        if (rigidbody.velocity.x > 1 && isGrounded[0] && !isFlying)
        {
            gameObject.transform.localScale = new Vector3(7, 7, 1);
        }
        else if (rigidbody.velocity.x < -1 && isGrounded[0] && !isFlying)
        {
            gameObject.transform.localScale = new Vector3(-7, 7, 1);
        } 
    }

    private void FixedUpdate()
    {
        isGrounded[0] = null;
        Physics2D.OverlapBoxNonAlloc(groundPosition.position, new Vector2(boxLength, boxHeight), 0, isGrounded, groundLayer);

        if (isGrounded[0] && !isFlying)
        {
            rigidbody.velocity = new Vector2(moveInput * moveSpeed, rigidbody.velocity.y);
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            rigidbody.freezeRotation = true;
        }
        else if (isFlying)
        {
            Vector3 rotation = new Vector3(0, 0, -moveInput * rotationSpeed);
            transform.Rotate(rotation);
            rigidbody.freezeRotation = false;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * normalizeRotationSpeed);
            rigidbody.AddForce(transform.rotation * Vector2.up * jetpackForce);
        }
        fly();
        
        if (GameObject.FindGameObjectWithTag(objectName) != null)
        {
            //crates[0] = GameObject.FindGameObjectWithTag(objectName).transform.GetChild(0).transform;

            if (GameObject.FindGameObjectWithTag(objectName).transform.GetChild(0).name == "Crate")
            {
                Transform crateO = GameObject.FindGameObjectWithTag(objectName).transform.GetChild(0);
                fly();

                float[] inputs = new float[1];

                float distance = Vector2.Distance(transform.position, crateO.position);
                Debug.Log(distance);

                slider.value = 10-distance;

                //if (distance)
            }
            else
            {
                isFlying = false;
            }

        }
        else
        {
            isFlying = false;
        } 
    }

    private void fly()
    {
        isFlying = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundPosition.position, new Vector2(boxLength, boxHeight));
    }

    public void Init(NeuralNetwork net, Transform target)
    {
        
    }


}
