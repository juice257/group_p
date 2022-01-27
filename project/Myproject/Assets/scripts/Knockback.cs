using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {
    
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player")) {
            other.GetComponent<Pot>().Smash();
        }
        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player")) {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null) {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if(other.gameObject.CompareTag("enemy")) {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }
                if(other.gameObject.CompareTag("Player")) {
                    hit.GetComponent<Movement>().currentState = PlayerState.stagger;
                    other.GetComponent<Movement>().Knock(knockTime);
                }
                
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy) 
    {
        if(enemy != null) {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }
    } 
}
