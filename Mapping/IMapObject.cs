using DOL.Tools.Mapping.Modules;
namespace DOL.Tools.Mapping.Map
{
    /// <summary>
    /// Object on map
    /// </summary>
    public interface IMapObject
    {
        IModul Modul { get; }

        bool IsMovable { get; }
        bool IsHit(int x, int y);
        int X { get; set; }
        int Y { get; set; }
    }
}