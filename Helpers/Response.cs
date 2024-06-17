namespace ResourceRequestService.Helpers
{
    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }


        public string Error { get; set; }
    }
}
