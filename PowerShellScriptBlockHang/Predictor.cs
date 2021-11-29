using System.Management.Automation.Subsystem.Prediction;

namespace PowerShellScriptBlockHang;

public class Predictor : ICommandPredictor
{
    public string Description => "TestHang";

    public Guid Id => new Guid("7959E3B3-8444-478A-A821-48A07FB407DF");

    public string Name => "TestHang";

    public bool CanAcceptFeedback(PredictionClient client, PredictorFeedbackKind feedback)
    {
        return false;
    }

    public SuggestionPackage GetSuggestion(PredictionClient client, PredictionContext context, CancellationToken cancellationToken)
    {
        try
        {
            //The line below will cause a permanent hang of this thread!
            var result = State.InvokeCommand.InvokeScript(State.SessionState, State.ScriptBlock);
            //We never get here!
        }
        catch (Exception ex)
        {
            throw;
        }        

        return default;
    }

    public void OnCommandLineAccepted(PredictionClient client, IReadOnlyList<string> history)
    {
    }

    public void OnCommandLineExecuted(PredictionClient client, string commandLine, bool success)
    {
    }

    public void OnSuggestionAccepted(PredictionClient client, uint session, string acceptedSuggestion)
    {
    }

    public void OnSuggestionDisplayed(PredictionClient client, uint session, int countOrIndex)
    {
    }
}
