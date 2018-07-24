using Bogus;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Helpers
{
    public static class ShyneesDataFaker
    {
        public static IEnumerable<ShyneeProfile> GetShyneeProfiles()
        {
            Randomizer.Seed = new Random(8675309);
            Random random = new Random();

            var faker = new Faker<ShyneeProfile>()
                .StrictMode(true)
                .RuleFor(s => s.Id, Guid.NewGuid())
                .RuleFor(s => s.Nickname, f => new KeyValuePair<bool, string>(
                    f.Random.Bool(), f.Internet.UserName()))
                .RuleFor(s => s.AvatarUri, f => new KeyValuePair<bool, string>(
                    f.Random.Bool(), f.Internet.Avatar()))
                .RuleFor(s => s.Dob, f => new KeyValuePair<bool, DateTime>(
                    f.Random.Bool(), f.Date.Past()))
                .RuleFor(s => s.Interests, f => new KeyValuePair<bool, string[]>(
                    f.Random.Bool(), f.Random.ArrayElements(f.Lorem.Words(f.Random.Byte()))))
                .RuleFor(s => s.Name, f => new KeyValuePair<bool, string>(
                    f.Random.Bool(), f.Lorem.Word()))
                .RuleFor(s => s.PersonalInfo, f => new KeyValuePair<bool, string>(
                    f.Random.Bool(), f.Lorem.Paragraph()))
                .RuleFor(s => s.Sex, f => new KeyValuePair<bool, Domain.SexType>(
                    f.Random.Bool(), f.PickRandom<Domain.SexType>()));

            return faker.GenerateLazy(random.Next(100));
        }
    }
}
