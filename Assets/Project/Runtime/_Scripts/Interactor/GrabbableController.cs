using UnityEngine;

namespace SB.Runtime {
    [RequireComponent(typeof(PlayerSensor))]
    public abstract class GrabbableController : InteractiveInstance
    {
        /// <summary>
        /// Text to be display in the UI that represents the action you can perform while grabbing an object
        /// </summary>
        [SerializeField] private string _interactionAlias;
        private GrabbableState _state;
        private Animator _anim;

        protected override void Awake() {
            base.Awake();

            _anim = GetComponent<Animator>();

            // TODO: Not always the first
            _state = new IdleGbState(this);
        }

        /// <summary>
        /// Modifies the state of the GrabbableController. Should be provided with a new GrabbableState instance.
        /// </summary>
        protected GrabbableState State {
            set {
                _state = value;
            }
        }

        public override bool CanInteract => PlayerController.Instance.Grabbed == null;

        private void FixedUpdate() {
            _state.StateUpdate();
        }

        protected override void OnInteract()
        {
            Debug.Log("Grab");
            PlayerController.Instance.Grabbed = this;
            if (PlayerController.Instance.Grabbed == this) {
                State = new GrabbedGbState(this);
                _anim.SetTrigger("Grab");
            }
        }

        /// <summary>
        /// Called when there is an interaction input.
        /// </summary>
        /// <param name="interaction">Interactive instance to interact with. Can be null.</param>
        public abstract void InteractWith(InteractiveInstance interaction);

        /// <summary>
        /// Called when the object is dropped.
        /// </summary>
        public virtual void Drop() {
            
            _anim.SetTrigger("Drop");
            PlayerController.Instance.Grabbed = null;
            State = new IdleGbState(this);
        }
    }
}