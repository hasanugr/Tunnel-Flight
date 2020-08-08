using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {
    public GameObject planeModelObject;
    private float rotateSpeed = 100f;
    private float rotateLimit = 30;
    private float posChangeSpeed = 25f;
    private float thrust = 80f;
    private Rigidbody rb;
    private Rigidbody planeModelRB;
    private float minSpeed = 20f;

    // Start is called before the first frame update
    void Start() {
        planeModelRB = planeModelObject.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = rb.transform.right * _xMov;
        Vector3 _movVertical = rb.transform.up * _yMov;

        //Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * posChangeSpeed;

        rb.MovePosition(rb.position + _velocity * Time.deltaTime);

        this.RotationControl(_xMov,_yMov);

        if (_xMov == 0 && _yMov == 0 && (rb.velocity.x != 0 || rb.velocity.y != 0)) {
            rb.velocity = new Vector3(0f, 0f, rb.velocity.z);
        }
        // Debug.Log("X_Mov: " + _xMov);
        // Debug.Log("Y_Mov: " + _yMov);
        // Debug.Log(rb.velocity);

    }

    void OnCollisionEnter(Collision col)
    {
        // Debug.Log("Çarptı.!!");
        // if (col.gameObject.tag == "PipeWall")
        // {
        //    Debug.Log("Duvara Çarptı.!!");
        //    rb.AddForce(-transform.forward * thrust);
        // //    rb.MovePosition(new Vector3(-20f, 0f, rb.position.z));
        // }

    }

    private void OnCollisionStay(Collision col) {
        // Debug.Log("Touching..");
        if (col.gameObject.tag == "PipeWall") {
            this.posChangeSpeed = 5f;
            // Debug.Log("Duvara Dokunuyor.!!");
            if (rb.velocity.z > minSpeed) {
                rb.AddForce(-transform.forward * thrust);
            }
           
        }
    }

    private void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "PipeWall"){
            this.posChangeSpeed = 25f;
        }
    }

    protected void LateUpdate() {
        // rb.transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    private void RotationControl (float xMov, float yMov) {
		Debug.Log("X-Mov: "+ xMov);
		Debug.Log("Y-Mov: "+ yMov);
        float vectorZ = xMov * -rotateLimit;
        float vectorX = yMov * -rotateLimit;
        // rb.transform.localEulerAngles = new Vector3(vectorX, 0, vectorZ);
        planeModelObject.transform.rotation = Quaternion.RotateTowards(planeModelObject.transform.rotation, Quaternion.Euler(vectorX, 0, vectorZ), rotateSpeed * Time.deltaTime);
	}
}
