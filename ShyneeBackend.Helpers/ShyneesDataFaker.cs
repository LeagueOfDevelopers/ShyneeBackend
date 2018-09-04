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
                    new ShyneeProfileParameter<string>(
                        f.PickRandomWithout(ShyneeProfileParameterStatus.Empty),
                        f.Internet.UserName()),
                    new ShyneeProfileParameter<Uri>(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        new Uri(f.Internet.Avatar())),
                    new ShyneeProfileParameter<string>(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Person.FirstName),
                    new ShyneeProfileParameter<DateTime>(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Person.DateOfBirth),
                    new ShyneeProfileParameter<Gender>(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.PickRandom<Gender>()),
                    new ShyneeProfileParameter<string[]>(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Random.WordsArray(0, 10)),
                    new ShyneeProfileParameter<string>(
                        f.PickRandom<ShyneeProfileParameterStatus>(),
                        f.Lorem.Paragraph())
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

        private static Shynee GetStaticShynee()
        {
            var shyneeCredentials = new ShyneeCredentials("shy@mail.com", "qwertyui");
            var shyneeCoordinates = FakeShyneeCoordinates().Generate();
            var shyneeReadySettings = new ShyneeReadySettings();
            var shyneeProfile = new ShyneeProfile(new ShyneeProfileParameter<string>(ShyneeProfileParameterStatus.Visible, "Shynee"),
                    new ShyneeProfileParameter<Uri>(ShyneeProfileParameterStatus.Empty),
                    new ShyneeProfileParameter<string>(ShyneeProfileParameterStatus.Empty),
                    new ShyneeProfileParameter<DateTime>(ShyneeProfileParameterStatus.Empty),
                    new ShyneeProfileParameter<Gender>(ShyneeProfileParameterStatus.Empty),
                    new ShyneeProfileParameter<string[]>(ShyneeProfileParameterStatus.Empty),
                    new ShyneeProfileParameter<string>(ShyneeProfileParameterStatus.Empty));
            var shynee = new Shynee(
                Guid.Empty,
                shyneeCredentials,
                shyneeCoordinates,
                shyneeProfile,
                shyneeReadySettings);
            return shynee;
        }

        public static List<Shynee> GenerateShynees()
        {
            Random random = new Random();
            var shyneesNumber = random.Next(0, 1000);

            var shynees = new List<Shynee>();

            for (var i = 0; i < shyneesNumber; i++)
            {
                shynees.Add(FakeShynee());
            }

            var staticShynee = GetStaticShynee();

            shynees.Add(staticShynee);

            return shynees;
        }
    }
}
