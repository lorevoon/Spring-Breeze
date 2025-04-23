using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A Interactor represents a GameObject which can interact with the
/// player's powers/habilities.
/// </summary>
[RequireComponent(typeof(ParticleSystem))]
public abstract class Interactor : MonoBehaviour
{
    // Variables
    [SerializeField] protected EInteraction type;
    
    // Properties
    public EInteraction Type { get => type; }
    
    // Events
    [Header("Events")]
    /// <summary>
    /// OnInteractionStarted is called the first time there is an interaction
    /// </summary>
    [SerializeField] protected UnityEvent onInteractionStarted;
    /// <summary>
    /// OnInteractionPerformed is called every frame there is an interaction
    /// </summary>
    [SerializeField] protected UnityEvent onInteractionPerformed;
    [SerializeField] protected UnityEvent onInteractionCancelled;

    // Properties
    protected abstract bool isInteracting { get; }
    
    /// <summary>
    /// Interact should be called during every frame of the interaction.
    /// </summary>
    /// <param name="type">Type of the interaction</param>
    public abstract void Interact(EInteraction type);
}
