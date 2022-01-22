using Common.Models;
using Microsoft.AspNetCore.Components;

namespace RihalChallenges.Pages
{
    public class IndexBase: PageBase
    {

        protected List<CountryDTO> Countries = new List<CountryDTO>();
        protected List<ClassDTO> Classes = new List<ClassDTO>();

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Countries = (await Task.Run(() => countryService.GetAllWithAtListOneStudent())).ToList();
                Classes = (await Task.Run(() => classService.GetAllWithAtListOneStudent())).ToList();
                StateHasChanged();
            }

        }
    }
}
