using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Player player;

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 2, -9);
    }
}
