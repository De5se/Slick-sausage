using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour
{
    [SerializeField] private float Power = 100;
    [SerializeField] private Trajectory trajectory;

    private Rigidbody rigidbody;

    private Camera mainCamera;

    private bool isDragging;
    [SerializeField] private bool isGrounded;

    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        mainCamera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDragging == false && isGrounded == true)
        {
            OnDragStart();
        }
        if (isDragging == true)
        {
            OnDrag();
        }

        if (Input.GetMouseButtonUp(0) && isDragging == true)
        {
            OnDragEnd();
        }
    }

    private void OnDragStart()
    {
        isDragging = true;
        startPos = Input.mousePosition / 100f;

        trajectory.ShowLine();
    }

    private void OnDrag()
    {
        endPos = Input.mousePosition / 100f; 

        trajectory.Show(transform.position, CalculateSpeed());
    }

    private void OnDragEnd()
    {
        isDragging = false;
        Jump();
        trajectory.Hide();
    }

    private void Jump()
    {
        rigidbody.velocity = CalculateSpeed();
    }

    private Vector3 CalculateSpeed()
    {
        float maxSpedX = 4f;
        float maxSpedY = 10f;

        Vector3 speed = (startPos - endPos) * Power;

        if (speed.x > 0)
        {
            speed.x = Mathf.Min(speed.x, maxSpedX);
        }
        else
        {
            speed.x = Mathf.Max(speed.x, -maxSpedX);
        }
        if (speed.y > 0)
        {
            speed.y = Mathf.Min(speed.y, maxSpedY);
        }
        else
        {
            speed.y = Mathf.Max(speed.y, -maxSpedY);
        }

        return speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
