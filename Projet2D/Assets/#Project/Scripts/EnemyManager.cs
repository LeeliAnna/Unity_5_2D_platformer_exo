using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float speed;
    private SpriteRenderer flip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveZ();
    }

    private void MoveZ()
    {
        if (flip.flipX == false)
        {
            transform.position += speed * Time.deltaTime * -transform.right;
        }
        else
        {
            transform.position += speed * Time.deltaTime * transform.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flip.flipX == false)
        {
            flip.flipX = true;
        }
        else
        {
            flip.flipX = false;
        }
    }
}
