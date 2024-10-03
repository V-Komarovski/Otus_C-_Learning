using AnonymousTypesHomework.Enums;

namespace AnonymousTypesHomework
{
    internal static class TestingMethods
    {
        private const string PlanetNameHeader = "Название планеты: ";
        private const string PositionNumberHeader = "Порядковый номер от Солнца: ";
        private const string EquatorLengthHeader = "Длина экватора: ";
        private const string IsEqualVenusHeader = "Эквивалента ли Венере: ";
        private const string SeparatorLine = "---------------------";

        internal static void ExecuteFirstProgram()
        {
            // Добавил для достоверности
            var mercury = new { Name = "Меркурий", PositionNumberFromTheSun = (short)SolarSystemPlanets.Mercury, EquatorLength = 15329, PreviousPlanet = (object?)null };

            var venus = new { Name = "Венера", PositionNumberFromTheSun = (short)SolarSystemPlanets.Venus, EquatorLength = 38025, PreviousPlanet = mercury };
            var earth = new { Name = "Земля", PositionNumberFromTheSun = (short)SolarSystemPlanets.Earth, EquatorLength = 40075, PreviousPlanet = venus };
            var mars = new { Name = "Марс", PositionNumberFromTheSun = (short)SolarSystemPlanets.Mars, EquatorLength = 21344, PreviousPlanet = earth };
            var secondVenus = new { Name = "Венера", PositionNumberFromTheSun = (short)SolarSystemPlanets.Venus, EquatorLength = 38025, PreviousPlanet = mercury };

            PrintPlanetInfo(venus.Name, venus.PositionNumberFromTheSun, venus.EquatorLength, null, venus.Equals(venus));
            PrintPlanetInfo(earth.Name, earth.PositionNumberFromTheSun, earth.EquatorLength, null, earth.Equals(venus));
            PrintPlanetInfo(mars.Name, mars.PositionNumberFromTheSun, mars.EquatorLength, null, mars.Equals(venus));
            PrintPlanetInfo(secondVenus.Name, secondVenus.PositionNumberFromTheSun, secondVenus.EquatorLength, null, secondVenus.Equals(venus));
        }

        internal static void ExecuteSecondProgram()
        {
            var planets = new[] { "Земля", "Лимония", "Марс" };
            var planetsCatalog = new PlanetsCatalog();
            Func<string, (short, int, string?)> method = planetsCatalog.GetPlanetByName;
            CallPlanetsCatalogMethod(
                planets,
                planetsCatalog,
                method);
        }

        internal static void ExecuteThirdProgram()
        {
            var planets = new[] { "Земля", "Лимония", "Марс" };
            var planetsCatalog = new PlanetsCatalog();

            Console.WriteLine("Планеты с первым валидатором");
            var validator = (string name) => planetsCatalog.GetPlanetByNameCallCount % 3 == 0
                ? "Вы спрашиваете слишком часто"
                : null;
            Func<string, (short, int, string?)> method = (string name) => planetsCatalog.GetPlanetByName(name, validator);
            CallPlanetsCatalogMethod(planets, planetsCatalog, method);

            Console.WriteLine("\nПланеты со вторым валидатором");
            validator = (string name) => name is "Лимония" ? "Это запретная планета" : null;
            CallPlanetsCatalogMethod(planets, planetsCatalog, method);
        }

        private static void CallPlanetsCatalogMethod(
            string[] planetNames,
            PlanetsCatalog catalog,
            Func<string, (short positionNumber, int equatorLength, string? exMessage)> callingMethod)
        {
            foreach (var planetName in planetNames)
            {
                var planetInfo = callingMethod(planetName);
                PrintPlanetInfo(
                    planetName,
                    planetInfo.positionNumber,
                    planetInfo.equatorLength,
                    planetInfo.exMessage);
            }
        }

        private static void PrintPlanetInfo(string name, short positionNumber, int equatorLength, string? exMessage)
            => PrintPlanetInfo(name, positionNumber, equatorLength, exMessage, null);

        private static void PrintPlanetInfo(
            string name,
            short positionNumber,
            int equatorLength,
            string? exMessage,
            bool? IsEqualVenus)
        {
            Console.WriteLine(SeparatorLine);
            if (!string.IsNullOrEmpty(exMessage))
            {
                Console.WriteLine(exMessage);
            }
            else
            {
                Console.WriteLine(PlanetNameHeader + name);
                Console.WriteLine(PositionNumberHeader + positionNumber);
                Console.WriteLine($"{EquatorLengthHeader} {equatorLength} км.");
                if (IsEqualVenus is not null)
                    Console.WriteLine($"{IsEqualVenusHeader} {(IsEqualVenus.Value ? "Да" : "Нет")}");
            }
            Console.WriteLine(SeparatorLine);
        }
    }
}