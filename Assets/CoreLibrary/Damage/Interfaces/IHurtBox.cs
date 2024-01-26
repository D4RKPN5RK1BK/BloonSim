namespace CoreLibrary.Damage
{
    /// <summary>
    /// Интерфейс используемый для хартбоксов
    /// </summary>
    public interface IHurtBox
    {
        /// <summary>
        /// Обработчик получения урона
        /// </summary>
        /// <param name="model">Модель нанесения урона противника</param>
        public void ReceiveDamage(HitModel model);
    }
}