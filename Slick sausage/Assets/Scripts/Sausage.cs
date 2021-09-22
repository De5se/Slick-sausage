using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour
{
    [SerializeField] private float Power = 100;
    [SerializeField] private float maxSpedX = 4f;
    [SerializeField] private float maxSpedY = 10f;
    [SerializeField] private Trajectory trajectory;

    [SerializeField] private List<Rigidbody> rigs = new List<Rigidbody>();

    private bool isDragging;
    [HideInInspector] byte rigsColided = 0;

    private Vector3 startPos;
    private Vector3 endPos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDragging == false && rigsColided > 0)
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

        trajectory.Show(CalculateSpeed());
    }

    private void OnDragEnd()
    {
        isDragging = false;
        Jump();
        trajectory.Hide();
    }

    private void Jump()
    {
        Vector3 velocity = CalculateSpeed();

        for (int i = 0; i < rigs.Count; i++)
            rigs[i].velocity = velocity;
    }

    private Vector3 CalculateSpeed()
    {
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

    public void PlusRigCollision()
    {
        rigsColided++;
    }

    public void MinusRigCollision()
    {
        rigsColided--;
    }
}
