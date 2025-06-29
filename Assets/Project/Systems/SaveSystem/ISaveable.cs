
namespace SB.SaveSystem
{
    public interface ISaveable<T>
    {
        /// <summary>
        /// Handles data to save.
        /// </summary>
        protected T saveData { get; set; }

        /// <summary>
        /// Binds the data to save to a certain instance, this way a save system can have
        /// a direct reference to the data when saving or loading.
        /// </summary>
        /// <param name="saveData">Binded data to save</param>
        public void Bind(ref T saveData)
        {
            if (saveData == null)
            {
                saveData = this.saveData;
            }
            else
            {
                this.saveData = saveData;
            }
        }

        /// <summary>
        /// Must be called during Awake
        /// </summary>
        protected void UpdateData();
    }
}