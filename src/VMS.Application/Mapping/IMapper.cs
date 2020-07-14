namespace VMS.Application.Mapping
{
    public interface IMapper<in Tsource, Tout> where Tsource : class
    {
        public Tout Map(Tsource source);
    }
}
