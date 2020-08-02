using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 500f;

    public float planeSpeed = 0.1f;
    public float rotateSpeed = 0.03f;
    private float xPos, yPos;

    public Rigidbody rb;
    public float maxSpeed = 50f;

    public Transform topPoint, bottomPoint, leftPoint, rightPoint, topLeftPoint, topRightPoint, bottomLeftPoint, bottomRightPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.up * _yMov;
        Vector3 _moveForward = transform.forward * maxSpeed;

        //Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        rb.MovePosition(rb.position + _velocity * Time.deltaTime);

        /*Vector3 planePos = this.transform.position;
        xPos = 0f;
        yPos = 0f;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //this.transform.Rotate(Vector3.right, -1f);

                //this.transform.Translate(planePos.x, rotateSpeed, planePos.z);
                yPos = rotateSpeed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //this.transform.Translate(planePos.x, -rotateSpeed, planePos.z);
                //this.transform.Rotate(Vector3.right, 1f);

                yPos = -rotateSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //this.transform.Rotate(Vector3.up, 1f);

                //this.transform.Translate(rotateSpeed, planePos.y, planePos.z);
                xPos = rotateSpeed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //this.transform.Rotate(Vector3.up, -1f);

                //this.transform.Translate(-rotateSpeed, planePos.y, planePos.z);
                xPos = -rotateSpeed;
            }
        }


        this.transform.Translate(xPos, yPos, planeSpeed);
        //this.transform.Translate(0, 0, planeSpeed);
        */


        /*if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        rb.AddForce(0, 0, 0.1f, ForceMode.Impulse);
        Debug.Log(rb.velocity.z);
        */
    }

    void OnCollisionEnter(Collision col)
    {
        /*Debug.Log("Çarptı.!!");
        if (col.gameObject.tag == "PipeWall")
        {
            Debug.Log("Duvara Çarptı.!!");
        }*/

        ContactPoint[] contacts = new ContactPoint[10];

        int numContacts = col.GetContacts(contacts);
        for (int i = 0; i < numContacts; i++)
        {
            if (Vector3.Distance(contacts[i].point, topPoint.position) < 1f)
            {
                Debug.Log("Yukarı Çarptı.!!");
                
                rb.MovePosition(rb.position + new Vector3(0f, -5f, 0f));
            }
            if (Vector3.Distance(contacts[i].point, bottomPoint.position) < 1f)
            {
                Debug.Log("Aşağı Çarptı.!!");

                rb.MovePosition(rb.position + new Vector3(0f, 5f, 0f));
            }
            if (Vector3.Distance(contacts[i].point, leftPoint.position) < 1f)
            {
                Debug.Log("Sola Çarptı.!!");

                rb.MovePosition(rb.position + new Vector3(5f, 0f, 0f));
            }
            if (Vector3.Distance(contacts[i].point, rightPoint.position) < 1f)
            {
                Debug.Log("Sağa Çarptı.!!");

                rb.MovePosition(rb.position + new Vector3(-5f, 0f, 0));
            }
            if (Vector3.Distance(contacts[i].point, topLeftPoint.position) < 1f)
            {
                Debug.Log("Sol Üste Çarptı.!!");

                rb.MovePosition(rb.position + new Vector3(2.5f, -2.5f, 0));
            }
            if (Vector3.Distance(contacts[i].point, topRightPoint.position) < 1f)
            {
                Debug.Log("Sağ Üste Çarptı.!!");

                rb.MovePosition(rb.position + new Vector3(-2.5f, -2.5f, 0));
            }
            if (Vector3.Distance(contacts[i].point, bottomLeftPoint.position) < 1f)
            {
                Debug.Log("Sol Alta Çarptı.!!");

                rb.MovePosition(rb.position + new Vector3(2.5f, 2.5f, 0));
            }
            if (Vector3.Distance(contacts[i].point, bottomRightPoint.position) < 1f)
            {
                Debug.Log("Sağ Alta Çarptı.!!");

                rb.MovePosition(rb.position + new Vector3(-2.5f, 2.5f, 0));
            }
        }
    }

        protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
