using FluentValidation.Results;
using VetProManager.Service.Responses;

namespace VetProManager.Service.Helpers.Exceptions {
    public class VetProException : Exception {
        public ValidationResult ValidationResult { get; }
        public ServiceResponse ServiceResponse { get; }

        public VetProException() : base("VetPro genel bir hataya rastladı.") { }

        public VetProException(string message) : base(message) { }

        public VetProException(string message, Exception innerException) : base(message, innerException) { }


        public VetProException(string message, ValidationResult validationResult) : base(message) {
            ValidationResult = validationResult;
        }

        public VetProException(ServiceResponse serviceResponse) {
            ServiceResponse = serviceResponse;
        }
    }
}
