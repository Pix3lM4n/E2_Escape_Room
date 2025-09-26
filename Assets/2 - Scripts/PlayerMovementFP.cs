using UnityEngine;

public class PlayerMovementFP : MonoBehaviour
{
    #region Variables
    [Header("Mouse Sensitivity")]
    [Tooltip("Controls camera speed")]
    public float mouseSens;

    [Header("Player Speeds")]
    [Tooltip("Controls A D speed")]
    public float horizontalSpeed;
    [Tooltip("COntrols W S speed")]
    public float verticalSpeed;
    [Tooltip("Controls mult of crouch speed. 0.5 is half")]
    public float crouchSpeedMult;
    [Tooltip("Crouch key")]
    public KeyCode crouchKey;
    [Tooltip("Controls mult of run speed")]
    public float runSpeedMult;
    [Tooltip("Run key")]
    public KeyCode runKey;

    [Header("Misc Variables (Test Only)")]
    float horizontalRotation, verticalRotation;
    Transform playerCam;
    Rigidbody playerRB;
    #endregion

    void Awake()
    {
        playerCam = GetComponentInChildren<Camera>().transform;
        playerRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Camera movement
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        //Rotation clamping
        horizontalRotation += mouseX;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90); //Func that limits the value of verticalRotation
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, horizontalRotation, transform.localEulerAngles.z);
        playerCam.localEulerAngles = new Vector3(verticalRotation, playerCam.localEulerAngles.y, playerCam.localEulerAngles.z);

        //Player movement
        float horizontalMove, verticalMove;
        if (Input.GetKey(crouchKey))
        {
            horizontalMove = Input.GetAxis("Horizontal") * horizontalSpeed * crouchSpeedMult * Time.deltaTime;
            verticalMove = Input.GetAxis("Vertical") * verticalSpeed * crouchSpeedMult * Time.deltaTime;
        }
        else if (Input.GetKey(runKey))
        {
            horizontalMove = Input.GetAxis("Horizontal") * horizontalSpeed * runSpeedMult * Time.deltaTime;
            verticalMove = Input.GetAxis("Vertical") * verticalSpeed * runSpeedMult * Time.deltaTime;
        }
        else
        {
            horizontalMove = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
            verticalMove = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        }
            transform.Translate(horizontalMove, 0, verticalMove);
    }
}
