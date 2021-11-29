using System.Management.Automation;
using System.Management.Automation.Subsystem;
using System.Management.Automation.Subsystem.Prediction;
using System.Reflection;

namespace PowerShellScriptBlockHang;

[Cmdlet("Install", "ScriptBlock"), OutputType(typeof(bool))]
public class InstallScriptBlock : PSCmdlet
{


    public static string AssemblyPath
    {
        get
        {
            string codeBase = Assembly.GetExecutingAssembly().Location;
            UriBuilder uri = new UriBuilder(codeBase);
            return Uri.UnescapeDataString(uri.Path); ;
        }
    }

    protected override void ProcessRecord()
    {
        var path = Path.Combine(Path.GetDirectoryName(AssemblyPath), "script.ps1");
        var script = ScriptBlock.Create("set-scriptblock -Expression { @( 'One', ' *$Two' ) | % { $_.trim(\" *$\") } }");
        InvokeCommand.InvokeScript(true, script, new List<object>());
        InvokeCommand.InvokeScript("Set-PSReadLineOption -PredictionSource Plugin");
        SubsystemManager.RegisterSubsystem<ICommandPredictor, Predictor>(new Predictor());
        base.ProcessRecord();
    }

}
