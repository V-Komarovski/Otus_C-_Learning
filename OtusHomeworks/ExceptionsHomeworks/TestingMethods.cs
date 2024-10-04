using ExceptionsHomework.Common;
using System.Collections;

namespace ExceptionsHomework
{
    internal static class TestingMethods
    {
        public static void ExecuteProgram()
        {
            Console.WriteLine("Программа для решения уравнений типа: a * x^2 + b * x + c = 0");
            TryEvaluateEquationRoots();
        }

        private static void TryEvaluateEquationRoots()
        {
            ExceptionsHomeworkHelper.ResetConsoleColorSettings();
            Console.WriteLine();

            var coefficientsCount = 3;
            var coefficients = new Dictionary<char, string?>(coefficientsCount);
            try
            {
                coefficients.FillEquationCoefficients(coefficientsCount);
                var parsedCoefficients = ParseEquationCoefficients(coefficients);
                var roots = EvaluateRoots(
                    parsedCoefficients[0],
                    parsedCoefficients[1],
                    parsedCoefficients[2]);

                if (roots.Count is 0 or > 2)
                {
                    throw new Exception("Ошибка получения корней квадратного уравнения");
                }
                else if (roots.Count is 1)
                {
                    Console.WriteLine($"x = {roots[0]}");
                }
                else
                {
                    for (var i = 0; i < roots.Count; i++)
                    {
                        Console.WriteLine($"x{i + 1} = {roots[i]}");
                    }
                }
            }
            catch (CoefficientsValidationException validationException)
            {
                ExceptionsHomeworkHelper.FormatData(validationException.Message, Severity.Error, coefficients);
                TryEvaluateEquationRoots();
            }
            catch (NegativeDiscriminantException negativeDiscriminantException)
            {
                ExceptionsHomeworkHelper.FormatData(negativeDiscriminantException.Message, Severity.Warning, coefficients);
            }
            catch (Exception ex)
            {
                ExceptionsHomeworkHelper.FormatData(ex.Message, Severity.Error, coefficients);
            }
        }

        private static IDictionary FillEquationCoefficients(this IDictionary coefficients, int coefficientsCount)
        {
            var firstCoefficientName = ExceptionsHomeworkHelper.FirstEquationCoefficientName;
            var lastCoefficientName = firstCoefficientName + coefficientsCount;
            for (var i = firstCoefficientName; i < lastCoefficientName; i++)
            {
                Console.Write($"Введите значение {i}: ");
                var coefficient = Console.ReadLine();
                coefficients.Add(i, coefficient);
            }

            return coefficients;
        }

        private static List<double> EvaluateRoots(int a, int b, int c)
        {
            var roots = new List<double>(2);
            try
            {
                var discriminant = Math.Pow(b, 2) - 4 * a * c;
                if (discriminant < 0)
                {
                    throw new NegativeDiscriminantException("Вещественных значений не найдено");
                }
                else if (discriminant is 0)
                {
                    roots.Add(-b / (2 * a));
                }
                else
                {
                    roots.Add((-b + Math.Sqrt(discriminant)) / (2 * a));
                    roots.Add((-b - Math.Sqrt(discriminant)) / (2 * a));
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return roots;
        }

        private static int[] ParseEquationCoefficients(IDictionary coefficients)
        {
            var result = new int[coefficients.Count];
            var errorsCoefficientNames = new List<char>(coefficients.Count);
            var firstCoefficientName = ExceptionsHomeworkHelper.FirstEquationCoefficientName;
            var lastCoefficientName = firstCoefficientName + coefficients.Count;
            for (var i = firstCoefficientName; i < lastCoefficientName; i++)
            {
                var isParsing = int.TryParse(coefficients[i] as string, out var parsedCoefficient);
                if (isParsing)
                {
                    result[i - firstCoefficientName] = parsedCoefficient;
                }
                else
                {
                    errorsCoefficientNames.Add(i);
                }
            }

            if (errorsCoefficientNames.Count > 0)
            {
                var end = errorsCoefficientNames.Count is 1 ? "а" : "ов";
                throw new CoefficientsValidationException($"Неверный формат параметр{end}: {string.Join(", ", errorsCoefficientNames)}");
            }

            return result;
        }
    }
}
