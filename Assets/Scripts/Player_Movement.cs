using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Player_Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;

    public float speed = 10f;
    public float smoothTime = 0.1f;
    float smoothVelocity;

    public Joystick joystick;

    public PhotonView view;

    void Update()
    {
        //if (view.IsMine)
        //{
            float h = joystick.Horizontal;
            float v = joystick.Vertical;
            Vector3 direction = new Vector3(h, 0f, v).normalized;


            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            }
        }
    //}
/*    public void SetJoysticks(GameObject camera)
    {
        Joystick[] tempJoystickList = camera.GetComponentsInChildren<Joystick>();
        foreach (Joystick temp in tempJoystickList)
        {
            if (temp.tag == "Joystick Movement")
                moveStick = temp;
        }

    }*/

}