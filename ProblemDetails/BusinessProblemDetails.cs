namespace ExceptionTest.ProblemDetails;

public class BusinessProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Business Problem Details";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/business";
        Instance = "";
    }
}