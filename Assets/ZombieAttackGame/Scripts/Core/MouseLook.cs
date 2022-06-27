using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    bool isFPS = true;
    public Transform playerBody;
    public Transform gun;
    [SerializeField]
    Transform aimPoint;
    [SerializeField]
    Camera playerCamera;
    Gun gunScript;
    // Start is called before the first frame update
    float xRotation = 0f;
    void Start()
    {
        gun.transform.LookAt(aimPoint.position);
        gunScript = gun.gameObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {    
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        if (isFPS)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, gunScript.range))
            {
                if ((gunScript.shootPoint.position - hit.point).magnitude > 1)
                {
                    gun.transform.LookAt(hit.point);
                }
                
            }
            else
            {
                gun.transform.LookAt(aimPoint.position);                
            }


            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            //gun.localRotation = Quaternion.Euler(xRotation, 0, 0);
        }
            
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
