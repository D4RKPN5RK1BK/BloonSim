namespace CoreLibrary.Damage
{
    /// <summary>
    /// Интерфейс используемый для сущностей способных наносить урон
    /// </summary>
    public interface IHitable 
    {
        /// <summary>
        /// Обработчик нанесения урона
        /// </summary>
        /// <param name="model">Модель получения урона противника</param>
        public void OnDamageDeal(HurtModel model);
    }
}