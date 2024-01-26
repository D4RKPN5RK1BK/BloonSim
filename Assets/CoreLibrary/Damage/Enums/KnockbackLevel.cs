using System.ComponentModel;

namespace CoreLibrary.Damage
{
    //TODO: Выпилить или решить в чем прикол
    /// <summary>
    /// Градации силы отбрасывания при нанесении урона
    /// </summary>
    public enum KnockbackLevel
    {
        [Description("Отсутствует")]
        None = 0,

        [Description("Обычный")]
        Regular = 1,

        [Description("Чистый")]
        Pure = 2
    }
}