using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string nextLevelName = "Level2";
    
    [Header("Animation")]
    [SerializeField] private Animator animator;
    private bool isOpen = false;
    
    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        
        if (animator != null)
        {
            animator.SetTrigger("Open");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }

    public void OnPortalOpened()
    {
        isOpen = true;
        if (animator != null)
        {
            animator.SetBool("IsOpen", true);
        }
    }
}