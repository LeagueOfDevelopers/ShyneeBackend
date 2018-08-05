using Bogus;
using ShyneeBackend.Domain;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Helpers
{
    public static class ShyneesDataFaker
    {
        private static Faker<ShyneeCoordinates> FakeShyneeCoordinates()
        {
            return new Faker<ShyneeCoordinates>()
                .CustomInstantiator(f => new ShyneeCoordinates(
                    f.Address.Latitude(),
                    f.Address.Longitude())
                );
        }

        private static Faker<ShyneeCredentials> FakeShyneeCredentials()
        {
            return new Faker<ShyneeCredentials>()
                .CustomInstantiator(f => new ShyneeCredentials(
                    f.Internet.Email(),
                    f.Internet.Password())
                );
        }

        private static Faker<ShyneeReadySettings> FakeShyneeReadySettings()
        {
            return new Faker<ShyneeReadySettings>()
                .CustomInstantiator(f => new ShyneeReadySettings());
        }

        private static Faker<ShyneeProfile> FakeShyneeProfile()
        {
            return new Faker<ShyneeProfile>()
                .CustomInstantiator(f => new ShyneeProfile(
                    new ShyneeProfileParameter(
                        f.PickRandomWithout(ShyneeProfileParameterStatus.Empty),
                        f.Internet.UserName()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Internet.Avatar()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Date.Past().ToLongDateString()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Random.String()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Lorem.Word()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Lorem.Paragraph()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.PickRandom<Gender>().ToString())
                    ));
        }

        private static Shynee FakeShynee()
        {
            var shyneeCredentials = FakeShyneeCredentials().Generate();
            var shyneeCoordinates = FakeShyneeCoordinates().Generate();
            var shyneeReadySettings = FakeShyneeReadySettings().Generate();
            var shyneeProfile = FakeShyneeProfile().Generate();
            var shynee = new Shynee(
                shyneeCredentials,
                shyneeCoordinates,
                shyneeProfile,
                shyneeReadySettings);
            return shynee;
        }

        public static List<Shynee> GenerateShynees()
        {
            Random random = new Random();
            var shyneesNumber = random.Next(0, 100);

            var shynees = new List<Shynee>();

            for (var i = 0; i < shyneesNumber; i++)
            {
                shynees.Add(FakeShynee());
            }

            return shynees;
        }
    }
}
