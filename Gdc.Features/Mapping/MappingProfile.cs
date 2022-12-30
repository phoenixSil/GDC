using AutoMapper;
using Gdc.Features.Dtos.CoursGeneriques;
using Gdc.Features.Dtos.Enseignants;
using Gdc.Features.Dtos.Matieres;
using Gdc.Features.Dtos.Niveaux;
using Gdc.Domain.Modeles;
using MsCommun.Messages.Niveaux;
using MsCommun.Messages.Enseignants;
using MsCommun.Messages.Matieres;

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
            CreateMap<MatiereDetailDto, MatiereACreerMessage>()
                .ForMember(des => des.NomEnseignant,
                        opt => opt.MapFrom(src => src.Enseignant.Nom))
                .ForMember(des => des.PrenomEnseignant,
                        opt => opt.MapFrom(src => src.Enseignant.Prenom))
                .ForMember(des => des.DesignationCycle,
                        opt => opt.MapFrom(src => src.Niveau.DesignationCycle))
                .ForMember(des => des.DesignationFiliere,
                        opt => opt.MapFrom(src => src.Niveau.DesignationFiliere))
                .ForMember(des => des.DesignationNiveau,
                        opt => opt.MapFrom(src => src.Niveau.Designation))
                .ForMember(des => des.NumeroExterne,
                        opt => opt.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<MatiereDetailDto, MatiereAModifierMessage>()
               .ForMember(des => des.NomEnseignant,
                       opt => opt.MapFrom(src => src.Enseignant.Nom))
               .ForMember(des => des.PrenomEnseignant,
                       opt => opt.MapFrom(src => src.Enseignant.Prenom))
               .ForMember(des => des.DesignationCycle,
                       opt => opt.MapFrom(src => src.Niveau.DesignationCycle))
               .ForMember(des => des.DesignationFiliere,
                       opt => opt.MapFrom(src => src.Niveau.DesignationFiliere))
               .ForMember(des => des.DesignationNiveau,
                       opt => opt.MapFrom(src => src.Niveau.Designation))
               .ForMember(des => des.NumeroExterne,
                       opt => opt.MapFrom(src => src.Id)).ReverseMap();

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
