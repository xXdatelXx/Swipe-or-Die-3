using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterTeleportView : MonoBehaviour, ICharacterTeleportView
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnStart()
    {
        // фшиу пау рапапам 
    }

    public void OnEnd()
    {
    }
}
