using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSausageCollision : MonoBehaviour
{
    public Sausage SausageScript;
    private byte isColliding;

    private void OnCollisionEnter(Collision collision)
    {
        SausageScript.PlusRigCollision();
    }

    private void OnCollisionExit(Collision collision)
    {
        SausageScript.MinusRigCollision();
    }
}
