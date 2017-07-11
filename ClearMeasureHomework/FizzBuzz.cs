using System;
using System.Collections.Generic;

namespace ClearMeasureHomework
{
    public class FizzBuzz
    {
        public IEnumerable<string> Run(IInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input.Length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Length must be greater than 0.");
            }

            for (var i = 1; i <= input.Length; i++)
            {
                string result;
                if (i % 3 == 0 && i % 5 == 0)
                {

                   result = $"{string.Join(" ", input.FizzWords)} {string.Join(" ", input.BuzzWords)}";
                   yield return result;
                   continue;
                }

                if (i % 3 == 0)
                {
                    result = $"{string.Join(" ", input.FizzWords)}";
                    yield return result;
                    continue;
                }

                if (i % 5 == 0)
                {
                    result = $"{string.Join(" ", input.BuzzWords)}";
                    yield return result;
                    continue;
                }

                result = i.ToString();
                yield return result;
            }
        }
    }    
}
