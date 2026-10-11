#nullable disable
using System;
using System.Collections.Generic;
using PolicyService.Api.Commands.Dtos;

namespace PolicyService.Api.Commands
{
    public class CreateOfferCommand
    {
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; } = new List<string>();
        public List<QuestionAnswer> Answers { get; set; } = new List<QuestionAnswer>();
    }

    public class CreateOfferResult
    {
        public string OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CreatePolicyCommand
    {
        public string OfferNumber { get; set; }
        public PersonDto PolicyHolder { get; set; }
        public AddressDto PolicyHolderAddress { get; set; }
    }

    public class CreatePolicyResult
    {
        public string PolicyNumber { get; set; }
    }
}
