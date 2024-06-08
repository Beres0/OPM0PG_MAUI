namespace WSH_HomeAssignment.Domain.Contracts
{
    public interface IPaginationArgs
    {
        int Skip { get; }
        int Take { get; }
    }
}