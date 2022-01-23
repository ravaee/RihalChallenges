using Common.Models;
using Microsoft.AspNetCore.Components;

namespace RihalChallenges.Pages
{
    public class IndexBase: PageBase
    {

        protected List<CountryDTO> Countries = new List<CountryDTO>();
        protected List<ClassDTO> Classes = new List<ClassDTO>();
        protected double StudentAvarage = 0;

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetOverviewData();
            }
        }

        protected async Task SeedAgain()
        {
            await dataService.refreshDatabase();
            await GetOverviewData();
        }

        private async Task GetOverviewData()
        {
            Countries = (await Task.Run(() => countryService.GetAllWithAtListOneStudent())).ToList();
            Classes = (await Task.Run(() => classService.GetAllWithAtListOneStudent())).ToList();
            StudentAvarage = await Task.Run(() => studentService.AverageAge());
            StateHasChanged();
        }
    }
}
