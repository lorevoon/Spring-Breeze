
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
        /// Called along with physics updates.
        /// </summary>
        public abstract void StateUpdate();
    }
}
