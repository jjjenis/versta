namespace Presentation.ViewModels.Common;

public sealed class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => string.IsNullOrEmpty(RequestId) is false;
}
