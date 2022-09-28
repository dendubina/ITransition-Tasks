using System;
using System.Collections.Generic;
using Bogus;
using Task_6_RandomData.Constants;
using Task_6_RandomData.Models;

namespace Task_6_RandomData.Logic
{
    public static class Generator
    {
        public static IEnumerable<PersonInfo> GetData(Regions region, double mistakesCount, int seed = 0)
        {
            var mistakesMaker = new MistakesMaker(region);

            var persons = new Faker<PersonInfo>(locale: GetLocale(region))
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.FullName, f => f.Name.FullName())
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Region, f => f.Address.State())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.StreetAddress, f => f.Address.StreetAddress());

            if (seed > 0)
            {
                persons.UseSeed(seed);
            }

            persons.FinishWith((f, x) =>
            {
                mistakesMaker.MakeErrors(x, mistakesCount);
            });

            return persons.GenerateForever();
        }

        private static string GetLocale(Regions region)
        {
            switch (region)
            {
                case Regions.Ru:
                    return "ru";
                case Regions.De:
                    return "de";
                default:
                    return "en";
            }
        }
    }
}
