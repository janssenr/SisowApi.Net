namespace SisowApi.Net.Types
{
    public class PaymentStatus
    {
        /// <summary>
        /// A succesfull transaction
        /// </summary>
        public const string STATUS_SUCCESS = "Success";

        /// <summary>
        /// The transaction is Expired
        /// </summary>
        public const string STATUS_Expired = "Expired";

        /// <summary>
        /// The transaction is cancelled
        /// </summary>
        public const string STATUS_Cancelled = "Cancelled";

        /// <summary>
        /// An internal error has occurred with the chosen payment method
        /// </summary>
        public const string STATUS_Failure = "Failure";

        /// <summary>
        /// Awaiting actual payment, payment is not certain yet.
        /// </summary>
        public const string STATUS_Pending = "Pending";

        /// <summary>
        /// The transaction has been reversed
        /// </summary>
        public const string STATUS_Reversed = "Reversed";

        /// <summary>
        /// The transaction request has been rejected by the payment method (AfterPay/Focum/Klarna/Billink)
        /// </summary>
        public const string STATUS_Denied = "Denied";

        /// <summary>
        /// Transaction request successful invoice still needs to be created (AfterPay/Focum/Klarna/Billink)
        /// </summary>
        public const string STATUS_Reservation = "Reservation";

        /// <summary>
        /// The transaction is still processing
        /// </summary>
        public const string STATUS_Open = "Open";
    }
}
