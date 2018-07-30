using Bogus;
using ShyneeBackend.Domain;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Helpers
{
    public static class ShyneesDataFaker
    {
        private static Faker<ShyneeCoordinates> fakeShyneeCoordinates()
        {
            return new Faker<ShyneeCoordinates>()
                .CustomInstantiator(f => new ShyneeCoordinates(
                    f.Address.Latitude(),
                    f.Address.Longitude())
                );
        }

        private static Faker<ShyneeCredentials> fakeShyneeCredentials()
        {
            return new Faker<ShyneeCredentials>()
                .CustomInstantiator(f => new ShyneeCredentials(
                    f.Internet.Email(),
                    f.Internet.Password())
                );
        }

        private static Faker<ShyneeReadySettings> fakeShyneeReadySettings()
        {
            return new Faker<ShyneeReadySettings>()
                .CustomInstantiator(f => new ShyneeReadySettings());
        }

        private static Faker<ShyneeProfile> fakeShyneeProfile()
        {
            return new Faker<ShyneeProfile>()
                .CustomInstantiator(f => new ShyneeProfile(
                    new ShyneeProfileParameter(
                        f.PickRandomWithout(ShyneeProfileParameterStatusType.Empty),
                        f.Internet.UserName()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatusType>(),
                        f.Internet.Avatar()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatusType>(),
                        f.Date.Past().ToLongDateString()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatusType>(),
                        f.Random.String()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatusType>(),
                        f.Lorem.Word()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatusType>(),
                        f.Lorem.Paragraph()),
                    new ShyneeProfileParameter(
                        f.PickRandom<ShyneeProfileParameterStatusType>(),
                        f.PickRandom<Gender>().ToString())
                    ));
        }

        private static Shynee fakeShynee()
        {
            var shyneeCredentials = fakeShyneeCredentials().Generate();
            var shyneeCoordinates = fakeShyneeCoordinates().Generate();
            var shyneeReadySettings = fakeShyneeReadySettings().Generate();
            var shyneeProfile = fakeShyneeProfile().Generate();
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
                shynees.Add(fakeShynee());
            }

            return shynees;
        }
    }
}
