using AutoMapper;
using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Dtos.Matieres;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Domain.Modeles;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Enseignants;

namespace Gdc.Features.Mapping
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
            CreateMap<EnseignantACreerDto, EnseignantACreerMessage>().ReverseMap();

            //Cours Generique
            CreateMap<CoursGenerique, CoursGeneriqueDto>().ReverseMap();
            CreateMap<CoursGenerique, CoursGeneriqueDetailDto>().ReverseMap();
            CreateMap<CoursGenerique, CoursGeneriqueACreerDto>().ReverseMap();
            CreateMap<CoursGenerique, CoursGeneriqueAModifierDto>().ReverseMap();

            
            // Niveau
            CreateMap<Niveau, NiveauDto>().ReverseMap();
            CreateMap<Niveau, NiveauDetailDto>().ReverseMap();
            CreateMap<Niveau, NiveauACreerDto >().ReverseMap();
            CreateMap<Niveau, NiveauAModifierDto>().ReverseMap();
            CreateMap<NiveauACreerDto, NiveauACreerMessage>().ReverseMap();
        }
    }
}
