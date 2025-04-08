using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Interactor : MonoBehaviour
{
    // Properties
    public EInteraction type;
    public float targetPercent = 10;
    
    // Events
    public event System.Action onInteractionComplete;
    
    // Data
    public SInteractionData data;
    
    // Components
    ParticleSystem particles;
    
    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        DataLoad();
    
        GameManager.Instance.OnSave += DataSave;
    }
    
    // Save System
    public virtual void DataSave()
    {
        SystemSaver.SaveObject(data, gameObject.name + GameManager.Instance.ID);
    }
    public virtual void DataLoad()
    {
        data = (SInteractionData)SystemSaver.LoadObject(data, gameObject.name + GameManager.Instance.ID);
        GameManager.Instance.loaded++;
    }
    
    public virtual void Interact(EInteraction type)
    {
        // Execute only when the type matches
        if (data.interacted || type != this.type)
            return;
    
        // If it's completed then proceed with animation or whatever
        data.interactionPercent += Time.deltaTime;
        if (data.interactionPercent >= targetPercent)
        {
            TransformObject();
        }
    
        // Play particles
        if (!particles.isPlaying)
        {
            particles.Play();
        }
    }
    
    public virtual void TransformObject()
    {
        data.interacted = true;
    
        // Call event
        if(onInteractionComplete != null)
            onInteractionComplete();
    
        DataSave();
    }
}
