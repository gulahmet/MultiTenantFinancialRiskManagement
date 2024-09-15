using AutoMapper;
using FinancialRiskManagement.Business.Dto;
using FinancialRiskManagement.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialRiskManagement.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBusinessPartnerDto, BusinessPartner>()
              .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<BusinessPartner, BusinessPartnerDto>().ReverseMap();
            CreateMap<BusinessTopic, BusinessTopicDto>().ReverseMap();
            // Contract ve ContractDto arasındaki mapping
            CreateMap<Contract, ContractDto>().ReverseMap();
            // FinancialReport ve FinancialReportDto arasındaki mapping
            CreateMap<FinancialReport, FinancialReportDto>().ReverseMap();
            CreateMap<RiskAnalysis, RiskAnalysisDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AgreementEvaluation, AgreementEvaluationDto>().ReverseMap();
        }
    }
}
