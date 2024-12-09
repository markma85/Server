using System.Text.Json.Serialization;

namespace InnovateFuture.Api.Common
{
    public class CommonResponse<T>
    {
        /*
         * 1. Success: Used to indicate whether the operation was successful.
           2. Message: The message describing the success or failure of the operation.
           3. Data: The specific data returned, which can be empty.
           4. Errors: A list of error messages returned when the operation fails.
         */
        public bool IsSuccess { get; set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; }
    }
}