using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D _rb;
    public Vector2 Dir { get; private set; }

    void Awake()
    {
        // Assicurati che il Player sia registrato nel GameStaticUtility
        GameUtility.GameStaticUtility.Player = gameObject;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Dir = new Vector2(horizontal, vertical).normalized;
        
        _rb.MovePosition(_rb.position + Dir * (speed * Time.fixedDeltaTime));
    }
}
