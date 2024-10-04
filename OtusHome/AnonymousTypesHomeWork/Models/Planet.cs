namespace AnonymousTypesHomework.Models
{
    /// <summary>
    /// Модель планеты.
    /// </summary>
    public class Planet
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Порядковый номер от Солнца.
        /// </summary>
        public short PositionNumberFromTheSun { get; set; }

        /// <summary>
        /// Длина экватора в км.
        /// </summary>
        public int EquatorLength { get; set; }

        /// <summary>
        /// Предыдущая планета.
        /// </summary>
        public Planet? PreviousPlanet { get; set; }
    }
}
