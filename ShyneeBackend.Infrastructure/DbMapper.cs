using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using ShyneeBackend.Domain;
using ShyneeBackend.Domain.Entities;
using System;

namespace ShyneeBackend.Infrastructure
{
    public class DbMapper
    {
        public DbMapper()
        {
            BsonClassMap.RegisterClassMap<ShyneeProfileParameter<dynamic>>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(c => c.Status)
                   .SetSerializer(new EnumSerializer<ShyneeProfileParameterStatus>());
                cm.MapMember(c => c.Parameter);
            });

            BsonClassMap.RegisterClassMap<ShyneeCredentials>(cm =>
            {
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(c => c.Email);
                cm.MapMember(c => c.Password);
                cm.MapMember(c => c.HasGoogleAccount);
                cm.MapMember(c => c.HasFacebookAccount);
                cm.MapCreator(c => new ShyneeCredentials(
                    c.Email,
                    c.Password,
                    c.HasGoogleAccount,
                    c.HasFacebookAccount));
            });

            BsonClassMap.RegisterClassMap<ShyneeCoordinates>(cm =>
            {
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(c => c.Latitude);
                cm.MapMember(c => c.Longitude);
                cm.MapCreator(c => new ShyneeCoordinates(
                    c.Latitude,
                    c.Longitude));
            });

            BsonClassMap.RegisterClassMap<ShyneeProfile>(cm =>
            {
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(c => c.Nickname);
                cm.MapMember(c => c.AvatarUri);
                cm.MapMember(c => c.Name);
                cm.MapMember(c => c.Dob);
                cm.MapMember(c => c.Gender);
                cm.MapMember(c => c.Interests);
                cm.MapMember(c => c.PersonalInfo);
                cm.MapCreator(c => new ShyneeProfile(
                    c.Nickname,
                    c.AvatarUri,
                    c.Name,
                    c.Dob,
                    c.Gender,
                    c.Interests,
                    c.PersonalInfo));
            });

            BsonClassMap.RegisterClassMap<ShyneeSettings>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapMember(c => c.IsReady);
                cm.MapMember(c => c.BackgroundModeIsEnabled);
                cm.MapMember(c => c.MetroModeIsEnabled);
                cm.MapMember(c => c.PushNotificationsAreEnabled);
                cm.MapMember(c => c.OfferMetroModeActivationWhenNoCoonnectionIsEnabled);
                cm.MapMember(c => c.OfferMetroModeDeactivationWhenCoonnectionIsEnabled);
                cm.MapMember(c => c.PushNotificationOnNewAcquaintanceIsEnabled);
                cm.MapCreator(c => new ShyneeSettings(
                    c.IsReady,
                    c.BackgroundModeIsEnabled,
                    c.MetroModeIsEnabled,
                    c.PushNotificationsAreEnabled,
                    c.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                    c.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                    c.PushNotificationOnNewAcquaintanceIsEnabled));
            });

            BsonClassMap.RegisterClassMap<Shynee>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapIdMember(s => s.Id);
                cm.MapMember(s => s.Profile);
                cm.MapMember(s => s.Coordinates);
                cm.MapMember(s => s.Credentials);
                cm.MapMember(s => s.Settings);

                cm.MapCreator(s => new Shynee(
                    s.Id,
                    new ShyneeCredentials(
                        s.Credentials.Email,
                        s.Credentials.Password,
                        s.Credentials.HasGoogleAccount,
                        s.Credentials.HasFacebookAccount),
                    new ShyneeCoordinates(
                        s.Coordinates.Latitude,
                        s.Coordinates.Longitude),
                    new ShyneeProfile(
                        s.Profile.Nickname,
                        s.Profile.AvatarUri,
                        s.Profile.Name,
                        s.Profile.Dob,
                        s.Profile.Gender,
                        s.Profile.Interests,
                        s.Profile.PersonalInfo),
                    new ShyneeSettings(
                        s.Settings.IsReady,
                        s.Settings.BackgroundModeIsEnabled,
                        s.Settings.MetroModeIsEnabled,
                        s.Settings.PushNotificationsAreEnabled,
                        s.Settings.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                        s.Settings.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                        s.Settings.PushNotificationOnNewAcquaintanceIsEnabled)
                    ));
            });
        }
    }
}
