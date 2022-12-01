using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed = 3f;
    private bool isGrounded;
    private int score;
    [SerializeField]
    private AudioClip destroyClip;
    [SerializeField]
    private AudioClip coinClip;
    private AudioSource AudioS;
    Animator anim;
    [SerializeField]
    ParticleSystem deathParticle;
    [SerializeField]
    TextMeshProUGUI textM;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        /* if (Input.GetButtonDown("Jump"))
         {
             rb.AddForce(Vector3.up * 7f, ForceMode2D.Impulse);
             isGrounded = false;
             anim.SetBool("Jump", true);
         }*/
        textM.text = ("Score: " + score);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
        }
        if (other.transform.CompareTag("Obstacle"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            AudioSource.PlayClipAtPoint(destroyClip, transform.position);
            deathParticle.Play();
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            StartCoroutine(hideMesh(other.gameObject));
            score += 1;
        }
    }




    IEnumerator hideMesh(GameObject other)
    {
        other.SetActive(false);
        AudioSource.PlayClipAtPoint(coinClip, transform.position);
        yield return new WaitForSeconds(5f);
        other.SetActive(true);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * 7f, ForceMode2D.Impulse);
        isGrounded = false;
        anim.SetBool("Jump", true);
    }

}

