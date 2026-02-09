using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using static Azure.Core.HttpHeader;

namespace HospitalManagementSystem.DTO
{
public class ApiResponse<T>
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public T? Data { get; init; }
        public IEnumerable<string>? Errors { get; init; }   // For validation / identity errors

        // Success factory
        public static ApiResponse<T> SuccessResponse(T data, string? message = null)
            => new()
            {
                Success = true,
                Message = message,
                Data = data
            };

        // Success without data (e.g. for actions like reset)
        public static ApiResponse<object> SuccessMessage(string message)
            => new()
            {
                Success = true,
                Message = message,
                Data = null
            };

        // Error factory
        public static ApiResponse<T> ErrorResponse(string message, IEnumerable<string>? errors = null, int? statusCodeHint = null)
            => new()
            {
                Success = false,
                Message = message,
                Errors = errors ?? Enumerable.Empty<string>(),
                Data = default
            };
    }
}
