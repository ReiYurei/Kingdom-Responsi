using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamageContainer : MonoBehaviour
{
    [SerializeField]GameObject damagePopUp;
    [SerializeField] PlayerController playerController;
    

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.OnDamageEvent += OnDamage;
    }
    public void OnDamage(float attackPower, Color color)
    {
        OnInstantiate(attackPower, color);
    }

    void OnInstantiate(float attackPower, Color color)
    {
        var obj = Instantiate(damagePopUp, this.transform);
        var damageProp = obj.GetComponent<TextMeshPro>();
        damageProp.text = attackPower.ToString();
        damageProp.color = color;
        StartCoroutine("DestroyObject", obj);
    }
    IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        Destroy(obj);
    }
}
