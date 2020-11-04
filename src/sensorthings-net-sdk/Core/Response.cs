using System;
using System.Net;

namespace SensorThings.Core
{
    public class Response<T>
    {
        private Response() { }

        /// <summary>
        /// Expected result from the service
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Location of the object.
        /// </summary>
        public Uri Location { get; set; }

        /// <summary>
        /// True if request was sucesfully and returned with expected result
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Readable error string
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Error returned by service
        /// </summary>
        public string ServiceError { get; set; }

        /// <summary>
        /// Service returned status code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Create a successful response
        /// </summary>
        /// <param name="location"></param>
        /// <param name="result"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static Response<T> CreateSuccessful(Uri location, T result, HttpStatusCode httpStatusCode)
        {
            return new Response<T> { Success = true, Location = location, Result = result, HttpStatusCode = httpStatusCode };
        }

        /// <summary>
        /// Create an unsuccessful response
        /// </summary>
        /// <param name="location"></param>
        /// <param name="serviceError"></param>
        /// <param name="httpStatusCode"></param>
        /// <returns></returns>
        public static Response<T> CreateUnsuccessful(Uri location, string serviceError, HttpStatusCode httpStatusCode)
        {
            return new Response<T> { Success = false, Location = location, Error = "See ServiceError", ServiceError = serviceError, HttpStatusCode = httpStatusCode };
        }
    }
}
