using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Collider2D collider;

    private bool playerOn;

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<Player>()
    }
}
