using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField][Range(0f, 20f)] float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Transform head;

    private float horizontal;
    private float vertical;
    private Vector2 direction;
    private Animator anim;


    // GAME //-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-/-
    void Awake()
    { 
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        anim.SetFloat("hSpeed", horizontal);
        anim.SetFloat("vSpeed", vertical);
    }

    private void FixedUpdate()
    {
        direction = new Vector2(horizontal, vertical);

        // NORMALIZZAZIONE DEL VETTORE //
        float mag = direction.magnitude;
        if (mag > 1f)
        { direction /= mag; }

        rb.velocity = direction * speed;
    }
}