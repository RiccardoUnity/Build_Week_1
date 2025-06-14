using UnityEngine;
using GSU = GameUtility.GameStaticUtility;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GSU.Player.GetComponent<PlayerController>();
        _animator.SetFloat("Horizontal", 1);
    }

    private void SetAnimation()
    {
        float x = Mathf.Abs(_playerController.Dir.x);
        float y = Mathf.Abs(_playerController.Dir.y);

        //Walk
        if (x != 0 || y != 0)
        {
            _animator.SetBool("IsWalking", true);
            //Left or Right
            if (x > y)
            {
                _animator.SetFloat("Horizontal", (_playerController.Dir.x > 0) ? 1f : -1f);
                _animator.SetFloat("Vertical", 0f);
            }
            //Back or Front
            else
            {
                _animator.SetFloat("Horizontal", 0f);
                _animator.SetFloat("Vertical", (_playerController.Dir.y > 0) ? 1f : -1f);
            }
        }
        //Idle
        else
        {
            _animator.SetBool("IsWalking", false);
            //Fatto così resta impostata l'ultima direzione
        }
    }

    void Update()
    {
        SetAnimation();
    }
}
