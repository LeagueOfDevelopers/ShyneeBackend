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

        public ShyneeReadySettings(
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
        /// I am ready option
        /// </summary>
        public bool IsReady { get; private set; }

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

        public void UpdateIsReadySetting(bool isReady)
        {
            IsReady = isReady;
        }
    }
}
