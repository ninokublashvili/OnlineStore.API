namespace OnlineStore.Application.Services
{
    public class GuidOrderNumberGenerator
    {
        public string Generate()
        {
            return $"ORD-{Guid.NewGuid():N}".Substring(0, 16);
        }
    }
}
