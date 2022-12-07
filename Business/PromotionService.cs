using DataAccess.Repository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business
{
    public class PromotionService : IPromotionService
    {
        private readonly HttpClient _httpClient;
        private readonly IUniversityManagementRepository _universityManagementRepository;

        public PromotionService(
            HttpClient httpClient,
            IUniversityManagementRepository universityManagementRepository)
        {
            _httpClient = httpClient;
            _universityManagementRepository = universityManagementRepository;
        }


        public async Task<bool> PromoteInCampusStudentAsync(
            InCampusStudent student)
        {
            if (await CheckIfInCampusStudentIsEligibleForPromotion(student.Id))
            {
                student.Level++;
                await _universityManagementRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }


        private async Task<bool> CheckIfInCampusStudentIsEligibleForPromotion(
            Guid studentId)
        {
            // call into API
            var apiRoot = "http://localhost:5250";

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{apiRoot}/api/promotioneligibilities/{studentId}");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // deserialize content
            var content = await response.Content.ReadAsStringAsync();
            var promotionEligibility = JsonSerializer
                .Deserialize<PromotionEligibility>(content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            // return value
            return promotionEligibility == null ?
                false : promotionEligibility.EligibleForPromotion;
        }
    }
}
