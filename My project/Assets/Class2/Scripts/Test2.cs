using UnityEditor;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        // EventManager.Subscribe(Condition.START, EnabledAnimator);
        // EventManager.Subscribe(Condition.PAUSE, DisabledAnimator);
        //

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
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    state = !state;
        //    if (state)
        //    {
        //        EventManager.Publish(Condition.START);
        //    }
        //    else
        //    {
        //        EventManager.Publish(Condition.PAUSE);
        //    }
        //
        //}
    }

    private void OnDisable()
    {
        // EventManager.Unsubsceribe(Condition.START, EnableAnimator);
        // EventManager.Unsubsceribe(Condition.PAUSE, DisableAnimator);

    }


}
