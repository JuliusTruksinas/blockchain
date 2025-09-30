using Hash.Enums;

namespace Hash.Models {
    public class HashInput {
        public HashAlgorithm HashAlgorithm { get; set; }
        /// <summary>
        /// Content to hash
        /// </summary>
        public string Content { get; set; }
    }
}
