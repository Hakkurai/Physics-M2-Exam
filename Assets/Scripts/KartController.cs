using UnityEngine;
using System.Collections; 

public class KartController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float turnSpeed = 100f;
    public float gravity = 20f;
    public float jumpForce = 10f;
    public Transform kartModel;

    private Vector3 moveDirection;
    private float defaultSpeed;
    private bool isBoosted = false;
    private bool isSpinningOut = false; 
    private float spinOutEndTime;       

    void Start()
    {
        defaultSpeed = speed; 
    }

    void Update()
    {
        if (!isSpinningOut) 
        {
            float moveInput = -Input.GetAxis("Vertical");
            float turnInput = Input.GetAxis("Horizontal");
            
            Vector3 forwardMovement = transform.forward * moveInput * speed;
            
            if (!controller.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            else
            {
                moveDirection.y = -0.1f; 
            }

            
            if (Input.GetKey(KeyCode.Space)) 
            {
                speed = defaultSpeed * 1.2f; 
                turnSpeed = 150f; 
            }
            else
            {
                speed = defaultSpeed;
                turnSpeed = 100f;
            }

            controller.Move((forwardMovement + moveDirection) * Time.deltaTime);  
            transform.Rotate(0, turnInput * turnSpeed * Time.deltaTime, 0);

            
        }
        else if (Time.time >= spinOutEndTime) 
        {
            RecoverFromSpinOut(); 
        }

        bool isMoving = Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f;
        AudioManager.Instance.PlayEngineSFX(isMoving);
        
        AdjustTilt();
    }

    public void Jump(float boost)
    {
        moveDirection.y = boost;
    }

    void AdjustTilt()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            kartModel.rotation = Quaternion.Lerp(kartModel.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    
    public void ApplySpeedBoost(float boost, float duration)
    {
        if (!isBoosted)
        {
            isBoosted = true;
            speed += boost;
            StartCoroutine(ResetSpeed(duration));
        }
    }

    private IEnumerator ResetSpeed(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed; 
        isBoosted = false;
    }

    
    public void SpinOut(float spinOutForce, float duration)
    {
        if (!isSpinningOut)
        {
            isSpinningOut = true;
            spinOutEndTime = Time.time + duration;
            speed = 0;  
            controller.Move(Vector3.zero); 

            StartCoroutine(SpinCoroutine(spinOutForce, duration));
        }
    }

    
    private IEnumerator SpinCoroutine(float spinOutForce, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            transform.Rotate(0, spinOutForce * Time.deltaTime, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    
    private void RecoverFromSpinOut()
    {
        isSpinningOut = false;
        speed = defaultSpeed;            
        moveDirection = Vector3.zero;    
    }
}
