using UnityEngine;

public class AudioPlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    
    public void PlayStopToggle()
    {
        if(_audioSource.isPlaying)
            _audioSource.Pause();
        else
            _audioSource.Play();
    }

    public void PlayStopToggleAnimation()
    {
        if (_animator.speed == 0)
            _animator.speed = 1;
        else if (_animator.speed == 1)
            _animator.speed = 0;
    }

    public void Play()
    {
        if(_audioSource.isPlaying) return;
        
        _audioSource.Play();
    }

    public void Backward()
    {
        _audioSource.time -= 5;
    }

    public void Forward()
    {
        _audioSource.time += 5;
    }

    public void SetAnimator(Animator animator)
    {
        _animator = animator;
    }
}