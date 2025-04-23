using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An interactor task represents a task which needs to be completed using
/// the player's powers/habilities
/// </summary>
public class InteractorTask : Interactor
{
    // Events
    /// <summary>
    /// OnInteractionComplete is called once the interaction is completed
    /// </summary>
    [SerializeField] private UnityEvent onInteractionComplete;

    [SerializeField] private float _targetTime = 10;

    // Components
    ParticleSystem particles;

    // Data
    protected SInteractionTaskData data;

    protected override bool isInteracting { get => data.interactionTime == 0; } 

    void Start()
    {
        particles = GetComponent<ParticleSystem>();

        // TODO: Refactor this
        DataLoad();
        GameManager.Instance.OnSave += DataSave;
    }

    // Save System
    // TODO: Refactor this
    public void DataSave()
    {
        SystemSaver.SaveObject(data, gameObject.name + GameManager.Instance.ID);
    }
    public void DataLoad()
    {
        data = (SInteractionTaskData)SystemSaver.LoadObject(data, gameObject.name + GameManager.Instance.ID);
        GameManager.Instance.loaded++;
    }

    public override void Interact(EInteraction type)
    {
        // Execute only when the type matches
        if (data.interacted || type != this.type)
            return;

        // Check if it's the first interaction
        if (data.interactionTime == 0) {
            onInteractionStarted?.Invoke();
        }
    
        // If it's completed then Stop interaction
        data.interactionTime += Time.deltaTime;
        if (data.interactionTime >= _targetTime)
        {
            CompleteInteraction();
        }
    
        // Play interaction particles
        if (!particles.isPlaying)
        {
            particles.Play();
        }

        // Call other actions
        onInteractionPerformed?.Invoke();
    }

    private void CompleteInteraction()
    {
        data.interacted = true;
    
        // Call event
        onInteractionComplete?.Invoke();
    
        // TODO: Refactor this
        DataSave();
    }
}
