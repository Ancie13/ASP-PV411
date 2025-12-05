namespace ASP_PV411.Services.Rfn
{
    //Random File Name
    public interface IRfnService
    {
        string GetRfn(int? length = null);
    }
}
