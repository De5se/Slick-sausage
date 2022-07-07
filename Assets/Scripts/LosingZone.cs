using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingZone : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameController.LooseGame();
        }
    }
}
