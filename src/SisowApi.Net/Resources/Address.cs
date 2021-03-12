namespace SisowApi.Net.Resources
{
    public class Address
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Chamber of Commerce number of the company
        /// </summary>
        public string ChamberOfCommerceNumber { get; set; }

        /// <summary>
        /// First address line
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Second address line
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// ZIP-code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Country ISO code (default is ‘NL’)
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Telephone number
        /// </summary>
        public string Phone { get; set; }
    }
}
