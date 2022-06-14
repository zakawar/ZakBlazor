using Microsoft.JSInterop;


namespace ZakBlazorWeb_Server.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime _JsRuntime, string message)
        {
            await _JsRuntime.InvokeVoidAsync("ShowToastr","success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime _JsRuntime, string message)
        {
            await _JsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }

        public static async ValueTask SwalSuccess(this IJSRuntime _JsRuntime, string message)
        {
            await _JsRuntime.InvokeVoidAsync("ShowSawl", "success", message);
        }

        public static async ValueTask SwalError(this IJSRuntime _JsRuntime, string message)
        {
            await _JsRuntime.InvokeVoidAsync("ShowSawl", "error", message);
        }

        public static async ValueTask SwalWarning(this IJSRuntime _JsRuntime, string message)
        {
            await _JsRuntime.InvokeVoidAsync("ShowSawl", "warning", message);
        }



    }
}
