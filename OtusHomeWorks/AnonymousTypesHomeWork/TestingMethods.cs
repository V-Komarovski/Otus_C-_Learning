using AnonymousTypesHomeWork.Enums;

namespace AnonymousTypesHomeWork
{
    internal static class TestingMethods
    {
        private const string _planetNameHeader = "Название планеты: ";
        private const string _positionNumberHeader = "Порядковый номер от Солнца: ";
        private const string _equatorLengthHeader = "Длина экватора: ";
        private const string _isEqualVenusHeader = "Эквивалента ли Венере: ";
        private const string _separatorLine = "---------------------";

        internal static void ExecuteFirstProgram()
        {
            // Добавил для достоверности
            var mercury = new { Name = "Меркурий", PositionNumberFromTheSun = (short)SolarSystemPlanets.Mercury, EquatorLength = 15329, PreviousPlanet = (object?)null };

            var venus = new { Name = "Венера", PositionNumberFromTheSun = (short)SolarSystemPlanets.Venus, EquatorLength = 38025, PreviousPlanet = mercury };
            var earth = new { Name = "Земля", PositionNumberFromTheSun = (short)SolarSystemPlanets.Earth, EquatorLength = 40075, PreviousPlanet = venus };
            var mars = new { Name = "Марс", PositionNumberFromTheSun = (short)SolarSystemPlanets.Mars, EquatorLength = 21344, PreviousPlanet = earth };
            var secondVenus = new { Name = "Венера", PositionNumberFromTheSun = (short)SolarSystemPlanets.Venus, EquatorLength = 38025, PreviousPlanet = mercury };

            Console.WriteLine(_separatorLine);
            Console.WriteLine(_planetNameHeader + venus.Name);
            Console.WriteLine(_positionNumberHeader + venus.PositionNumberFromTheSun);
            Console.WriteLine($"{_equatorLengthHeader} {venus.EquatorLength} км.");
            Console.WriteLine($"{_isEqualVenusHeader} {(venus.Equals(venus) ? "Да" : "Нет")}");
            Console.WriteLine(_separatorLine);

            Console.WriteLine(_separatorLine);
            Console.WriteLine(_planetNameHeader + earth.Name);
            Console.WriteLine(_positionNumberHeader + earth.PositionNumberFromTheSun);
            Console.WriteLine($"{_equatorLengthHeader} {earth.EquatorLength} км.");
            Console.WriteLine($"{_isEqualVenusHeader} {(earth.Equals(venus) ? "Да" : "Нет")}");
            Console.WriteLine(_separatorLine);

            Console.WriteLine(_separatorLine);
            Console.WriteLine(_planetNameHeader + mars.Name);
            Console.WriteLine(_positionNumberHeader + mars.PositionNumberFromTheSun);
            Console.WriteLine($"{_equatorLengthHeader} {mars.EquatorLength} км.");
            Console.WriteLine($"{_isEqualVenusHeader} {(mars.Equals(venus) ? "Да" : "Нет")}");
            Console.WriteLine(_separatorLine);

            Console.WriteLine(_separatorLine);
            Console.WriteLine(_planetNameHeader + secondVenus.Name);
            Console.WriteLine(_positionNumberHeader + secondVenus.PositionNumberFromTheSun);
            Console.WriteLine($"{_equatorLengthHeader} {secondVenus.EquatorLength} км.");
            Console.WriteLine($"{_isEqualVenusHeader} {(secondVenus.Equals(venus) ? "Да" : "Нет")}");
            Console.WriteLine(_separatorLine);
        }

        internal static void ExecuteSecondProgram()
        {
            var planets = new[] { "Земля", "Лимония", "Марс" };
            var planetsCatalog = new PlanetsCatalog();
            foreach (var planetName in planets)
            {
                var planetInfo = planetsCatalog.GetPlanetByName(planetName);
                PrintPlanetInfo(
                    planetName,
                    planetInfo.positionNumber,
                    planetInfo.equatorLength,
                    planetInfo.exMessage);
            }
        }

        internal static void ExecuteThirdProgram()
        {
            var planets = new[] { "Земля", "Лимония", "Марс" };
            var planetsCatalog = new PlanetsCatalog();
            var validator = (string name) => planetsCatalog.GetPlanetByNameCallCount % 3 == 0
                ? "Вы спрашиваете слишком часто"
                : null;

            Console.WriteLine("Планеты с первым валидатором");

            foreach (var planetName in planets)
            {
                var planetInfo = planetsCatalog.GetPlanetByName(planetName, validator);
                PrintPlanetInfo(
                    planetName,
                    planetInfo.positionNumber,
                    planetInfo.equatorLength,
                    planetInfo.exMessage);
            }

            Console.WriteLine("\nПланеты со вторым валидатором");
            validator = (string name) => name is "Лимония" ? "Это запретная планета" : null;
            foreach (var planetName in planets)
            {
                var planetInfo = planetsCatalog.GetPlanetByName(planetName, validator);
                PrintPlanetInfo(
                    planetName,
                    planetInfo.positionNumber,
                    planetInfo.equatorLength,
                    planetInfo.exMessage);
            }
        }

        private static void PrintPlanetInfo(
            string name,
            short positionNumber,
            int equatorLength,
            string? exMessage)
        {
            Console.WriteLine(_separatorLine);
            if (!string.IsNullOrEmpty(exMessage))
            {
                Console.WriteLine(exMessage);
            }
            else
            {
                Console.WriteLine(_planetNameHeader + name);
                Console.WriteLine(_positionNumberHeader + positionNumber);
                Console.WriteLine($"{_equatorLengthHeader} {equatorLength} км.");
            }
            Console.WriteLine(_separatorLine);
        }
    }
}
