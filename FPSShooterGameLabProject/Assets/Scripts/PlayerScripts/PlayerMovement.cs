using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    private bool lerpCrouch, crouching, sprinting;
    public float crouchTimer;
    public float x, y, z;
     
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

     
    void Update()
    {
        isGrounded = characterController.isGrounded;
        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching) 
            {
                characterController.height = Mathf.Lerp(characterController.height, 1, p);
            }
            else
            {
                characterController.height = Mathf.Lerp(characterController.height, 2, p);
            }
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }

    public void LoadData(GameData data)
    {

        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {

        data.playerPosition = this.transform.position;

    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;  
        characterController.Move(transform.TransformDirection(moveDirection)*speed*Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) 
        {
            playerVelocity.y = -2f;
        }

        characterController.Move(playerVelocity*Time.deltaTime);
        

    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
    }

     
    private void OnApplicationFocus(bool focus)
    {
        if(focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
     
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    static void OnBeforeSplashScreen()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
