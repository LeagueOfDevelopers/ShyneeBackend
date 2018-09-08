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
                    Hasher.HashPassword(f.Internet.Password()))
                );
        }

        private static Faker<ShyneeReadySettings> FakeShyneeReadySettings()
        {
            return new Faker<ShyneeReadySettings>()
                .CustomInstantiator(f => new ShyneeReadySettings());
        }

        private static Faker<ShyneeProfile> FakeShyneeProfile()
        {
            var faker = new Faker();

            var nicknameParameterStatus = faker.PickRandomWithout(ShyneeProfileParameterStatus.Empty);
            var avatarUriParameterStatus = faker.PickRandom<ShyneeProfileParameterStatus>();
            var nameParameterStatus = faker.PickRandom<ShyneeProfileParameterStatus>();
            var dobParameterStatus = faker.PickRandom<ShyneeProfileParameterStatus>();
            var genderParameterStatus = faker.PickRandom<ShyneeProfileParameterStatus>();
            var interestsParameterStatus = faker.PickRandom<ShyneeProfileParameterStatus>();
            var personalInfoParameterStatus = faker.PickRandom<ShyneeProfileParameterStatus>();

            return new Faker<ShyneeProfile>()
                .CustomInstantiator(f => new ShyneeProfile(
                    new ShyneeProfileParameter<string>(
                        nicknameParameterStatus,
                        f.Internet.UserName()),
                    new ShyneeProfileParameter<Uri>(
                        avatarUriParameterStatus,
                        avatarUriParameterStatus != ShyneeProfileParameterStatus.Empty ? 
                            new Uri(f.Internet.Avatar()) : null),
                    new ShyneeProfileParameter<string>(
                        nameParameterStatus,
                        nameParameterStatus != ShyneeProfileParameterStatus.Empty ?
                            f.Person.FirstName : null),
                    new ShyneeProfileParameter<DateTime>(
                        dobParameterStatus,
                        dobParameterStatus != ShyneeProfileParameterStatus.Empty ?
                            f.Person.DateOfBirth : default(DateTime)),
                    new ShyneeProfileParameter<Gender>(
                        genderParameterStatus,
                        genderParameterStatus != ShyneeProfileParameterStatus.Empty ? 
                            f.PickRandom<Gender>() : default(Gender)),
                    new ShyneeProfileParameter<string[]>(
                        interestsParameterStatus,
                        interestsParameterStatus != ShyneeProfileParameterStatus.Empty ? 
                            f.Random.WordsArray(0, 10) : null),
                    new ShyneeProfileParameter<string>(
                        personalInfoParameterStatus,
                        personalInfoParameterStatus != ShyneeProfileParameterStatus.Empty ? 
                            f.Lorem.Paragraph() : null)
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
            var shyneeCredentials = new ShyneeCredentials("shy@mail.com", Hasher.HashPassword("qwertyui"));
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
                new Guid("452B5C13-E964-499C-89D4-072EEC43E7A4"),
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
