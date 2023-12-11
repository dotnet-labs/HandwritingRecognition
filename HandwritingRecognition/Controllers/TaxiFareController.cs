using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using TaxiFareML.Model;

namespace HandwritingRecognition.Controllers;

[Route("api/[controller]")]
public class TaxiFareController(
    ILogger<TaxiFareController> logger,
    PredictionEnginePool<TaxiFareModelInput, TaxiFareModelOutput> predictionEnginePool)
    : Controller
{
    [HttpGet("prediction")]
    public IActionResult Predict()
    {
        var input = new TaxiFareModelInput
        {
            VendorId = "VTS",
            RateCode = 1,
            PassengerCount = 1,
            TripTimeInSecs = 1140,
            TripDistance = 3.75f,
            PaymentType = "CSH",
            FareAmount = 0 // To predict. Actual/Observed = 15.5
        };
        var result = predictionEnginePool.Predict(modelName: TaxiFareModel.Name, example: input);
        logger.LogInformation("Predicted fare: {fare}, actual fare: 15.5", result.FareAmount);
        return Ok(result);
    }
}