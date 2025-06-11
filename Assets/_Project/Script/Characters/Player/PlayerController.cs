using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Rigidbody2D _rb;
    public Vector2 dir { get; private set; }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float _horizontal = Input.GetAxis($"Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        dir = new Vector2(_horizontal, _vertical).normalized;
        
        _rb.MovePosition(_rb.position + dir * (speed * Time.deltaTime));
    }
}
