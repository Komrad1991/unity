using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3;
    [SerializeField] public GameObject Player;
    [SerializeField] public LayerMask Spike;
    void Update()
    {

    }
    private void DoDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(Player);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Я почти внутри");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Spike")
        {
            Debug.Log("Я внутри");
            DoDamage();
        }
    }
}
