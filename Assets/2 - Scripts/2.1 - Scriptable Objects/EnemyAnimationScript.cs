using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim.SetBool("EnemyIdle", true);
    }
    private void Update()
    {
        
    }
}
