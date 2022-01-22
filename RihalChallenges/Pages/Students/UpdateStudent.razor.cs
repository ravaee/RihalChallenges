using Common.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace RihalChallenges.Pages.Students
{
    public class UpdateStudentBase: PageBase
    {       

        protected StudentDTO model = new StudentDTO();

        protected List<ClassDTO> Classes = new();
        protected List<CountryDTO> Countries = new();


        [Parameter]
        public string Id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            if (Id == null)
            {
                return;
            }

            model = await studentService.Get(int.Parse(Id));

            Classes = (await classService.GetAll()).ToList();
            Countries = (await countryService.GetAll()).ToList();

        }

        protected async Task Submit()
        {
            await form.Validate();

            if (form.IsValid)
            {
                model.Class = null;
                model.Country = null;

                var isUpdated = await studentService.Update(model);

                if (isUpdated)
                {
                    Snackbar.Add("Student Has Been Updated!");
                    NavigationManager.NavigateTo("students");
                }
                else
                {
                    Snackbar.Add("Error!");
                }

            }
        }
    }
}
