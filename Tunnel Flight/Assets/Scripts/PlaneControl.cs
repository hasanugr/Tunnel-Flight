using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour {
    public GameObject mainPlaneObject;
    private float rotateSpeed = 25f;
    private float thrust = 80f;
    private Rigidbody rb;
    private float minSpeed = 20f;

    // Start is called before the first frame update
    void Start() {
        rb = mainPlaneObject.GetComponent<Rigidbody>();
        // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = rb.transform.right * _xMov;
        Vector3 _movVertical = rb.transform.up * _yMov;

        //Final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * rotateSpeed;

        rb.MovePosition(rb.position + _velocity * Time.deltaTime);

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
        Debug.Log("Touching..");
        if (col.gameObject.tag == "PipeWall") {
            this.rotateSpeed = 5f;
            Debug.Log("Duvara Dokunuyor.!!");
            if (rb.velocity.z > minSpeed) {
                rb.AddForce(-transform.forward * thrust);
            }
           
        }
    }

    private void OnCollisionExit(Collision col) {
        if (col.gameObject.tag == "PipeWall"){
            this.rotateSpeed = 25f;
        }
    }

    protected void LateUpdate() {
        rb.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
