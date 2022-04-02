using HierarchiaKlasPojazdow.Enumy;

namespace HierarchiaKlasPojazdow.RodzajPojazdu
{
    public interface ISilnik
    {
        public RodzajSilnika Silnik { get; init; }
        public double MocSilnika { get; init; }
    }
}