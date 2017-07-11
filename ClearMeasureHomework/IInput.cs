using System.Collections.Generic;

namespace ClearMeasureHomework
{
    public interface IInput
    {
        List<string> FizzWords { get; set; }
        List<string> BuzzWords { get; set; }
        int Length { get; set; }
    }
}
