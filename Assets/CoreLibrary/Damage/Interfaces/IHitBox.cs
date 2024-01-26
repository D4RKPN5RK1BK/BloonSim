namespace CoreLibrary.Damage
{
    /// <summary>
    /// Интерфейс используемый для хитбоксов
    /// </summary>
    public interface IHitBox
    {
        /// <summary>
        /// Обработчик нанесения урона
        /// </summary>
        /// <param name="model">Модель получения урона противника</param>
        public void DealDamage(HurtModel model);
    }
}