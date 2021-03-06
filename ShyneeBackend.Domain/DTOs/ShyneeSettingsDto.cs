﻿namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeSettingsDto
    {
        public ShyneeSettingsDto(
            bool backgroundModeIsEnabled, 
            bool metroModeIsEnabled, 
            bool pushNotificationsAreEnabled, 
            bool offerMetroModeActivationWhenNoCoonnectionIsEnabled, 
            bool offerMetroModeDeactivationWhenCoonnectionIsEnabled, 
            bool pushNotificationOnNewAcquaintanceIsEnabled)
        {
            BackgroundModeIsEnabled = backgroundModeIsEnabled;
            MetroModeIsEnabled = metroModeIsEnabled;
            PushNotificationsAreEnabled = pushNotificationsAreEnabled;
            OfferMetroModeActivationWhenNoCoonnectionIsEnabled = offerMetroModeActivationWhenNoCoonnectionIsEnabled;
            OfferMetroModeDeactivationWhenCoonnectionIsEnabled = offerMetroModeDeactivationWhenCoonnectionIsEnabled;
            PushNotificationOnNewAcquaintanceIsEnabled = pushNotificationOnNewAcquaintanceIsEnabled;
        }


        /// <summary>
        /// Background mode option
        /// </summary>
        public bool BackgroundModeIsEnabled { get; }

        /// <summary>
        /// Metro mode option
        /// (Switches ready option)
        /// </summary>
        public bool MetroModeIsEnabled { get; }

        /// <summary>
        /// Chat push notifications
        /// </summary>
        public bool PushNotificationsAreEnabled { get; }

        /// <summary>
        /// Offer to turn on metro mode when no network connection
        /// </summary>
        public bool OfferMetroModeActivationWhenNoCoonnectionIsEnabled { get; }

        /// <summary>
        /// Offer to turn off metro mode when network connection
        /// </summary>
        public bool OfferMetroModeDeactivationWhenCoonnectionIsEnabled { get; }

        /// <summary>
        /// New acquintance request push notification
        /// </summary>
        public bool PushNotificationOnNewAcquaintanceIsEnabled { get; }
    }
}
