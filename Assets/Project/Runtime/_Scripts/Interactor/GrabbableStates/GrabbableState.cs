
namespace SB.Runtime {
    public abstract class GrabbableState
    {
        /// <summary>
        /// The constructor calls StateStart.
        /// </summary>
        /// <param name="grabbable">Context for the grabbable controller.</param>
        public GrabbableState(GrabbableController grabbable) {
            this.grabbable = grabbable;
            StateStart();
        }

        protected GrabbableController grabbable;

        /// <summary>
        /// Shold be called when the state instance is created.
        /// </summary>
        protected abstract void StateStart();
        
        /// <summary>
        /// Should be called on every frame.
        /// </summary>
        public abstract void StateUpdate();

        /// <summary>
        /// Called when the grabbable object is clicked.
        /// </summary>
        public abstract void OnInteractWith(InteractiveInstance other);
    }
}
