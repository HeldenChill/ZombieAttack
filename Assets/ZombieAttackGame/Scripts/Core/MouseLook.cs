using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    readonly Vector3 TPS_POSITION = new Vector3(0,10f,-8f);
    readonly Vector3 TPS_ROTATION = new Vector3(30f, 0, 0);
    readonly Vector3 FPS_POSITION = new Vector3(0, 0.34f, 0);
    readonly Vector3 FPS_ROTATION = new Vector3(0, 0, 0);
    public float mouseSensitivity = 100f;
    bool isFPS = true;
    public bool IsFPS
    {
        get => isFPS;
        set
        {
            if (value)
            {
                ChangeTypeCameraShooter(TypeShooter.FPS);
            }
            else
            {
                ChangeTypeCameraShooter(TypeShooter.TPS);
            }
        }
    }


    public Transform playerBody;
    public Transform gun;
    [SerializeField]
    Transform aimPoint;
    [SerializeField]
    Camera playerCamera;
    [SerializeField]
    AnimationModule anim;
    Gun gunScript;
    bool isAnimTransition = false;
    // Start is called before the first frame update
    float xRotation = 0f;
    public enum TypeShooter
    {
        FPS = 1,
        TPS = 3
    }
    private void OnEnable()
    {
        anim.UpdateEventAnimationState += UpdateEvent;
    }
    void Start()
    {
        ChangeTypeCameraShooter(TypeShooter.FPS);
        gun.transform.LookAt(aimPoint.position);
        gunScript = gun.gameObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isAnimTransition)
            return;

        if (Input.GetKeyDown(KeyCode.K))
        {
            IsFPS = !IsFPS;
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
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

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, gunScript.range))
            {
                if ((gunScript.shootPoint.position - hit.point).magnitude > 1)
                {
                    gun.transform.LookAt(new Vector3(hit.point.x,gun.transform.position.y,hit.point.z));
                }

            }
            xRotation = Mathf.Clamp(xRotation, 25f, 40f);
        }
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }


    void ChangeTypeCameraShooter(TypeShooter type)
    {
        isAnimTransition = true;
        Time.timeScale = 1f/12;
        if(type == TypeShooter.FPS)
        {        
            anim.SetActive(true);
            anim.Deactivate("isTPS");
            anim.Activate("isFPS");
        }
        else if(type == TypeShooter.TPS)
        {
            anim.SetActive(true);
            anim.Deactivate("isFPS");
            anim.Activate("isTPS");
        }
    }

    private void OnDisable()
    {
        anim.UpdateEventAnimationState -= UpdateEvent;
    }
    void UpdateEvent(string code)
    {
        if(code.IndexOf("EndAnimation") != -1)
        {
            if (code.IndexOf("FPS") != -1)
            {
                isFPS = false;
            }
            else if(code.IndexOf("TPS") != -1)
            {
                isFPS = true;
            }
            isAnimTransition = false;
            Time.timeScale = 1;
            anim.SetActive(false);
        }

    }
}
