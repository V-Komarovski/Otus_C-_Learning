using AnonymousTypesHomeWork.Enums;
using AnonymousTypesHomeWork.Models;

namespace AnonymousTypesHomeWork
{
    public class PlanetsCatalog
    {
        // _planets можно было сделать и массивом, 
        // но выглядит так, будто надо оставить возможность редактирования каталога
        private List<Planet> _planets;

        public int GetPlanetByNameCallCount { get; private set; }

        public PlanetsCatalog()
        {
            _planets = PlanetCatalogHelper
                .GeneratePlanetList([SolarSystemPlanets.Venus, SolarSystemPlanets.Earth, SolarSystemPlanets.Mars]);

            if (_planets is null || _planets.Count == 0)
            {
                throw new InvalidOperationException("Ошибка загрузки списка планет в каталог");
            }
        }

        /// <summary>
        /// Возвращает информацию о планете по её названию.
        /// </summary>
        /// <param name="name">Название планеты.</param>
        /// <param name="validator">Валидатор входных данных.</param>
        /// <returns>Данные по планете: порядковый номер от Солнца, длина экватора, текст ошибки.</returns>
        public (short positionNumber, int equatorLength, string? exMessage) GetPlanetByName(string name, Func<string, string> validator)
        {
            GetPlanetByNameCallCount++;
            (short posNumber, int equatorLength, string? exMessage) result = new();

            // Выполняем валидацию перед поиском планеты
            var validationExMessage = validator(name);

            if (!string.IsNullOrEmpty(validationExMessage))
            {
                result.exMessage = validationExMessage;
                return result;
            }

            foreach (var planet in _planets)
            {
                if (planet.Name == name)
                {
                    result.posNumber = planet.PositionNumberFromTheSun;
                    result.equatorLength = planet.EquatorLength;
                }
            }

            if (result.posNumber is 0 || result.equatorLength is 0)
            {
                result.exMessage = "Не удалось найти планету";
            }

            return result;
        }

        /// <summary>
        /// Перегрузка метода GetPlanetByName исключительно для написания программы №2 по ДЗ.
        /// </summary>
        public (short positionNumber, int equatorLength, string? exMessage) GetPlanetByName(string name)
        {
            GetPlanetByNameCallCount++;
            (short posNumber, int equatorLength, string? exMessage) result = new();

            // Выполняем валидацию перед поиском планеты
            if (GetPlanetByNameCallCount % 3 == 0)
            {
                result.exMessage = "Вы спрашиваете слишком часто";
                return result;
            }

            foreach (var planet in _planets)
            {
                if (planet.Name == name)
                {
                    result.posNumber = planet.PositionNumberFromTheSun;
                    result.equatorLength = planet.EquatorLength;
                }
            }

            if (result.posNumber is 0 && result.equatorLength is 0)
            {
                result.exMessage = "Не удалось найти планету";
            }

            return result;
        }
    }
}
