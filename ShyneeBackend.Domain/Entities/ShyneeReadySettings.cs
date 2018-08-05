namespace ShyneeBackend.Domain.Entities
{
    public class ShyneeReadySettings
    {
        public ShyneeReadySettings(
            bool isReady = false, 
            bool backgroundModeIsEnabled = false, 
            bool metroModeIsEnabled = false, 
            bool pushNotificationsAreEnabled = true, 
            bool offerMetroModeActivationWhenNoCoonnectionIsEnabled = true, 
            bool offerMetroModeDeactivationWhenCoonnectionIsEnabled = true, 
            bool pushNotificationOnNewAcquaintanceIsEnabled = true)
        {
            IsReady = isReady;
            BackgroundModeIsEnabled = backgroundModeIsEnabled;
            MetroModeIsEnabled = metroModeIsEnabled;
            PushNotificationsAreEnabled = pushNotificationsAreEnabled;
            OfferMetroModeActivationWhenNoCoonnectionIsEnabled = offerMetroModeActivationWhenNoCoonnectionIsEnabled;
            OfferMetroModeDeactivationWhenCoonnectionIsEnabled = offerMetroModeDeactivationWhenCoonnectionIsEnabled;
            PushNotificationOnNewAcquaintanceIsEnabled = pushNotificationOnNewAcquaintanceIsEnabled;
        }

        /// <summary>
        /// I am ready option
        /// </summary>
        public bool IsReady { get; set; }

        /// <summary>
        /// Background mode option
        /// </summary>
        public bool BackgroundModeIsEnabled { get; set; }

        /// <summary>
        /// Metro mode option
        /// (Switches ready option)
        /// </summary>
        public bool MetroModeIsEnabled { get; set; }

        /// <summary>
        /// Chat push notifications
        /// </summary>
        public bool PushNotificationsAreEnabled { get; set; }

        /// <summary>
        /// Offer to turn on metro mode when no network connection
        /// </summary>
        public bool OfferMetroModeActivationWhenNoCoonnectionIsEnabled { get; set; }

        /// <summary>
        /// Offer to turn off metro mode when network connection
        /// </summary>
        public bool OfferMetroModeDeactivationWhenCoonnectionIsEnabled { get; set; }

        /// <summary>
        /// New acquintance request push notification
        /// </summary>
        public bool PushNotificationOnNewAcquaintanceIsEnabled { get; set; }
    }
}
