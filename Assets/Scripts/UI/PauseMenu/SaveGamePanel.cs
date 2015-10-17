using UnityEngine;

public class SaveGamePanel : MonoBehaviour
{
    private Animator _animator;

    public bool PanelOpen
    {
        get { return _animator.GetBool("IsOpen"); }
        set { _animator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}

