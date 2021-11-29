using System.Management.Automation;

namespace PowerShellScriptBlockHang;

static class State
{
    public static CommandInvocationIntrinsics InvokeCommand { get; set; }
    public static SessionState SessionState { get; set; }
    public static ScriptBlock ScriptBlock { get; set; }
}
