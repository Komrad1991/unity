using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpVisualizer : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Text box;
    // Update is called once per frame
    void Update()
    {
        int hp = Player.GetComponent<PlayerHealth>().health;
        box.text = "υο:" + hp;
    }
}
