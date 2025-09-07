namespace UnifiedHttpContextLib
{
    /// <summary>
    /// Represents how the HTTP request body has been read.
    /// Unified version of System.Web.ReadEntityBodyMode for .NET Core compatibility.
    /// </summary>
    public enum UnifiedReadEntityBodyMode
    {
        None = 0,          // Request body has not been read
        Classic = 1,       // Read via InputStream (Framework) or Body stream (Core)
        ReadBuffered = 2,  // Request body buffered (e.g., EnableBuffering() in Core)
        ReadPartial = 3,   // Only partially read
        ReadDirect = 4     // Read directly without buffering
    }
}
