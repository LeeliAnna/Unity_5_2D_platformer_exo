using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    //[Tooltip("Le sens ne peut avoir comme valeur que 1 ou -1")]
    //[SerializeField] private float sens = 1f;
    [SerializeField] private bool goRight = true;
    private SpriteRenderer spriteRenderer;

    private Vector3 mvt;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // mvt = speed * sens * Time.deltaTime * transform.right;
        // transform.Translate(mvt);
        //transform.Translate(speed * sens * Time.deltaTime, 0f, 0f);
        transform.Translate(speed * (goRight ? 1f : -1f) * Time.deltaTime, 0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            InversSpeed();
        }
    }

    private void InversSpeed()
    {
        goRight = !goRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
