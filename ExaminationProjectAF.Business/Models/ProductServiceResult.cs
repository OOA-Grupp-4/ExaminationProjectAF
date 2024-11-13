namespace ExaminationProjectAF.Business.Models;

public class ProductServiceResult : BaseResponseResult
{

}

public class ProductServiceResult<T> : BaseResponseResult
{
    public T? Data { get; set; }
}
