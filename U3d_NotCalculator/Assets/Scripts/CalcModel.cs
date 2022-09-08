using System;
using System.Collections.Generic;

public class CalcModel
{
    private SaveLoad _saveLoad;

    public CalcModel(SaveLoad saveLoad)
    {
        _saveLoad = saveLoad;
    }

    public void Save(string value) =>
        _saveLoad.Save(value);

    public string Load() =>
        _saveLoad.Load();

    public bool TryDivide(string input, out int rezult)
    {
        rezult = 0;

        if (string.IsNullOrWhiteSpace(input))
            return false;

        var parts = input.Split("/");
        if (parts.Length == 0)
            return false;

        var pass = TryGetNumbers(parts, out var numbers);
        if (!pass)
            return false;

        if (numbers.Count > 0)
        {
            rezult = numbers[0];
            for (var i = 1; i < numbers.Count; i++)
            {
                rezult /= numbers[i];
            }
        }

        return true;
    }

    private bool TryGetNumbers(string[] parts, out List<int> arr)
    {
        arr = new List<int>();
        foreach (var part in parts)
        {
            if (int.TryParse(part, out var element) && element >= 0)
                arr.Add(element);
            else
                return false;
        }

        return true;
    }
}