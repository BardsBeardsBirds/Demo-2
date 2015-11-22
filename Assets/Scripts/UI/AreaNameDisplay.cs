using UnityEngine;
using UnityEngine.UI;

public class AreaNameDisplay : MonoBehaviour
{
    public static AreaNameDisplay Instance;

    private Animator _animator;
    private Text _areaText;
    private string _name;
    private bool _followUpAnimation = false;

    public void Awake()
    {
        Instance = this;

        _animator = GetComponent<Animator>();
        _areaText = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        if (_followUpAnimation && _areaText.color.a < 0.02f)
        {
            _areaText.text = TextAdjustment.ReplaceUnderscores(_name);
            _animator.SetBool("Display", true);
            _followUpAnimation = false;
        }
    }

    public void DisplayAreaName(string name)
    {
        _areaText.enabled = true;
        _areaText.text = TextAdjustment.ReplaceUnderscores(name);
        _animator.SetBool("Display", true);
    }

    public void EndDisplayAreaName()    // triggered in last frame of the animation
    {
        _areaText.enabled = false;
        _animator.SetBool("Display", false);
    }

    public void RestartAnimation(string name)   //display name while another is being displayed
    {
        _animator.SetBool("Display", false);
        _name = name;
        _followUpAnimation = true;
    }

    public bool IsInAnimation()
    {
        return _animator.GetBool("Display");
    }
}
