// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace TaxiFareML.Model;

public class TaxiFareModelInput
{
    [ColumnName("vendor_id"), LoadColumn(0)]
    public string VendorId { get; set; } = string.Empty;


    [ColumnName("rate_code"), LoadColumn(1)]
    public float RateCode { get; set; }


    [ColumnName("passenger_count"), LoadColumn(2)]
    public float PassengerCount { get; set; }


    [ColumnName("trip_time_in_secs"), LoadColumn(3)]
    public float TripTimeInSecs { get; set; }


    [ColumnName("trip_distance"), LoadColumn(4)]
    public float TripDistance { get; set; }


    [ColumnName("payment_type"), LoadColumn(5)]
    public string PaymentType { get; set; } = string.Empty;


    [ColumnName("fare_amount"), LoadColumn(6)]
    public float FareAmount { get; set; }


}