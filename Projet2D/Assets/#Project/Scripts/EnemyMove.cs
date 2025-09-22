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

        Vector3 origin = transform.position + 0.4f * Vector3.up + Vector3.right * 0.4f * (goRight ? 1f : -1f);
        Vector3 direction = Vector3.right * (goRight ? 1f : -1f);
        RaycastHit2D sideHit = Physics2D.Raycast(origin, direction, 0.02f);
        Debug.DrawRay(origin, direction, Color.cyan);

        // Vector3 originDown = transform.position + 1f * Vector3.down;
        // Vector3 directionDown = Vector3.down;
        // RaycastHit2D down = Physics2D.Raycast(originDown, directionDown);
        // if (down.collider == null)
        // {
        //     InversSpeed();
        // }

        origin = transform.position + Vector3.right * 0.4f * (goRight ? 1f : -1f);
        direction = Vector3.down;

        RaycastHit2D bellowHit = Physics2D.Raycast(origin, direction, 1.01f);
        Debug.DrawRay(origin, direction * 1.01f, Color.orange);


        if (sideHit.collider != null|| bellowHit.collider == null)
        {
            InversSpeed();
        }
    }

    /// <summary>
    /// Plus besoin de OnCollisionEnter le raycaste fais le boulot
    /// </summary>
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Obstacle"))
    //     {
    //         InversSpeed();
    //     }
    // }

    private void InversSpeed()
    {
        goRight = !goRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
