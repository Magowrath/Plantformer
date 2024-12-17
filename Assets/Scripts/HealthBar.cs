using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private PlayerController player;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;
    // Start is called before the first frame update
    void Start()
    {
        totalhealthbar.fillAmount = player.health * 20;
        Debug.Log(player.health + player.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        currenthealthbar.fillAmount = player.health *20; 
    }
}
