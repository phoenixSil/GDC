using AutoMapper;
using Gdc.Api.Dtos.CoursGeneriques;
using Gdc.Api.Dtos.Enseignants;
using Gdc.Api.Dtos.Matieres;
using Gdc.Api.Dtos.Niveaux;
using Gdc.Api.Modeles;

namespace Gdc.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Matieres 
            CreateMap<Matiere, MatiereDto>().ReverseMap();
            CreateMap<Matiere, MatiereDetailDto>().ReverseMap();
            CreateMap<Matiere, MatiereACreerDto>().ReverseMap();
            CreateMap<Matiere, MatiereAModifierDto>().ReverseMap();

            // Enseignants 
            CreateMap<Enseignant, EnseignantDto>().ReverseMap();
            CreateMap<Enseignant, EnseignantDetailDto>().ReverseMap();
            CreateMap<Enseignant, EnseignantACreerDto>().ReverseMap();
            CreateMap<Enseignant, EnseignantAModifierDto>().ReverseMap();
            CreateMap<EnseignantACreerDto, EnseignantAModifierDto>().ReverseMap();

            //Cours Generique
            CreateMap<CoursGenerique, CoursGeneriqueDto>().ReverseMap();
            CreateMap<CoursGenerique, CoursGeneriqueDetailDto>().ReverseMap();
            CreateMap<CoursGenerique, CoursGeneriqueACreerDto>().ReverseMap();
            CreateMap<CoursGenerique, CoursGeneriqueAModifierDto>().ReverseMap();

            
            // Niveau
            CreateMap<Niveau, NiveauDto>().ReverseMap();
            CreateMap<Niveau, NiveauDetailDto>().ReverseMap();
            CreateMap<Niveau, NiveauGdcACreerDto >().ReverseMap();
            CreateMap<Niveau, NiveauAModifierDto>().ReverseMap();
        }
    }
}
