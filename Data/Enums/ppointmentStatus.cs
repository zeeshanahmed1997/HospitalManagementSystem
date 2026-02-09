namespace HospitalManagementSystem.Data.Enums
{
    public enum AppointmentStatus
    {
        /// <summary>
        /// Initial state when a patient requests an appointment
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Appointment is approved by the admin or doctor
        /// </summary>
        Confirmed = 1,

        /// <summary>
        /// Patient has arrived at the hospital and is waiting
        /// </summary>
        CheckedIn = 2,

        /// <summary>
        /// The consultation is currently happening
        /// </summary>
        InConsultation = 3,

        /// <summary>
        /// The visit is finished and medical records are updated
        /// </summary>
        Completed = 4,

        /// <summary>
        /// Cancelled by the patient or staff before the time
        /// </summary>
        Cancelled = 5,

        /// <summary>
        /// Patient failed to show up without cancelling
        /// </summary>
        NoShow = 6,

        /// <summary>
        /// Appointment needs to be moved to another slot
        /// </summary>
        Rescheduled = 7
    }
}
