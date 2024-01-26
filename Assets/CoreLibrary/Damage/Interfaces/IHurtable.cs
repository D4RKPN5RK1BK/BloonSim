namespace CoreLibrary.Damage
{
    /// <summary>
    /// Интерфейс используемый для сущностей способных получать урон
    /// </summary>
    public interface IHurtable
    {
        /// <summary>
        /// Обработчик получения урона
        /// </summary>
        /// <param name="model">Модель нанесения урона противника</param>
        public void OnDamageReceive(HitModel model);
    }
}