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
        public Animator Anim { get; private set; }

        protected override void Awake() {
            Anim = GetComponent<Animator>();

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

        public override bool CanInteract => PlayerController.Instance.Grabbed == this;

        void FixedUpdate() {
            _state.StateUpdate();
        }

        protected override void OnInteract()
        {
            PlayerController.Instance.Grabbed = this;
            if (PlayerController.Instance.Grabbed == this) {
                State = new GrabbedGbState(this);
            }
        }

        /// <summary>
        /// Interacts with an InteractiveInstance
        /// </summary>
        /// <param name="interaction">Interactive instance to interact with</param>
        public abstract void InteractWith(InteractiveInstance interaction);

        /// <summary>
        /// Called when the object is dropped.
        /// </summary>
        public virtual void OnDrop() {
            State = new IdleGbState(this);
        }

        
    }
}