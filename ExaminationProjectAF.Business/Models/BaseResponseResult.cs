namespace ExaminationProjectAF.Business.Models;

public abstract class BaseResponseResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}
