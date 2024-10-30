using Bogus;
using Cadmus.Mat.Bricks;
using System;

namespace Cadmus.Seed.Epigraphy.Parts;

internal static class SeedHelper
{
    public static PhysicalSize GetSize(Faker f, bool depth = false)
    {
        ArgumentNullException.ThrowIfNull(f);

        PhysicalSize size = new()
        {
            W = new PhysicalDimension
            {
                Value = f.Random.Number(5, 30),
                Unit = "cm"
            },
            H = new PhysicalDimension
            {
                Value = f.Random.Number(5, 30),
                Unit = "cm"
            }
        };
        if (depth)
        {
            size.D = new PhysicalDimension
            {
                Value = f.Random.Number(1, 10),
                Unit = "cm"
            };
        }
        return size;
    }
}
