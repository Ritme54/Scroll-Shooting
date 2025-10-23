using UnityEditor;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool state = true;

    private void OnEnable()
    {
        EventManager.Subscribe(Condition.START, EnableAnimator);
        EventManager.Subscribe(Condition.PAUSE, DisableAnimator);


    }

    public void EnableAnimator()
    {
        animator.enabled = true;
    }
    public void DisableAnimator()
    {
        animator.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = !state;
            if (state)
            {
                EventManager.Publish(Condition.START);
            }
            else
            {
                EventManager.Publish(Condition.PAUSE);
            }

        }
    }

    private void OnDisable()
    {
        EventManager.Unsubscribe(Condition.START, EnableAnimator);
        EventManager.Unsubscribe(Condition.PAUSE, DisableAnimator);

    }


}
