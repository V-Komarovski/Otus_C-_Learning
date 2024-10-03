using AnonymousTypesHomework.Enums;
using AnonymousTypesHomework.Models;

namespace AnonymousTypesHomework
{
    public static class PlanetCatalogHelper
    {
        private static readonly Planet[] _planets;

        static PlanetCatalogHelper()
        {
            var mercury = new Planet { Name = "Меркурий", PositionNumberFromTheSun = (short)SolarSystemPlanets.Mercury, EquatorLength = 15329, PreviousPlanet = null };
            var venus = new Planet { Name = "Венера", PositionNumberFromTheSun = (short)SolarSystemPlanets.Venus, EquatorLength = 38025, PreviousPlanet = mercury };
            var earth = new Planet { Name = "Земля", PositionNumberFromTheSun = (short)SolarSystemPlanets.Earth, EquatorLength = 40075, PreviousPlanet = venus };
            var mars = new Planet { Name = "Марс", PositionNumberFromTheSun = (short)SolarSystemPlanets.Mars, EquatorLength = 21344, PreviousPlanet = earth };

            _planets = [mercury, venus, earth, mars];
        }

        public static List<Planet> GeneratePlanetList(SolarSystemPlanets[] planetNumbers)
        {
            ArgumentNullException.ThrowIfNull(planetNumbers);

            if (planetNumbers.Length is 0)
            {
                throw new ArgumentException("Передан пустой список планет");
            }

            var result = new List<Planet>(planetNumbers.Length);

            foreach (var number in planetNumbers)
            {
                foreach (var planet in _planets)
                {
                    if ((int)number == planet.PositionNumberFromTheSun)
                    {
                        result.Add(planet);
                    }
                }
            }

            return result;
        }
    }
}
