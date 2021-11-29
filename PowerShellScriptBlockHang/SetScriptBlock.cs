using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace PowerShellScriptBlockHang;

[Cmdlet("Set", "ScriptBlock"), OutputType(typeof(bool))]
public class SetScriptBlock : PSCmdlet
{
    /// <summary>
    /// <para type="description">Indicates whether the user would like to receive output. </para>
    /// </summary>
    [Parameter(Mandatory = true)]
    public ScriptBlock Expression { get; set; } = null!;


    protected override void ProcessRecord()
    {
        State.ScriptBlock = Expression;
        State.SessionState = SessionState;
        State.InvokeCommand = InvokeCommand;
        base.ProcessRecord();
    }
}