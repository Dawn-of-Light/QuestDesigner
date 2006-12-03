namespace DOL.Tools.Mapping.DX.Meshes
{
    /// <summary>
    /// A abstract Mesh object
    /// Contains a Render mechanism
    /// and a Device
    /// </summary>
    public interface IMesh
    {
        /// <summary>
        /// Render this Mesh
        /// </summary>
        void Render();

        /// <summary>
        /// Delete this object
        /// </summary>
        void Dispose();
    }
}