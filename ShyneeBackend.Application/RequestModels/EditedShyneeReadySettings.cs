using System.ComponentModel.DataAnnotations;

namespace ShyneeBackend.Application.RequestModels
{
    public class EditedShyneeReadySettings
    {
        [Required]
        public bool BackgroundModeIsEnabled { get; set; }

        [Required]
        public bool MetroModeIsEnabled { get; set; }

        [Required]
        public bool PushNotificationsAreEnabled { get; set; }

        [Required]
        public bool OfferMetroModeActivationWhenNoCoonnectionIsEnabled { get; set; }

        [Required]
        public bool OfferMetroModeDeactivationWhenCoonnectionIsEnabled { get; set; }

        [Required]
        public bool PushNotificationOnNewAcquaintanceIsEnabled { get; set; }
    }
}
