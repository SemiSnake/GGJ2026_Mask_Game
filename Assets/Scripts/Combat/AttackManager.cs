using System;
using UnityEngine;

public class AttackManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public void performAttack (Entity attacker, string targetTag)
    {
        BoxCollider2D attackBoxCollider = attacker.gameObject.transform.Find("AttackBox").GetComponent<BoxCollider2D>();
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        for(int i = 0; i<targets.Length; i++) {
            BoxCollider2D targetHitBox = null;
            try
            {
                targetHitBox = targets[i].GetComponent<BoxCollider2D>();
            } catch(Exception e)
            {
                Debug.Log(e);
            }

            if(targetHitBox != null && attackBoxCollider.IsTouching(targetHitBox))
            {
                CombatManager.HandleDamageInteraction(attacker.attackPattern, targets[i].GetComponent<Entity>());
            }
        }
    }
}
