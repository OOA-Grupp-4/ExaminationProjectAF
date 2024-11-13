namespace ExaminationProjectAF.Business.Models;

public class CartServiceResult : BaseResponseResult
{

}

public class CartServiceResult<T> : BaseResponseResult
{
    public T? Data { get; set; }
}
