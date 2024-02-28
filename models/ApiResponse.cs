namespace ShopApi.models
{
    public class ApiResponse
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public Dictionary<string, dynamic>? data { get; set; }

        public ApiResponse setSuccess(Dictionary<string, dynamic>? data = null)
        {
            var response = new ApiResponse();
            data ??= new Dictionary<string, dynamic>();
            response.data = data;
            response.status = true;
            response.message = "success";
            return response;
        }

        public ApiResponse setFailure(Dictionary<string, dynamic>? data = null)
        {
            var response = new ApiResponse();
            data ??= new Dictionary<string, dynamic>();
            response.data = data;
            response.status = false;
            response.message = "error";
            return response;
        }
    }
}
